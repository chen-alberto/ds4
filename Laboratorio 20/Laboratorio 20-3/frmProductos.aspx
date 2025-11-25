<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmProductos.aspx.cs" Inherits="frmProductos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Laptops</h2>
        <label>ID:</label>
        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
        <br /><br />
        <label>Nombre:</label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br /><br />
        <label>Precio:</label>
        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
        <br /><br />
        <label>Stock:</label>
        <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        <br /><br />
        Buscar por ID:<br />
        <asp:TextBox ID="txtBuscarId" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
</asp:Content>