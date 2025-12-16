<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarExpediente.aspx.cs" Inherits="SistemaConsultasMedicas.EditarExpediente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Editar Expediente Médico - Sistema de Consultas Médicas</title>
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
            max-width: 900px;
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

        .patient-banner {
            background: #f8f9fa;
            padding: 20px;
            border-bottom: 3px solid #667eea;
            text-align: center;
            font-size: 18px;
            font-weight: 600;
            color: #333;
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

        .form-row {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
            gap: 20px;
            margin-bottom: 20px;
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
            min-height: 100px;
            resize: vertical;
        }

        select.form-control {
            cursor: pointer;
        }

        .validator {
            color: #dc3545;
            font-size: 13px;
            margin-top: 5px;
            display: block;
        }

        .info-box {
            background: #e7f3ff;
            border-left: 4px solid #2196F3;
            padding: 15px;
            border-radius: 5px;
            margin-bottom: 20px;
        }

        .info-box strong {
            color: #1976D2;
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

        .input-group {
            display: flex;
            align-items: center;
            gap: 5px;
        }

        .input-addon {
            color: #666;
            font-size: 14px;
            font-weight: 600;
        }

        @media (max-width: 768px) {
            .content {
                padding: 20px;
            }

            .form-row {
                grid-template-columns: 1fr;
            }

            .button-group {
                flex-direction: column;
            }

            .btn {
                width: 100%;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <h1>🏥 Expediente Médico</h1>
                <p>Gestión de información clínica del paciente</p>
            </div>

            <div class="patient-banner">
                <asp:Label ID="lblPaciente" runat="server"></asp:Label>
            </div>

            <div class="content">
                <asp:Panel ID="pnlMessage" runat="server" Visible="false" CssClass="message">
                </asp:Panel>

                <div class="info-box">
                    <strong>Información Importante:</strong> Complete todos los campos requeridos con la información médica más actualizada del paciente. Esta información es crucial para brindar una atención médica adecuada.
                </div>

                <!-- Datos Físicos -->
                <div class="section">
                    <div class="section-title">Datos Físicos</div>
                    <div class="form-row">
                        <div class="form-group">
                            <label class="required">Peso</label>
                            <div class="input-group">
                                <asp:TextBox 
                                    ID="txtPeso" 
                                    runat="server" 
                                    CssClass="form-control"
                                    placeholder="70.5"
                                    style="flex: 1;">
                                </asp:TextBox>
                                <span class="input-addon">kg</span>
                            </div>
                            <asp:RequiredFieldValidator 
                                ID="rfvPeso" 
                                runat="server" 
                                ControlToValidate="txtPeso"
                                ErrorMessage="El peso es obligatorio"
                                CssClass="validator"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator
                                ID="revPeso"
                                runat="server"
                                ControlToValidate="txtPeso"
                                ValidationExpression="^\d+(\.\d{1,2})?$"
                                ErrorMessage="Ingrese un peso válido (ej: 70.5)"
                                CssClass="validator"
                                Display="Dynamic">
                            </asp:RegularExpressionValidator>
                        </div>

                        <div class="form-group">
                            <label class="required">Altura</label>
                            <div class="input-group">
                                <asp:TextBox 
                                    ID="txtAltura" 
                                    runat="server" 
                                    CssClass="form-control"
                                    placeholder="1.75"
                                    style="flex: 1;">
                                </asp:TextBox>
                                <span class="input-addon">m</span>
                            </div>
                            <asp:RequiredFieldValidator 
                                ID="rfvAltura" 
                                runat="server" 
                                ControlToValidate="txtAltura"
                                ErrorMessage="La altura es obligatoria"
                                CssClass="validator"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator
                                ID="revAltura"
                                runat="server"
                                ControlToValidate="txtAltura"
                                ValidationExpression="^\d+(\.\d{1,2})?$"
                                ErrorMessage="Ingrese una altura válida (ej: 1.75)"
                                CssClass="validator"
                                Display="Dynamic">
                            </asp:RegularExpressionValidator>
                        </div>

                        <div class="form-group">
                            <label class="required">Tipo de Sangre</label>
                            <asp:DropDownList ID="ddlTipoSangre" runat="server" CssClass="form-control">
                                <asp:ListItem Text="-- Seleccione --" Value=""></asp:ListItem>
                                <asp:ListItem Text="A+" Value="A+"></asp:ListItem>
                                <asp:ListItem Text="A-" Value="A-"></asp:ListItem>
                                <asp:ListItem Text="B+" Value="B+"></asp:ListItem>
                                <asp:ListItem Text="B-" Value="B-"></asp:ListItem>
                                <asp:ListItem Text="AB+" Value="AB+"></asp:ListItem>
                                <asp:ListItem Text="AB-" Value="AB-"></asp:ListItem>
                                <asp:ListItem Text="O+" Value="O+"></asp:ListItem>
                                <asp:ListItem Text="O-" Value="O-"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator 
                                ID="rfvTipoSangre" 
                                runat="server" 
                                ControlToValidate="ddlTipoSangre"
                                ErrorMessage="Seleccione el tipo de sangre"
                                CssClass="validator"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <!-- Historial Médico -->
                <div class="section">
                    <div class="section-title">Historial Médico</div>
                    
                    <div class="form-group">
                        <label>Alergias</label>
                        <asp:TextBox 
                            ID="txtAlergias" 
                            runat="server" 
                            TextMode="MultiLine" 
                            CssClass="form-control"
                            placeholder="Describa cualquier alergia conocida (medicamentos, alimentos, etc.)">
                        </asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Enfermedades Crónicas</label>
                        <asp:TextBox 
                            ID="txtEnfermedadesCronicas" 
                            runat="server" 
                            TextMode="MultiLine" 
                            CssClass="form-control"
                            placeholder="Diabetes, hipertensión, asma, etc.">
                        </asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Medicamentos Actuales</label>
                        <asp:TextBox 
                            ID="txtMedicamentos" 
                            runat="server" 
                            TextMode="MultiLine" 
                            CssClass="form-control"
                            placeholder="Liste los medicamentos que toma regularmente con su dosis">
                        </asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Cirugías Previas</label>
                        <asp:TextBox 
                            ID="txtCirugiasPrevias" 
                            runat="server" 
                            TextMode="MultiLine" 
                            CssClass="form-control"
                            placeholder="Describa cirugías o procedimientos quirúrgicos previos">
                        </asp:TextBox>
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
                        ID="btnGuardar" 
                        runat="server" 
                        Text="💾 Guardar Expediente" 
                        CssClass="btn btn-primary"
                        OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
