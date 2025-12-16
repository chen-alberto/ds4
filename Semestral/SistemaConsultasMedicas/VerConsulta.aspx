<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerConsulta.aspx.cs" Inherits="SistemaConsultasMedicas.VerConsulta" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Ver Consulta - Sistema de Consultas Médicas</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh;
            padding: 20px;
        }

        .container {
            max-width: 1000px;
            margin: 0 auto;
            background: white;
            border-radius: 10px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.2);
            overflow: hidden;
        }

        .header {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            padding: 30px;
            text-align: center;
        }

        .header h1 {
            font-size: 28px;
            margin-bottom: 10px;
        }

        .header p {
            font-size: 14px;
            opacity: 0.9;
        }

        .content {
            padding: 30px;
        }

        .status-banner {
            padding: 15px 25px;
            margin-bottom: 25px;
            border-radius: 8px;
            font-weight: 600;
            text-align: center;
            font-size: 16px;
        }

        .status-pendiente {
            background: #fff3cd;
            color: #856404;
            border: 2px solid #ffc107;
        }

        .status-respondida {
            background: #d4edda;
            color: #155724;
            border: 2px solid #28a745;
        }

        .section {
            background: #f8f9fa;
            border-radius: 8px;
            padding: 25px;
            margin-bottom: 25px;
            border-left: 4px solid #667eea;
        }

        .section-title {
            font-size: 18px;
            color: #667eea;
            margin-bottom: 20px;
            font-weight: 600;
            display: flex;
            align-items: center;
        }

        .section-title::before {
            content: "📋";
            margin-right: 10px;
            font-size: 22px;
        }

        .info-grid {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
            gap: 15px;
        }

        .info-row {
            padding: 12px 0;
            border-bottom: 1px solid #e0e0e0;
        }

        .info-row:last-child {
            border-bottom: none;
        }

        .info-label {
            font-weight: 600;
            color: #333;
            display: block;
            margin-bottom: 5px;
            font-size: 13px;
            text-transform: uppercase;
            color: #666;
        }

        .info-value {
            color: #333;
            font-size: 15px;
        }

        .consultation-metadata {
            display: flex;
            gap: 20px;
            margin-bottom: 20px;
            flex-wrap: wrap;
        }

        .metadata-item {
            background: white;
            padding: 15px;
            border-radius: 5px;
            flex: 1;
            min-width: 200px;
        }

        .metadata-label {
            font-size: 12px;
            color: #666;
            margin-bottom: 5px;
            text-transform: uppercase;
        }

        .metadata-value {
            font-weight: 600;
            color: #333;
            font-size: 16px;
        }

        .description-box {
            background: white;
            padding: 20px;
            border-radius: 5px;
            border: 1px solid #e0e0e0;
            line-height: 1.6;
            white-space: pre-wrap;
            color: #333;
        }

        .response-box {
            background: #e7f3ff;
            padding: 20px;
            border-radius: 5px;
            border-left: 4px solid #2196F3;
            line-height: 1.6;
            white-space: pre-wrap;
            color: #333;
        }

        .no-response {
            background: #fff3cd;
            padding: 20px;
            border-radius: 5px;
            text-align: center;
            color: #856404;
            font-style: italic;
        }

        .button-group {
            display: flex;
            gap: 15px;
            justify-content: flex-end;
            margin-top: 30px;
            padding-top: 20px;
            border-top: 2px solid #e0e0e0;
            flex-wrap: wrap;
        }

        .btn {
            padding: 12px 30px;
            border: none;
            border-radius: 5px;
            font-size: 15px;
            font-weight: 600;
            cursor: pointer;
            transition: all 0.3s;
            text-decoration: none;
            display: inline-block;
        }

        .btn-primary {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
        }

        .btn-primary:hover {
            transform: translateY(-2px);
            box-shadow: 0 5px 15px rgba(102, 126, 234, 0.4);
        }

        .btn-success {
            background: #28a745;
            color: white;
        }

        .btn-success:hover {
            background: #218838;
            transform: translateY(-2px);
        }

        .btn-secondary {
            background: #6c757d;
            color: white;
        }

        .btn-secondary:hover {
            background: #5a6268;
            transform: translateY(-2px);
        }

        .link-expediente {
            display: inline-block;
            color: #667eea;
            text-decoration: none;
            font-weight: 600;
            margin-top: 15px;
            padding: 8px 15px;
            border: 2px solid #667eea;
            border-radius: 5px;
            transition: all 0.3s;
        }

        .link-expediente:hover {
            background: #667eea;
            color: white;
        }

        @media (max-width: 768px) {
            .content {
                padding: 20px;
            }

            .consultation-metadata {
                flex-direction: column;
            }

            .button-group {
                flex-direction: column;
            }

            .btn {
                width: 100%;
            }

            .info-grid {
                grid-template-columns: 1fr;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <h1>Detalles de la Consulta</h1>
                <p>Información completa de la consulta médica</p>
            </div>

            <div class="content">
                <!-- Estado de la Consulta -->
                <asp:Panel ID="pnlEstado" runat="server" CssClass="status-banner">
                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                </asp:Panel>

                <!-- Información de la Consulta -->
                <div class="section">
                    <div class="section-title">Información de la Consulta</div>
                    <div class="consultation-metadata">
                        <div class="metadata-item">
                            <div class="metadata-label">ID Consulta</div>
                            <asp:Label ID="lblConsultaId" runat="server" CssClass="metadata-value"></asp:Label>
                        </div>
                        <div class="metadata-item">
                            <div class="metadata-label">Fecha de Creación</div>
                            <asp:Label ID="lblFechaCreacion" runat="server" CssClass="metadata-value"></asp:Label>
                        </div>
                        <div class="metadata-item">
                            <div class="metadata-label">Fecha de Respuesta</div>
                            <asp:Label ID="lblFechaRespuesta" runat="server" CssClass="metadata-value"></asp:Label>
                        </div>
                    </div>
                    
                    <div class="info-row">
                        <span class="info-label">Motivo de la Consulta</span>
                        <div class="info-value">
                            <asp:Label ID="lblMotivo" runat="server"></asp:Label>
                        </div>
                    </div>

                    <div class="info-row">
                        <span class="info-label">Descripción Detallada</span>
                        <div class="description-box">
                            <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>

                <!-- Información del Paciente -->
                <div class="section">
                    <div class="section-title">Información del Paciente</div>
                    <div class="info-grid">
                        <div class="info-row">
                            <span class="info-label">Nombre Completo</span>
                            <div class="info-value">
                                <asp:Label ID="lblNombrePaciente" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="info-row">
                            <span class="info-label">Cédula</span>
                            <div class="info-value">
                                <asp:Label ID="lblCedula" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="info-row">
                            <span class="info-label">Edad</span>
                            <div class="info-value">
                                <asp:Label ID="lblEdad" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="info-row">
                            <span class="info-label">Email</span>
                            <div class="info-value">
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="info-row">
                            <span class="info-label">Teléfono</span>
                            <div class="info-value">
                                <asp:Label ID="lblTelefono" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <asp:HyperLink ID="hlExpediente" runat="server" CssClass="link-expediente" Target="_blank">
                        Ver Expediente Médico Completo
                    </asp:HyperLink>
                </div>

                <!-- Respuesta Médica -->
                <div class="section">
                    <div class="section-title">Respuesta Médica</div>
                    
                    <asp:Panel ID="pnlMedico" runat="server" Visible="false">
                        <div class="info-row" style="margin-bottom: 15px;">
                            <span class="info-label">Médico Responsable</span>
                            <div class="info-value">
                                <asp:Label ID="lblMedico" runat="server"></asp:Label>
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="pnlRespuesta" runat="server" Visible="false">
                        <span class="info-label">Diagnóstico / Respuesta</span>
                        <div class="response-box">
                            <asp:Label ID="lblRespuesta" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="pnlSinRespuesta" runat="server" Visible="false">
                        <div class="no-response">
                            Esta consulta aún no ha sido respondida por un médico.
                        </div>
                    </asp:Panel>
                </div>

                <!-- Botones de Acción -->
                <div class="button-group">
                    <asp:Button 
                        ID="btnVolver" 
                        runat="server" 
                        Text="Volver" 
                        CssClass="btn btn-secondary"
                        OnClick="btnVolver_Click" />
                    <asp:Button 
                        ID="btnResponder" 
                        runat="server" 
                        Text="Responder Consulta" 
                        CssClass="btn btn-success"
                        Visible="false"
                        OnClick="btnResponder_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
