<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="SICAP.usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido card-panel animated fadeIn">

        <h5 class="section">Usuarios</h5>
        <div class="divider"></div>

        <div class="row">            
            <div class="col s12 m1">
                <br />
                <p>Buscar usuario</p>
            </div>
            <div class="col s12 m6 input-field">
                <asp:Label Text="Nombre del proyecto" AssociatedControlID="txtBusqueda" runat="server" />
                <asp:TextBox ID="txtBusqueda" runat="server" />                
            </div>
            
            <div class="col s12 m3">
                <br />            
                <asp:LinkButton CssClass="btn-flat cyan left white-text" ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" ><i class="material-icons center">search</i></asp:LinkButton>
                <asp:LinkButton Text="Cancelar busqueda" Visible ="false" ID="btnCancelarBusqueda" OnClick="btnCancelarBusqueda_Click" runat="server" />
            </div>

        </div>

        <asp:GridView ID="gvUsurios" CssClass="responsive-table" runat="server"
         DataKeyNames="id_usuario"  AutoGenerateColumns="false" >
        <Columns>
            <asp:BoundField DataField="id_usuario" HeaderText="ID" />
            <asp:ImageField DataImageUrlField="ruta" HeaderText="Img" ControlStyle-Width="80px" ControlStyle-CssClass="responsive-img circle" ></asp:ImageField>
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="paterno" HeaderText="Apellido Paterno" />
            <asp:BoundField DataField="materno" HeaderText="Apellido Materno" />
            <asp:BoundField DataField="area" HeaderText="Área" />
            <asp:HyperLinkField DataNavigateUrlFields="id_usuario" DataNavigateUrlFormatString="usuario.aspx?id_usuario={0}" Text="Ver perfil" />
        </Columns>
    </asp:GridView>
    </div>
</asp:Content>
