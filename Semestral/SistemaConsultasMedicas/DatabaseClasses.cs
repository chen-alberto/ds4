using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SistemaConsultasMedicas
{
    // Clase para manejar conexiones a la base de datos
    public class DatabaseHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MedicalSystemDB"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static void ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }

    // Clase Paciente
    public class Paciente
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; } 
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public static int Crear(Paciente paciente)
        {
            string query = @"INSERT INTO Pacientes (Cedula, Nombre, Apellido, FechaNacimiento, Sexo, Email, Telefono, Direccion) 
                   VALUES (@Cedula, @Nombre, @Apellido, @FechaNacimiento, @Sexo, @Email, @Telefono, @Direccion);
                   SELECT CAST(SCOPE_IDENTITY() as int)";

            SqlParameter[] parameters = {
        new SqlParameter("@Cedula", paciente.Cedula),
        new SqlParameter("@Nombre", paciente.Nombre),
        new SqlParameter("@Apellido", paciente.Apellido),
        new SqlParameter("@FechaNacimiento", paciente.FechaNacimiento),
        new SqlParameter("@Sexo", paciente.Sexo ?? (object)DBNull.Value), // ← AGREGAR ESTA LÍNEA
        new SqlParameter("@Email", paciente.Email),
        new SqlParameter("@Telefono", paciente.Telefono ?? (object)DBNull.Value),
        new SqlParameter("@Direccion", paciente.Direccion ?? (object)DBNull.Value)
    };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public static DataTable ObtenerTodos()
        {
            return DatabaseHelper.ExecuteQuery("SELECT * FROM Pacientes ORDER BY Apellido, Nombre");
        }

        public static DataTable BuscarPorCedula(string cedula)
        {
            string query = "SELECT * FROM Pacientes WHERE Cedula = @Cedula";
            return DatabaseHelper.ExecuteQuery(query, new[] { new SqlParameter("@Cedula", cedula) });
        }
    }

    // Clase Expediente Médico
    public class ExpedienteMedico
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public string TipoSangre { get; set; }
        public string Alergias { get; set; }
        public string EnfermedadesCronicas { get; set; }
        public string Medicamentos { get; set; }
        public string CirugiasPrevias { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public static void CrearOActualizar(ExpedienteMedico expediente)
        {
            string query = @"IF EXISTS (SELECT 1 FROM ExpedientesMedicos WHERE PacienteId = @PacienteId)
                           UPDATE ExpedientesMedicos SET Peso=@Peso, Altura=@Altura, TipoSangre=@TipoSangre, 
                                  Alergias=@Alergias, EnfermedadesCronicas=@EnfermedadesCronicas, 
                                  Medicamentos=@Medicamentos, CirugiasPrevias=@CirugiasPrevias, 
                                  FechaActualizacion=GETDATE()
                           WHERE PacienteId = @PacienteId
                           ELSE
                           INSERT INTO ExpedientesMedicos (PacienteId, Peso, Altura, TipoSangre, Alergias, 
                                  EnfermedadesCronicas, Medicamentos, CirugiasPrevias, FechaActualizacion)
                           VALUES (@PacienteId, @Peso, @Altura, @TipoSangre, @Alergias, 
                                  @EnfermedadesCronicas, @Medicamentos, @CirugiasPrevias, GETDATE())";

            SqlParameter[] parameters = {
                new SqlParameter("@PacienteId", expediente.PacienteId),
                new SqlParameter("@Peso", expediente.Peso),
                new SqlParameter("@Altura", expediente.Altura),
                new SqlParameter("@TipoSangre", expediente.TipoSangre ?? (object)DBNull.Value),
                new SqlParameter("@Alergias", expediente.Alergias ?? (object)DBNull.Value),
                new SqlParameter("@EnfermedadesCronicas", expediente.EnfermedadesCronicas ?? (object)DBNull.Value),
                new SqlParameter("@Medicamentos", expediente.Medicamentos ?? (object)DBNull.Value),
                new SqlParameter("@CirugiasPrevias", expediente.CirugiasPrevias ?? (object)DBNull.Value)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public static DataTable ObtenerPorPaciente(int pacienteId)
        {
            string query = "SELECT * FROM ExpedientesMedicos WHERE PacienteId = @PacienteId";
            return DatabaseHelper.ExecuteQuery(query, new[] { new SqlParameter("@PacienteId", pacienteId) });
        }
    }

    // Clase Consulta
    public class Consulta
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public string Motivo { get; set; }
        public string Descripcion { get; set; }
        public string Respuesta { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaRespuesta { get; set; }

        public static int Crear(Consulta consulta)
        {
            string query = @"INSERT INTO Consultas (PacienteId, Motivo, Descripcion, Estado, FechaCreacion)
                           VALUES (@PacienteId, @Motivo, @Descripcion, 'Pendiente', GETDATE());
                           SELECT CAST(SCOPE_IDENTITY() as int)";

            SqlParameter[] parameters = {
                new SqlParameter("@PacienteId", consulta.PacienteId),
                new SqlParameter("@Motivo", consulta.Motivo),
                new SqlParameter("@Descripcion", consulta.Descripcion)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public static void Responder(int consultaId, int medicoId, string respuesta)
        {
            string query = @"UPDATE Consultas SET MedicoId=@MedicoId, Respuesta=@Respuesta, 
                           Estado='Respondida', FechaRespuesta=GETDATE()
                           WHERE Id=@Id";

            SqlParameter[] parameters = {
                new SqlParameter("@Id", consultaId),
                new SqlParameter("@MedicoId", medicoId),
                new SqlParameter("@Respuesta", respuesta)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public static DataTable ObtenerPendientes()
        {
            string query = @"SELECT c.Id, c.Motivo, c.Descripcion, c.FechaCreacion,
                           p.Nombre + ' ' + p.Apellido AS Paciente, p.Cedula
                           FROM Consultas c
                           INNER JOIN Pacientes p ON c.PacienteId = p.Id
                           WHERE c.Estado = 'Pendiente'
                           ORDER BY c.FechaCreacion DESC";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public static DataTable ObtenerPorPaciente(int pacienteId)
        {
            string query = @"SELECT c.*, m.Nombre + ' ' + m.Apellido AS NombreMedico
                           FROM Consultas c
                           LEFT JOIN Medicos m ON c.MedicoId = m.Id
                           WHERE c.PacienteId = @PacienteId
                           ORDER BY c.FechaCreacion DESC";
            return DatabaseHelper.ExecuteQuery(query, new[] { new SqlParameter("@PacienteId", pacienteId) });
        }
    }

    // Clase Médico
    public class Medico
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public static DataTable ObtenerTodos()
        {
            return DatabaseHelper.ExecuteQuery("SELECT * FROM Medicos ORDER BY Apellido, Nombre");
        }

        public static int Crear(Medico medico)
        {
            string query = @"INSERT INTO Medicos (Cedula, Nombre, Apellido, Especialidad, Email, Telefono)
                           VALUES (@Cedula, @Nombre, @Apellido, @Especialidad, @Email, @Telefono);
                           SELECT CAST(SCOPE_IDENTITY() as int)";

            SqlParameter[] parameters = {
                new SqlParameter("@Cedula", medico.Cedula),
                new SqlParameter("@Nombre", medico.Nombre),
                new SqlParameter("@Apellido", medico.Apellido),
                new SqlParameter("@Especialidad", medico.Especialidad),
                new SqlParameter("@Email", medico.Email),
                new SqlParameter("@Telefono", medico.Telefono)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}