<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResponderConsulta.aspx.cs" Inherits="SistemaConsultasMedicas.ResponderConsulta" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Responder Consulta - Sistema de Consultas Médicas</title>
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

        .message {
            padding: 15px;
            border-radius: 5px;
            margin-bottom: 20px;
            font-weight: 500;
        }

        .message.success {
            background-color: #d4edda;
            color: #155724;
            border: 1px solid #c3e6cb;
        }

        .message.error {
            background-color: #f8d7da;
            color: #721c24;
            border: 1px solid #f5c6cb;
        }

        .section {
            background: #f8f9fa;
            border-radius: 8px;
            padding: 20px;
            margin-bottom: 25px;
            border-left: 4px solid #667eea;
        }

        .section-title {
            font-size: 18px;
            color: #667eea;
            margin-bottom: 15px;
            font-weight: 600;
            display: flex;
            align-items: center;
        }

        .section-title::before {
            content: "●";
            margin-right: 10px;
            font-size: 20px;
        }

        .info-grid {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
            gap: 15px;
        }

        .info-row {
            padding: 10px 0;
            border-bottom: 1px solid #e0e0e0;
        }

        .info-row:last-child {
            border-bottom: none;
        }

        .info-row strong {
            color: #333;
            display: inline-block;
            min-width: 100px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-group label {
            display: block;
            margin-bottom: 8px;
            color: #333;
            font-weight: 600;
            font-size: 14px;
        }

        .form-group .required::after {
            content: " *";
            color: #dc3545;
        }

        .form-control {
            width: 100%;
            padding: 12px;
            border: 2px solid #e0e0e0;
            border-radius: 5px;
            font-size: 14px;
            font-family: inherit;
            transition: border-color 0.3s;
        }

        .form-control:focus {
            outline: none;
            border-color: #667eea;
        }

        textarea.form-control {
            min-height: 150px;
            resize: vertical;
        }

        .validator {
            color: #dc3545;
            font-size: 13px;
            margin-top: 5px;
            display: block;
        }

        .button-group {
            display: flex;
            gap: 15px;
            justify-content: flex-end;
            margin-top: 30px;
            padding-top: 20px;
            border-top: 2px solid #e0e0e0;
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
            margin-top: 10px;
            padding: 8px 15px;
            border: 2px solid #667eea;
            border-radius: 5px;
            transition: all 0.3s;
        }

        .link-expediente:hover {
            background: #667eea;
            color: white;
        }

        .consultation-metadata {
            display: flex;
            gap: 20px;
            margin-bottom: 15px;
            padding: 10px;
            background: white;
            border-radius: 5px;
        }

        .metadata-item {
            display: flex;
            flex-direction: column;
        }

        .metadata-label {
            font-size: 12px;
            color: #666;
            margin-bottom: 3px;
        }

        .metadata-value {
            font-weight: 600;
            color: #333;
        }

        @media (max-width: 768px) {
            .content {
                padding: 20px;
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
                <h1>📋 Responder Consulta Médica</h1>
                <p>Complete la información para responder la consulta del paciente</p>
            </div>

            <div class="content">
                <asp:Panel ID="pnlMessage" runat="server" Visible="false" CssClass="message">
                </asp:Panel>

                <!-- Información de la Consulta -->
                <div class="section">
                    <div class="section-title">Información de la Consulta</div>
                    <div class="consultation-metadata">
                        <div class="metadata-item">
                            <span class="metadata-label">ID Consulta</span>
                            <asp:Label ID="lblConsultaId" runat="server" CssClass="metadata-value"></asp:Label>
                        </div>
                        <div class="metadata-item">
                            <span class="metadata-label">Fecha de Creación</span>
                            <asp:Label ID="lblFecha" runat="server" CssClass="metadata-value"></asp:Label>
                        </div>
                    </div>
                    <div class="info-row">
                        <strong>Motivo:</strong>
                        <asp:Label ID="lblMotivo" runat="server"></asp:Label>
                    </div>
                    <div class="info-row">
                        <strong>Descripción:</strong>
                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                    </div>
                </div>

                <!-- Información del Paciente -->
                <div class="section">
                    <div class="section-title">Información del Paciente</div>
                    <asp:Label ID="lblPacienteInfo" runat="server"></asp:Label>
                    <asp:HyperLink ID="hlExpediente" runat="server" CssClass="link-expediente" Target="_blank">
                        📄 Ver Expediente Completo
                    </asp:HyperLink>
                </div>

                <!-- Formulario de Respuesta -->
                <div class="section">
                    <div class="section-title">Respuesta Médica</div>
                    
                    <div class="form-group">
                        <label class="required">Médico Responsable</label>
                        <asp:DropDownList ID="ddlMedico" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator 
                            ID="rfvMedico" 
                            runat="server" 
                            ControlToValidate="ddlMedico"
                            ErrorMessage="Por favor seleccione un médico"
                            CssClass="validator"
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <label class="required">Respuesta / Diagnóstico</label>
                        <asp:TextBox 
                            ID="txtRespuesta" 
                            runat="server" 
                            TextMode="MultiLine" 
                            CssClass="form-control"
                            placeholder="Ingrese la respuesta médica, diagnóstico, recomendaciones y/o tratamiento sugerido...">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator 
                            ID="rfvRespuesta" 
                            runat="server" 
                            ControlToValidate="txtRespuesta"
                            ErrorMessage="La respuesta es obligatoria"
                            CssClass="validator"
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <!-- Botones de Acción -->
                <div class="button-group">
                    <asp:Button 
                        ID="btnVolver" 
                        runat="server" 
                        Text="Volver" 
                        CssClass="btn btn-secondary"
                        CausesValidation="false"
                        OnClick="btnVolver_Click" />
                    <asp:Button 
                        ID="btnEnviarRespuesta" 
                        runat="server" 
                        Text="Enviar Respuesta" 
                        CssClass="btn btn-primary"
                        OnClick="btnEnviarRespuesta_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>