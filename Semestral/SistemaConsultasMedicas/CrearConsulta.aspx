<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearConsulta.aspx.cs" Inherits="SistemaConsultasMedicas.CrearConsulta" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nueva Consulta Médica</title>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); min-height: 100vh; padding: 20px; }
        .container { max-width: 800px; margin: 0 auto; background: white; padding: 40px; border-radius: 10px; box-shadow: 0 4px 6px rgba(0,0,0,0.1); }
        h1 { color: #667eea; margin-bottom: 30px; text-align: center; }
        .form-group { margin-bottom: 20px; }
        label { display: block; margin-bottom: 5px; color: #333; font-weight: 600; }
        input[type="text"], textarea { width: 100%; padding: 10px; border: 1px solid #ddd; border-radius: 5px; font-size: 14px; }
        textarea { min-height: 150px; resize: vertical; }
        .btn { background: #667eea; color: white; padding: 12px 30px; border: none; border-radius: 5px; cursor: pointer; font-size: 16px; margin-right: 10px; }
        .btn:hover { background: #5568d3; }
        .btn-search { background: #28a745; }
        .btn-search:hover { background: #218838; }
        .btn-secondary { background: #6c757d; }
        .btn-secondary:hover { background: #5a6268; }
        .button-group { margin-top: 30px; text-align: center; }
        .message { padding: 15px; border-radius: 5px; margin-bottom: 20px; text-align: center; }
        .success { background: #d4edda; color: #155724; border: 1px solid #c3e6cb; }
        .error { background: #f8d7da; color: #721c24; border: 1px solid #f5c6cb; }
        .info { background: #d1ecf1; color: #0c5460; border: 1px solid #bee5eb; padding: 15px; border-radius: 5px; margin-bottom: 20px; }
        .search-section { background: #f8f9fa; padding: 20px; border-radius: 8px; margin-bottom: 25px; }
        .patient-info { background: #e7f3ff; padding: 15px; border-radius: 5px; margin-top: 15px; border-left: 4px solid #667eea; }
        .patient-info h4 { color: #667eea; margin-bottom: 10px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>💬 Nueva Consulta Médica</h1>
            
            <asp:Panel ID="pnlMessage" runat="server" Visible="false"></asp:Panel>

            <div class="search-section">
                <div class="form-group">
                    <label>Buscar Paciente por Cédula</label>
                    <div style="display: flex; gap: 10px;">
                        <asp:TextBox ID="txtBuscarCedula" runat="server" placeholder="8-123-4567" style="flex: 1;" />
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-search" OnClick="btnBuscar_Click" CausesValidation="false" />
                    </div>
                </div>

                <asp:Panel ID="pnlPacienteInfo" runat="server" Visible="false" CssClass="patient-info">
                    <h4>Paciente Encontrado</h4>
                    <asp:Label ID="lblPacienteInfo" runat="server" />
                    <asp:HiddenField ID="hfPacienteId" runat="server" />
                </asp:Panel>
            </div>

            <asp:Panel ID="pnlConsultaForm" runat="server" Visible="false">
                <div class="form-group">
                    <label>Motivo de la Consulta *</label>
                    <asp:TextBox ID="txtMotivo" runat="server" placeholder="Ej: Dolor de cabeza persistente" MaxLength="200" />
                    <asp:RequiredFieldValidator ID="rfvMotivo" runat="server" ControlToValidate="txtMotivo" 
                        ErrorMessage="El motivo es requerido" ForeColor="Red" Display="Dynamic" />
                </div>

                <div class="form-group">
                    <label>Descripción Detallada de la Consulta *</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" 
                        placeholder="Describa sus síntomas, tiempo de evolución, medicamentos que ha tomado, etc." />
                    <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion" 
                        ErrorMessage="La descripción es requerida" ForeColor="Red" Display="Dynamic" />
                </div>

                <div class="info">
                    <strong>Nota:</strong> Su consulta será enviada a nuestros médicos y recibirá una respuesta lo antes posible. 
                    La respuesta quedará registrada en el sistema junto con su expediente médico.
                </div>

                <div class="button-group">
                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar Consulta" CssClass="btn" OnClick="btnEnviar_Click" />
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" CausesValidation="false" />
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlInstrucciones" runat="server" Visible="true">
                <div class="info">
                    <strong>Instrucciones:</strong><br />
                    1. Busque al paciente por su número de cédula<br />
                    2. Complete el formulario de consulta<br />
                    3. Envíe la consulta para que sea atendida por un médico
                </div>
                <div class="button-group">
                    <asp:Button ID="btnVolverInicio" runat="server" Text="Volver al Inicio" CssClass="btn btn-secondary" OnClick="btnVolver_Click" CausesValidation="false" />
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>