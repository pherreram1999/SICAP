<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="proyecto.aspx.cs" Inherits="SICAP.proyecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido card-panel animated fadeIn">
        <h3 class="section">Crear un nuevo proyecto</h3>
        <div class="divider"></div>
        <div class="section"></div>
        <div class="row">
            <div class="input-field col s12">
                <asp:Label Text="Nombre del proyecto" AssociatedControlID="txtNombre" runat="server" />
                <asp:TextBox runat="server" ID="txtNombre" />
            </div>
        </div>

    </div>
</asp:Content>
