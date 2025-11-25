<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 50px;
            background-color: #f5f5f5;
        }
        .container {
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 0 15px rgba(0,0,0,0.1);
            max-width: 800px;
            margin: 0 auto;
        }
        h2 {
            color: #333;
            text-align: center;
        }
        .input-section {
            margin: 20px 0;
            text-align: center;
        }
        label {
            font-weight: bold;
            margin-right: 10px;
        }
        input[type="text"] {
            padding: 8px;
            font-size: 16px;
            border: 1px solid #ddd;
            border-radius: 5px;
            width: 100px;
            text-align: center;
        }
        .btn {
            background-color: #28a745;
            color: white;
            padding: 10px 30px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            margin: 10px;
        }
        .btn:hover {
            background-color: #218838;
        }
        .matriz-container {
            margin-top: 30px;
            overflow-x: auto;
        }
        table {
            border-collapse: collapse;
            margin: 0 auto;
            background-color: white;
        }
        td, th {
            border: 2px solid #007bff;
            padding: 15px;
            text-align: center;
            font-size: 16px;
            min-width: 60px;
        }
        th {
            background-color: #007bff;
            color: white;
            font-weight: bold;
        }
        td {
            background-color: #f8f9fa;
        }
        .diagonal {
            background-color: #ffc107 !important;
            font-weight: bold;
            color: #000;
        }
        .numero-uno {
            background-color: #28a745 !important;
            color: white;
            font-weight: bold;
        }
        .numero-cero {
            background-color: #dc3545 !important;
            color: white;
            font-weight: bold;
        }
    </style>
    
    <div class="container">
        <h2>Generador de Matriz N x N</h2>
        
        <div class="input-section">
            <label>Tamaño de la Matriz (N):</label>
            <asp:TextBox ID="txtDimension" runat="server" TextMode="Number" Text="5"></asp:TextBox>
            <br /><br />
            <asp:Button ID="btnGenerar" runat="server" Text="Generar Matriz" 
                        CssClass="btn" OnClick="btnGenerar_Click" />
        </div>
        
        <div class="matriz-container">
            <asp:Literal ID="litMatriz" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>