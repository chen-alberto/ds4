<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerExpediente.aspx.cs" Inherits="SistemaConsultasMedicas.VerExpediente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Expediente Médico</title>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); min-height: 100vh; padding: 20px; }
        .container { max-width: 1000px; margin: 0 auto; background: white; padding: 40px; border-radius: 10px; box-shadow: 0 4px 6px rgba(0,0,0,0.1); }
        h1 { color: #667eea; margin-bottom: 10px; text-align: center; }
        .subtitle { text-align: center; color: #666; margin-bottom: 30px; font-size: 18px; }
        .section { background: #f8f9fa; padding: 20px; border-radius: 8px; margin-bottom: 20px; }
        .section h3 { color: #667eea; margin-bottom: 15px; border-bottom: 2px solid #667eea; padding-bottom: 10px; }
        .info-grid { display: grid; grid-template-columns: repeat(2, 1fr); gap: 15px; }
        .info-item { background: white; padding: 12px; border-radius: 5px; }
        .info-item label { font-weight: 600; color: #333; display: block; margin-bottom: 5px; }
        .info-item .value { color: #666; }
        .info-full { background: white; padding: 15px; border-radius: 5px; margin-top: 15px; }
        .consulta-item { background: white; padding: 15px; border-radius: 5px; margin-bottom: 15px; border-left: 4px solid #667eea; }
        .consulta-header { display: flex; justify-content: space-between; margin-bottom: 10px; }
        .consulta-fecha { color: #666; font-size: 0.9em; }
        .badge { display: inline-block; padding: 5px 10px; border-radius: 3px; font-size: 0.85em; font-weight: 600; }
        .badge-pendiente { background: #fff3cd; color: #856404; }
        .badge-respondida { background: #d4edda; color: #155724; }
        .respuesta-box { background: #e7f3ff; padding: 12px; border-radius: 5px; margin-top: 10px; border-left: 3px solid #667eea; }
        .btn { background: #667eea; color: white; padding: 12px 30px; border: none; border-radius: 5px; cursor: pointer; font-size: 16px; margin-right: 10px; text-decoration: none; display: inline-block; }
        .btn:hover { background: #5568d3; }
        .btn-secondary { background: #6c757d; }
        .btn-secondary:hover { background: #5a6268; }
        .button-group { margin-top: 30px; text-align: center; }
        .no-data { text-align: center; padding: 20px; color: #666; font-style: italic; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>📋 Expediente Médico Completo</h1>
            <div class="subtitle">
                <asp:Label ID="lblPaciente" runat="server" />
            </div>

            <div class="section">
                <h3>👤 Información Personal</h3>
                <div class="info-grid">
                    <div class="info-item">
                        <label>Cédula</label>
                        <div class="value"><asp:Label ID="lblCedula" runat="server" /></div>
                    </div>
                    <div class="info-item">
                        <label>Fecha de Nacimiento</label>
                        <div class="value"><asp:Label ID="lblFechaNacimiento" runat="server" /></div>
                    </div>
                    <div class="info-item">
                        <label>Email</label>
                        <div class="value"><asp:Label ID="lblEmail" runat="server" /></div>
                    </div>
                    <div class="info-item">
                        <label>Teléfono</label>
                        <div class="value"><asp:Label ID="lblTelefono" runat="server" /></div>
                    </div>
                </div>
                <div class="info-full">
                    <label>Dirección</label>
                    <div class="value"><asp:Label ID="lblDireccion" runat="server" /></div>
                </div>
            </div>

            <asp:Panel ID="pnlExpediente" runat="server">
                <div class="section">
                    <h3>📏 Medidas y Datos Clínicos</h3>
                    <div class="info-grid">
                        <div class="info-item">
                            <label>Peso</label>
                            <div class="value"><asp:Label ID="lblPeso" runat="server" /></div>
                        </div>
                        <div class="info-item">
                            <label>Altura</label>
                            <div class="value"><asp:Label ID="lblAltura" runat="server" /></div>
                        </div>
                        <div class="info-item">
                            <label>IMC</label>
                            <div class="value"><asp:Label ID="lblIMC" runat="server" /></div>
                        </div>
                        <div class="info-item">
                            <label>Tipo de Sangre</label>
                            <div class="value"><asp:Label ID="lblTipoSangre" runat="server" /></div>
                        </div>
                    </div>

                    <div class="info-full">
                        <label>Alergias</label>
                        <div class="value"><asp:Label ID="lblAlergias" runat="server" /></div>
                    </div>

                    <div class="info-full">
                        <label>Enfermedades Crónicas</label>
                        <div class="value"><asp:Label ID="lblEnfermedadesCronicas" runat="server" /></div>
                    </div>

                    <div class="info-full">
                        <label>Medicamentos Actuales</label>
                        <div class="value"><asp:Label ID="lblMedicamentos" runat="server" /></div>
                    </div>

                    <div class="info-full">
                        <label>Cirugías Previas</label>
                        <div class="value"><asp:Label ID="lblCirugiasPrevias" runat="server" /></div>
                    </div>

                    <div style="margin-top: 15px; text-align: right; font-size: 0.9em; color: #666;">
                        Última actualización: <asp:Label ID="lblFechaActualizacion" runat="server" />
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlNoExpediente" runat="server" Visible="false">
                <div class="section">
                    <div class="no-data">
                        No hay datos del expediente médico registrados para este paciente.
                    </div>
                </div>
            </asp:Panel>

            <div class="section">
                <h3>💬 Historial de Consultas</h3>
                <asp:Panel ID="pnlConsultas" runat="server">
                    <asp:Repeater ID="rptConsultas" runat="server">
                        <ItemTemplate>
                            <div class="consulta-item">
                                <div class="consulta-header">
                                    <div>
                                        <strong>Consulta #<%# Eval("Id") %>:</strong> <%# Eval("Motivo") %>
                                        <span class='badge <%# Eval("Estado").ToString() == "Pendiente" ? "badge-pendiente" : "badge-respondida" %>'>
                                            <%# Eval("Estado") %>
                                        </span>
                                    </div>
                                    <div class="consulta-fecha">
                                        <%# Convert.ToDateTime(Eval("FechaCreacion")).ToString("dd/MM/yyyy HH:mm") %>
                                    </div>
                                </div>
                                
                                <div><strong>Descripción:</strong> <%# Eval("Descripcion") %></div>
                                
                                <asp:Panel ID="pnlRespuesta" runat="server" Visible='<%# !string.IsNullOrEmpty(Eval("Respuesta").ToString()) %>'>
                                    <div class="respuesta-box">
                                        <strong>👨‍⚕️ Respuesta del Dr. <%# Eval("NombreMedico") %>:</strong><br />
                                        <%# Eval("Respuesta") %><br />
                                        <small style="color: #666;">
                                            Respondida: <%# Eval("FechaRespuesta") != DBNull.Value ? Convert.ToDateTime(Eval("FechaRespuesta")).ToString("dd/MM/yyyy HH:mm") : "" %>
                                        </small>
                                    </div>
                                </asp:Panel>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </asp:Panel>

                <asp:Panel ID="pnlNoConsultas" runat="server" Visible="false">
                    <div class="no-data">
                        No hay consultas registradas para este paciente.
                    </div>
                </asp:Panel>
            </div>

            <div class="button-group">
                <asp:HyperLink ID="hlEditarExpediente" runat="server" Text="✏️ Editar Expediente" CssClass="btn" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
            </div>
        </div>
    </form>
</body>
</html>