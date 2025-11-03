<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio_17._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="row">
        <asp:GridView ID="MyGridView" DataSourceID="MyDataSource1"
            AllowSorting="true" AllowPaging="true"
            DataKeyNames="ProductID"
            AutoGenerateEditButton="true"
        Runat="server" />

        <asp:SqlDataSource ID="MyDataSource1" runat="server"
            ConnectionString="data source=.\SQLEXPRESS;initial catalog=northwind;persist security info=True;Integrated Security=SSPI;"
            pRoviderName="System.Data.SqlClient"
            SelectCommand="SELECT ProductID, ProductName, UnitPrice FROM Products"
            UpdateCommand="UPDATE Products SET [ProductName]= @ProductName, [UnitPrice]= @UnitPrice WHERE [ProductID]= @ProductID">
        </asp:SqlDataSource>
            
        </div>
    </main>

</asp:Content>
