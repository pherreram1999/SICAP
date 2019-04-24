<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="avance.aspx.cs" Inherits="SICAP.avance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contenido animated fadeIn card-panel">
        <h5 class="section">Registrar nuevo avance</h5>
        <div class="divider"></div>
        <div class="row">
            <div class="input-field col s12">
                <asp:Label Text="Nombre del avance" AssociatedControlID="txtNombreAvance" runat="server" />
                <asp:TextBox runat="server" ID="txtNombreAvance" />  
            </div>
        </div>
        <div class="row">
            <div class="input-field col s12 m3">
                <asp:Label Text="Fecha de Registro" Enabled="false" runat="server" />
                <asp:TextBox runat="server" TextMode="Date" ID="txtFecha"/>  
            </div>
        </div>
        <div class="row">
            <div class="input-field col s12">
                <asp:Label Text="Observaciones" AssociatedControlID="txtObservaciones" runat="server" />
                <asp:TextBox runat="server" ID="txtObservaciones" />  
            </div>
        </div>

    </div>
</asp:Content>
