<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="perfilProyecto.aspx.cs" Inherits="SICAP.perfilProyecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido card-panel animated fadeIn">
        <h5 class="section">Datos del proyecto</h5>
        <div class="divider"></div>
        
        <div class="row">
            <div class="input-field col s12 m4 ">
                <asp:Label Text="Estatus del Proyecto" runat="server" />
                <asp:DropDownList ID="dllEstatus" runat="server" Enabled="False"></asp:DropDownList>                
            </div>
            <div class="col s12 m4">                
                <div class="section"></div>
                <asp:LinkButton ID="btnEstatus" Text="Modificar estatus" CssClass="btn" runat="server" OnClick="btnEstatus_Click" />
            </div>            
        </div>
        <div class="row">
            <div class="col s12">
                <h5><asp:Label ID="lblNombreProyecto" runat="server" Text=""></asp:Label></h5>
            </div>
        </div>
        <div class="row">
            <div class="input-field col s12 m3">
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio"></asp:Label>
                <asp:TextBox ID="txtFechaInicio" Enabled="false" TextMode="Date" runat="server"></asp:TextBox>
            </div>
            <div class="input-field col s12 m3">
                <asp:Label ID="lblFechaFinal" runat="server" Text="Fecha Final"></asp:Label>
                <asp:TextBox ID="txtFechaFinal" Enabled="false" runat="server" TextMode="Date"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col s12">
                <h5 class="section">Observaciones</h5>
                <p>
                    <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones"></asp:Label>
                </p>
            </div>
        </div>

        <div class="row">   
            <div class="col s12 m5">
                <asp:ListBox ID="lbxUsuarios" CssClass="browser-default fixSelect z-depth-2" runat="server"></asp:ListBox>
            </div>
            <div class="col s12 m2"></div>
            <div class="col s12 m5">
                <asp:ListBox ID="lbxActividades" CssClass="browser-default fixSelect z-depth-2" runat="server"></asp:ListBox>
            </div>
        </div>

    </div>
</asp:Content>
