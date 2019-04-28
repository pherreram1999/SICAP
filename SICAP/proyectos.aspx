<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="proyectos.aspx.cs" Inherits="SICAP.proyectos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido card-panel animated fadeIn">

        <div class="row">
            <div class="col s12">
                <h4 class="section">Proyectos</h4>
                <div class="divider"></div>
            </div>
        </div>

        <div class="row">
            <div class="col s12">
                <asp:GridView ID="gvProyectos" DataKeyNames="id_proyecto" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField DataField="id_proyecto" HeaderText="ID" />
                        <asp:BoundField DataField="proyecto" HeaderText="Nombre del Proyecto" />
                        <asp:BoundField DataField="fecha_registro" HeaderText="Fecha de Crecion" />
                        <asp:BoundField DataField="fecha_inicio" HeaderText ="Incio" />
                        <asp:BoundField DataField="fecha_final" HeaderText="Termino" />
                        <asp:BoundField DataField="estatus" HeaderText="Estatus" />
                        <asp:HyperLinkField DataNavigateUrlFields="id_proyecto"  DataNavigateUrlFormatString="perfilProyecto.aspx?id_proyecto={0}" Text="ver datos" />
                        
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        
    </div>
</asp:Content>
