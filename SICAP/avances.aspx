<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="avances.aspx.cs" Inherits="SICAP.avances" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido card-panel animated fadeIn">
        
        <h6>Avances del proyecto</h6>
        <h4><asp:Label ID="lblNombreProyecto" Text="Nombre del proyecto aqui" runat="server"></asp:Label></h4>
        <div class="divider"></div>

        
        <asp:HyperLink NavigateUrl="avance.aspx" runat="server" ><i class="material-icons left">add</i>Nuevo avance</asp:HyperLink>
    </div>
    <script type="text/javascript">
        var today = new Date();
        var dd = String(today.getDate()).padStart(2, '0');
        var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
        var yyyy = today.getFullYear();

        today = yyyy + '-' + mm + '-' + dd;
        var fecha = document.getElementById("ContentPlaceHolder1_txtFecha");
        fecha.value = today;
    </script>
</asp:Content>
