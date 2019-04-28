<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="misProyectos.aspx.cs" Inherits="SICAP.misProyectos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido card-panel animated fadeIn">
        <h5 class="section">Mis proyectos</h5>
        <div class="divider"></div>
        <div class="row">
            <div class="col s12">
                <asp:GridView ID="gvMisProyectos" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField DataField="id_proyecto" HeaderText ="ID" />
                        <asp:BoundField DataField="proyecto" HeaderText="Proyecto" />
                        <asp:BoundField DataField ="fecha_registro" HeaderText="Registro" />
                        <asp:BoundField DataField ="fecha_inicio" HeaderText="Inicio" />
                        <asp:BoundField DataField ="fecha_final" HeaderText="Termino" />
                        <asp:HyperLinkField DataNavigateUrlFields="id_proyecto"  DataNavigateUrlFormatString="perfilProyecto.aspx?id_proyecto={0}" Text="ver datos" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
