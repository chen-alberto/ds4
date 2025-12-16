<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Expedientes.aspx.cs" Inherits="SistemaConsultasMedicas.Expedientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Expedientes Médicos</title>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); min-height: 100vh; padding: 20px; }
        .container { max-width: 1200px; margin: 0 auto; background: white; padding: 40px; border-radius: 10px; box-shadow: 0 4px 6px rgba(0,0,0,0.1); }
        h1 { color: #667eea; margin-bottom: 30px; text-align: center; }
        .search-box { background: #f8f9fa; padding: 20px; border-radius: 8px; margin-bottom: 25px; }
        .search-box input { width: 100%; padding: 12px; border: 1px solid #ddd; border-radius: 5px; font-size: 14px; }
        table { width: 100%; border-collapse: collapse; margin-bottom: 20px; }
        thead { background: #667eea; color: white; }
        th { padding: 15px; text-align: left; font-weight: 600; }
        td { padding: 12px 15px; border-bottom: 1px solid #eee; }
        tbody tr:hover { background: #f8f9fa; }
        .btn { background: #667eea; color: white; padding: 8px 16px; border: none; border-radius: 5px; cursor: pointer; font-size: 14px; margin-right: 5px; text-decoration: none; display: inline-block; }
        .btn:hover { background: #5568d3; }
        .btn-sm { padding: 6px 12px; font-size: 13px; }
        .btn-secondary { background: #6c757d; }
        .btn-secondary:hover { background: #5a6268; }
        .button-group { margin-top: 20px; text-align: center; }
        .no-data { text-align: center; padding: 40px; color: #666; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>📁 Expedientes Médicos</h1>

            <div class="search-box">
                <asp:TextBox ID="txtBuscar" runat="server" placeholder="🔍 Buscar por nombre, apellido o cédula..." AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" />
            </div>

            <asp:Panel ID="pnlTabla" runat="server">
                <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="false" CssClass="table">
                    <HeaderStyle BackColor="#667eea" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Cedula" HeaderText="Cédula" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:TemplateField HeaderText="Edad">
                            <ItemTemplate>
                                <%# CalcularEdad(Eval("FechaNacimiento")) %> años
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                               <asp:HyperLink ID="hlVer" runat="server"
                                    NavigateUrl='<%# "VerExpediente.aspx?pacienteId=" + Eval("Id") %>'
                                    Text="👁 Ver" CssClass="btn btn-sm" />
                                <asp:HyperLink ID="hlEditar" runat="server"
                                    NavigateUrl='<%# "EditarExpediente.aspx?pacienteId=" + Eval("Id") %>'
                                    Text="✏️ Editar" CssClass="btn btn-sm" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>

            <asp:Panel ID="pnlNoData" runat="server" Visible="false" CssClass="no-data">
                <div style="font-size: 3em; margin-bottom: 15px;">📋</div>
                <h3>No se encontraron pacientes</h3>
                <p>No hay pacientes registrados en el sistema</p>
            </asp:Panel>

            <div class="button-group">
                <asp:Button ID="btnVolver" runat="server" Text="Volver al Inicio" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
            </div>
        </div>
    </form>
</body>
</html>