<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarPaciente.aspx.cs" Inherits="SistemaConsultasMedicas.RegistrarPaciente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Registrar Paciente - Sistema de Consultas Médicas</title>
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
            content: "👤";
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

        .help-text {
            font-size: 12px;
            color: #666;
            margin-top: 5px;
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
                <h1>Registrar Nuevo Paciente</h1>
                <p>Complete el formulario con la información del paciente</p>
            </div>

            <div class="content">
                <asp:Panel ID="pnlMessage" runat="server" Visible="false" CssClass="message">
                </asp:Panel>

                <div class="info-box">
                    <strong>Información:</strong> Los campos marcados con asterisco (*) son obligatorios. Asegúrese de completar toda la información correctamente.
                </div>

                <!-- Datos Personales -->
                <div class="section">
                    <div class="section-title">Datos Personales</div>
                    
                    <div class="form-row">
                        <div class="form-group">
                            <label class="required">Nombre</label>
                            <asp:TextBox 
                                ID="txtNombre" 
                                runat="server" 
                                CssClass="form-control"
                                placeholder="Juan">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator 
                                ID="rfvNombre" 
                                runat="server" 
                                ControlToValidate="txtNombre"
                                ErrorMessage="El nombre es obligatorio"
                                CssClass="validator"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label class="required">Apellido</label>
                            <asp:TextBox 
                                ID="txtApellido" 
                                runat="server" 
                                CssClass="form-control"
                                placeholder="Pérez">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator 
                                ID="rfvApellido" 
                                runat="server" 
                                ControlToValidate="txtApellido"
                                ErrorMessage="El apellido es obligatorio"
                                CssClass="validator"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group">
                            <label class="required">Cédula</label>
                            <asp:TextBox 
                                ID="txtCedula" 
                                runat="server" 
                                CssClass="form-control"
                                placeholder="8-123-4567">
                            </asp:TextBox>
                            <div class="help-text">Formato: 8-123-4567</div>
                            <asp:RequiredFieldValidator 
                                ID="rfvCedula" 
                                runat="server" 
                                ControlToValidate="txtCedula"
                                ErrorMessage="La cédula es obligatoria"
                                CssClass="validator"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator
                                ID="revCedula"
                                runat="server"
                                ControlToValidate="txtCedula"
                                ValidationExpression="^\d{1,2}-\d{1,4}-\d{1,5}$"
                                ErrorMessage="Formato de cédula inválido (ej: 8-123-4567)"
                                CssClass="validator"
                                Display="Dynamic">
                            </asp:RegularExpressionValidator>
                        </div>

                        <div class="form-group">
                            <label class="required">Fecha de Nacimiento</label>
                            <asp:TextBox 
                                ID="txtFechaNacimiento" 
                                runat="server" 
                                TextMode="Date"
                                CssClass="form-control">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator 
                                ID="rfvFechaNacimiento" 
                                runat="server" 
                                ControlToValidate="txtFechaNacimiento"
                                ErrorMessage="La fecha de nacimiento es obligatoria"
                                CssClass="validator"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group">
                            <label class="required">Sexo</label>
                            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control">
                                <asp:ListItem Text="-- Seleccione --" Value=""></asp:ListItem>
                                <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                                <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator 
                                ID="rfvSexo" 
                                runat="server" 
                                ControlToValidate="ddlSexo"
                                ErrorMessage="Seleccione el sexo"
                                CssClass="validator"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label>Teléfono</label>
                            <asp:TextBox 
                                ID="txtTelefono" 
                                runat="server" 
                                CssClass="form-control"
                                placeholder="6123-4567">
                            </asp:TextBox>
                            <div class="help-text">Opcional</div>
                        </div>
                    </div>
                </div>

                <!-- Datos de Contacto -->
                <div class="section">
                    <div class="section-title">Datos de Contacto</div>
                    
                    <div class="form-group">
                        <label class="required">Email</label>
                        <asp:TextBox 
                            ID="txtEmail" 
                            runat="server" 
                            TextMode="Email"
                            CssClass="form-control"
                            placeholder="juan.perez@email.com">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator 
                            ID="rfvEmail" 
                            runat="server" 
                            ControlToValidate="txtEmail"
                            ErrorMessage="El email es obligatorio"
                            CssClass="validator"
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            ID="revEmail"
                            runat="server"
                            ControlToValidate="txtEmail"
                            ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"
                            ErrorMessage="Ingrese un email válido"
                            CssClass="validator"
                            Display="Dynamic">
                        </asp:RegularExpressionValidator>
                    </div>

                    <div class="form-group">
                        <label>Dirección</label>
                        <asp:TextBox 
                            ID="txtDireccion" 
                            runat="server" 
                            TextMode="MultiLine"
                            CssClass="form-control"
                            placeholder="Calle, ciudad, provincia"
                            Rows="3">
                        </asp:TextBox>
                        <div class="help-text">Opcional</div>
                    </div>
                </div>

                <!-- Información Adicional -->
                <div class="section">
                    <div class="section-title">Información Adicional</div>
                    
                    <asp:CheckBox 
                        ID="chkCrearExpediente" 
                        runat="server" 
                        Text="Crear expediente médico después del registro"
                        Checked="true"
                        style="margin-bottom: 10px;" />
                    <div class="help-text" style="margin-left: 25px;">
                        Si marca esta opción, será redirigido para completar el expediente médico del paciente.
                    </div>
                </div>

                <!-- Botones de Acción -->
                <div class="button-group">
                    <asp:Button 
                        ID="btnCancelar" 
                        runat="server" 
                        Text="Cancelar" 
                        CssClass="btn btn-secondary"
                        CausesValidation="false"
                        OnClick="btnCancelar_Click" />
                    <asp:Button 
                        ID="btnGuardar" 
                        runat="server" 
                        Text="Registrar Paciente" 
                        CssClass="btn btn-primary"
                        OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>