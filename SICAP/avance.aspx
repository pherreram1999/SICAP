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
                <asp:TextBox required ="required" runat="server" ID="txtNombreAvance" />  
            </div>
        </div>
        <div class="row">
            <div class="input-field col s12 m3">
                <asp:Label Text="Fecha de Registro"  runat="server" />
                <asp:TextBox runat="server" Enabled="false" TextMode="Date" ID="txtFecha"/>  
            </div>
            <div class="input-field col s12 m4">
                <asp:Label Text="Activdad" runat="server" />
                <asp:DropDownList ID="dllActividades" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="input-field col s12">
                <asp:Label Text="Observaciones" AssociatedControlID="txtObservaciones" runat="server" />
                <asp:TextBox required="required" runat="server" ID="txtObservaciones" />  
            </div>
        </div>
        <h5 class="section">Cargar Archivos</h5>
        <div class="row">
            <div class="file-field input-field col s12 valign-wrapper">
                <div class="btn">
                    <span>Seleccionar archivo</span>
                    <asp:FileUpload ID="fuArchivos" runat="server" />
                </div>
                <div class="file-path-wrapper">
                    <input class="file-path validate" type="text" placeholder="adjuntar">
                </div>
            </div>
            
        </div>
        <div class="row">
            <div class="col s12">   
                <p class="red-text">* Nota: no se pueden subir archvivos mayores 4MB</p>
                <p>*Si va a enviar varios archivos, favor de comprimirlos</p>
                
            </div>
        </div>

        <div class="row">
            <div class="col s12">
                <asp:Button Text="Guardar Avance" CssClass="btn right" ID="btnGuardar" OnClick="btnGuardar_Click" runat="server" />
            </div>
        </div>

    </div>


   

</asp:Content>
