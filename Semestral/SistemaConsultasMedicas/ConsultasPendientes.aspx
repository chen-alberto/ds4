<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultasPendientes.aspx.cs" Inherits="SistemaConsultasMedicas.ConsultasPendientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Consultas Pendientes - Sistema de Consultas Médicas</title>
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
            max-width: 1200px;
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

        .toolbar {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 25px;
            gap: 15px;
            flex-wrap: wrap;
        }

        .search-box {
            display: flex;
            gap: 10px;
            flex: 1;
            min-width: 250px;
        }

        .search-input {
            flex: 1;
            padding: 10px 15px;
            border: 2px solid #e0e0e0;
            border-radius: 5px;
            font-size: 14px;
            transition: border-color 0.3s;
        }

        .search-input:focus {
            outline: none;
            border-color: #667eea;
        }

        .btn {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            font-size: 14px;
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
        }

        .btn-secondary {
            background: #6c757d;
            color: white;
        }

        .btn-secondary:hover {
            background: #5a6268;
        }

        .stats-container {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
            gap: 20px;
            margin-bottom: 30px;
        }

        .stat-card {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            padding: 20px;
            border-radius: 8px;
            text-align: center;
        }

        .stat-number {
            font-size: 36px;
            font-weight: bold;
            margin-bottom: 5px;
        }

        .stat-label {
            font-size: 14px;
            opacity: 0.9;
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

        .message.info {
            background-color: #d1ecf1;
            color: #0c5460;
            border: 1px solid #bee5eb;
        }

        .grid-container {
            background: #f8f9fa;
            border-radius: 8px;
            padding: 20px;
            overflow-x: auto;
        }

        .grid-view {
            width: 100%;
            border-collapse: collapse;
            background: white;
            border-radius: 8px;
            overflow: hidden;
        }

        .grid-view th {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            padding: 15px;
            text-align: left;
            font-weight: 600;
            font-size: 14px;
        }

        .grid-view td {
            padding: 15px;
            border-bottom: 1px solid #e0e0e0;
            font-size: 14px;
        }

        .grid-view tr:last-child td {
            border-bottom: none;
        }

        .grid-view tr:hover {
            background-color: #f8f9fa;
        }

        .badge {
            display: inline-block;
            padding: 5px 12px;
            border-radius: 20px;
            font-size: 12px;
            font-weight: 600;
        }

        .badge-pending {
            background: #fff3cd;
            color: #856404;
        }

        .badge-answered {
            background: #d4edda;
            color: #155724;
        }

        .action-buttons {
            display: flex;
            gap: 8px;
        }

        .btn-small {
            padding: 6px 12px;
            font-size: 12px;
        }

        .empty-state {
            text-align: center;
            padding: 60px 20px;
            color: #666;
        }

        .empty-state-icon {
            font-size: 64px;
            margin-bottom: 20px;
            opacity: 0.5;
        }

        .empty-state h3 {
            font-size: 20px;
            margin-bottom: 10px;
            color: #333;
        }

        @media (max-width: 768px) {
            .content {
                padding: 20px;
            }

            .toolbar {
                flex-direction: column;
                align-items: stretch;
            }

            .search-box {
                width: 100%;
            }

            .grid-container {
                padding: 10px;
            }

            .grid-view {
                font-size: 12px;
            }

            .grid-view th,
            .grid-view td {
                padding: 10px 8px;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <h1>Consultas Pendientes</h1>
                <p>Gestión de consultas médicas del sistema</p>
            </div>

            <div class="content">
                <asp:Panel ID="pnlMessage" runat="server" Visible="false" CssClass="message">
                </asp:Panel>

                <!-- Estadísticas -->
                <div class="stats-container">
                    <div class="stat-card">
                        <div class="stat-number">
                            <asp:Label ID="lblTotalConsultas" runat="server" Text="0"></asp:Label>
                        </div>
                        <div class="stat-label">Total de Consultas</div>
                    </div>
                    <div class="stat-card" style="background: linear-gradient(135deg, #f093fb 0%, #f5576c 100%);">
                        <div class="stat-number">
                            <asp:Label ID="lblPendientes" runat="server" Text="0"></asp:Label>
                        </div>
                        <div class="stat-label">Pendientes</div>
                    </div>
                    <div class="stat-card" style="background: linear-gradient(135deg, #4facfe 0%, #00f2fe 100%);">
                        <div class="stat-number">
                            <asp:Label ID="lblRespondidas" runat="server" Text="0"></asp:Label>
                        </div>
                        <div class="stat-label">Respondidas</div>
                    </div>
                </div>

                <!-- Barra de herramientas -->
                <div class="toolbar">
                    <div class="search-box">
                        <asp:TextBox 
                            ID="txtBuscar" 
                            runat="server" 
                            CssClass="search-input" 
                            placeholder="Buscar por paciente, cédula o motivo...">
                        </asp:TextBox>
                        <asp:Button 
                            ID="btnBuscar" 
                            runat="server" 
                            Text="Buscar" 
                            CssClass="btn btn-primary"
                            OnClick="btnBuscar_Click" />
                        <asp:Button 
                            ID="btnLimpiar" 
                            runat="server" 
                            Text="Limpiar" 
                            CssClass="btn btn-secondary"
                            OnClick="btnLimpiar_Click" />
                    </div>
                    <div>
                        <asp:Button 
                            ID="btnNuevaConsulta" 
                            runat="server" 
                            Text="+ Nueva Consulta" 
                            CssClass="btn btn-success"
                            OnClick="btnNuevaConsulta_Click" />
                    </div>
                </div>

                <!-- Grid de consultas -->
                <div class="grid-container">
                    <asp:GridView 
                        ID="gvConsultas" 
                        runat="server" 
                        CssClass="grid-view"
                        AutoGenerateColumns="False"
                        DataKeyNames="Id"
                        OnRowCommand="gvConsultas_RowCommand"
                        EmptyDataText="No hay consultas registradas en el sistema.">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-Width="60px" />
                            
                            <asp:TemplateField HeaderText="Fecha">
                                <ItemTemplate>
                                    <%# Convert.ToDateTime(Eval("FechaCreacion")).ToString("dd/MM/yyyy HH:mm") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Paciente">
                                <ItemTemplate>
                                    <strong><%# Eval("NombrePaciente") %></strong><br />
                                    <small style="color: #666;">Cédula: <%# Eval("Cedula") %></small>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Motivo" HeaderText="Motivo" ItemStyle-Width="200px" />

                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <span class='badge <%# Eval("Estado").ToString() == "Pendiente" ? "badge-pending" : "badge-answered" %>'>
                                        <%# Eval("Estado") %>
                                    </span>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Médico">
                                <ItemTemplate>
                                    <%# Eval("NombreMedico") != DBNull.Value ? "Dr. " + Eval("NombreMedico") : "<span style='color: #999;'>Sin asignar</span>" %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="180px">
                                <ItemTemplate>
                                    <div class="action-buttons">
                                        <asp:Button 
                                            runat="server" 
                                            Text="Ver" 
                                            CommandName="Ver"
                                            CommandArgument='<%# Eval("Id") %>'
                                            CssClass="btn btn-primary btn-small" />
                                        <asp:Button 
                                            runat="server" 
                                            Text="Responder" 
                                            CommandName="Responder"
                                            CommandArgument='<%# Eval("Id") %>'
                                            CssClass="btn btn-success btn-small"
                                            Visible='<%# Eval("Estado").ToString() == "Pendiente" %>' />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div class="empty-state">
                                <div class="empty-state-icon">📋</div>
                                <h3>No hay consultas disponibles</h3>
                                <p>Comienza creando una nueva consulta médica</p>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>