<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaConsultasMedicas.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema de Consultas Médicas</title>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); min-height: 100vh; }
        .container { max-width: 1200px; margin: 0 auto; padding: 20px; }
        .header { background: white; padding: 30px; border-radius: 10px; box-shadow: 0 4px 6px rgba(0,0,0,0.1); margin-bottom: 30px; text-align: center; }
        .header h1 { color: #667eea; margin-bottom: 10px; }
        .header p { color: #666; }
        .menu { display: grid; grid-template-columns: repeat(auto-fit, minmax(250px, 1fr)); gap: 20px; margin-top: 20px; }
        .menu-item { background: white; padding: 30px; border-radius: 10px; box-shadow: 0 4px 6px rgba(0,0,0,0.1); text-align: center; cursor: pointer; transition: transform 0.3s, box-shadow 0.3s; }
        .menu-item:hover { transform: translateY(-5px); box-shadow: 0 6px 12px rgba(0,0,0,0.15); }
        .menu-item h3 { color: #667eea; margin-bottom: 15px; font-size: 1.5em; }
        .menu-item p { color: #666; margin-bottom: 20px; }
        .btn { background: #667eea; color: white; padding: 12px 30px; border: none; border-radius: 5px; cursor: pointer; font-size: 16px; text-decoration: none; display: inline-block; transition: background 0.3s; }
        .btn:hover { background: #5568d3; }
        .icon { font-size: 3em; margin-bottom: 15px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <h1>🏥 Sistema de Consultas Médicas</h1>
                <p>Gestión integral de consultas y expedientes médicos</p>
            </div>

            <div class="menu">
                <div class="menu-item">
                    <div class="icon">👤</div>
                    <h3>Registrar Paciente</h3>
                    <p>Registra nuevos pacientes en el sistema</p>
                    <asp:Button ID="btnRegistrarPaciente" runat="server" Text="Ir al Registro" CssClass="btn" OnClick="btnRegistrarPaciente_Click" />
                </div>

                <div class="menu-item">
                    <div class="icon">📋</div>
                    <h3>Crear Consulta</h3>
                    <p>Crea una nueva consulta médica</p>
                    <asp:Button ID="btnCrearConsulta" runat="server" Text="Nueva Consulta" CssClass="btn" OnClick="btnCrearConsulta_Click" />
                </div>

                <div class="menu-item">
                    <div class="icon">💬</div>
                    <h3>Consultas Pendientes</h3>
                    <p>Responde consultas de pacientes</p>
                    <asp:Button ID="btnConsultasPendientes" runat="server" Text="Ver Consultas" CssClass="btn" OnClick="btnConsultasPendientes_Click" />
                </div>

                <div class="menu-item">
                    <div class="icon">📁</div>
                    <h3>Expedientes</h3>
                    <p>Gestiona expedientes médicos</p>
                    <asp:Button ID="btnExpedientes" runat="server" Text="Ver Expedientes" CssClass="btn" OnClick="btnExpedientes_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>