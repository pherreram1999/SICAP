<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="perfilAvance.aspx.cs" Inherits="SICAP.perfilAvance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido animated fadeIn card-panel ">
        <div class="row">
            <div class="col s12">   
                <label>Nombre del Avance</label>
                <h5 class="section"><asp:Label Text="" ID="lbAvance" runat="server" /></h5>
                <div class="divider"></div>
            </div>
        </div>
        <div class="row">
            <div class="col s12 m4">   
                <label>Fecha de registro</label>
                <h6><asp:Label Text="" ID="lblFechaRegistro" runat="server" /></h6>
            </div>
            <div class="col s12  m4">   
                <label>Propietario</label>
                <p><asp:Label Text="" ID="lblPropietario" runat="server" /></p>
            </div>
        </div>
        <div class="row">
            <div class="col s12">   
                <label>Observaciones</label>
                <p><asp:Label Text="" ID="lbObservaciones" runat="server" /></p>
            </div>
        </div>
        <div class="row">
            <div class="col s12">
                <h6><asp:Label Text="No se adjunto ningún archivo" ID ="lblArchivo" runat="server" /></h6>
                <asp:HyperLink Text="Descargar Archivo" ID="hlDescargar" download  CssClass="btn" runat="server" />
                
            </div>
            
        </div>

    </div>



</asp:Content>
