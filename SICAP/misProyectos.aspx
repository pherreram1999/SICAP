<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="misProyectos.aspx.cs" Inherits="SICAP.misProyectos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido card-panel animated fadeIn">
        <h5 class="section">Mis proyectos</h5>
        <div class="divider"></div>
        <div class="row">
            <div class="col s12">
                <asp:GridView ID="gvMisProyectos" AutoGenerateColumns="true" runat="server"></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
