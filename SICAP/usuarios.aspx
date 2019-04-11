<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="SICAP.usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido card-panel animated fadeIn">
        <asp:GridView ID="gvUsurios" CssClass="responsive-table" runat="server"
         DataKeyNames="id_usuario"  AutoGenerateColumns="false" >
        <Columns>
            <asp:BoundField DataField="id_usuario" HeaderText="ID" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="paterno" HeaderText="Apellido Paterno" />
            <asp:BoundField DataField="materno" HeaderText="Apellido Materno" />
            <asp:BoundField DataField="area" HeaderText="Área" />
            <asp:HyperLinkField />
        </Columns>
    </asp:GridView>
    </div>
</asp:Content>
