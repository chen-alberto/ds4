using Proyecto_2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Proyecto_2.Data
{
    public class OperacionRepository
    {
        private string connectionString = @"Server=.\SQLEXPRESS;Database=Operaciones;Trusted_Connection=True;TrustServerCertificate=True;";

        // Obtener todas las operaciones
        public List<Operacion> ObtenerTodas()
        {
            List<Operacion> lista = new List<Operacion>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Operacion, ResultadoFinal FROM RESULTADO";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Operacion
                            {
                                // Usar GetValue y convertir
                                operacion = dr.GetValue(0)?.ToString() ?? "",
                                resultado = Convert.ToDouble(dr.GetValue(1))
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL: {ex.Message}");
                throw;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Error de conversión: {ex.Message}");
                throw;
            }

            return lista;
        }

        // Obtener operaciones por tipo (suma, resta, multiplicacion, division)
        public List<Operacion> ObtenerPorTipo(string tipoOperacion)
        {
            List<Operacion> lista = new List<Operacion>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Operacion, ResultadoFinal FROM RESULTADO WHERE Operacion = @Operacion";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Operacion", tipoOperacion);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Operacion
                                {
                                    operacion = dr.GetValue(0)?.ToString() ?? "",
                                    resultado = Convert.ToDouble(dr.GetValue(1))
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL: {ex.Message}");
                throw;
            }

            return lista;
        }
    }
}