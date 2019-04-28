<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="avances.aspx.cs" Inherits="SICAP.avances" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido card-panel animated fadeIn">
        
        <h6>Avances del proyecto</h6>
        <h4><asp:Label ID="lblNombreProyecto" Text="Nombre del proyecto aqui" runat="server"></asp:Label></h4>
        <div class="divider"></div>

        <div class="row">
            <div class="col s12">
                <asp:GridView runat="server" ID="gvAvances" AutoGenerateColumns="false" CssClass="responsive-table">
                  <Columns>
                      <asp:BoundField DataField="ID" HeaderText="ID" />
                      <asp:BoundField DataField="avance" HeaderText="Avance" />
                      <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                      <asp:BoundField DataField="actividad" HeaderText="Actividad" />
                      <asp:BoundField DataField="fecha_registro" HeaderText="Fecha De Registro" />
                      <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                      <asp:HyperLinkField Text="Ver Avance"  DataNavigateUrlFields="ID"  DataNavigateUrlFormatString="perfilAvance.aspx?ID={0}" />
                  </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>
    
    <div class="fixed-action-btn">
      <asp:HyperLink CssClass="btn-floating btn-large tooltipped" NavigateUrl="#" ID="hlAgregarAvance" runat="server" data-position="left" data-tooltip="Agregar Avance">
        <i class="large material-icons">add</i>
      </asp:HyperLink>
    </div>
   
</asp:Content>
