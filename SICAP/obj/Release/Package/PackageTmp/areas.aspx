<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="areas.aspx.cs" Inherits="SICAP.areas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido card-panel animated fadeIn">
        <h5 class="section">Areas</h5>        
        <div class="divider"></div>
        <div class="row">
            <div class="col s12 m6 card-panel">
                <asp:GridView ID="gvAreas" OnSelectedIndexChanged="gvAreas_SelectedIndexChanged" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField DataField="area" HeaderText="Area" />
                        <asp:ButtonField ButtonType="Link" CommandName="Select" Text="Eliminar"/>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col s12 m6">
                <div class="row">
                    <div class="input-field col s12">
                        <asp:Label Text="Nombre del area"  AssociatedControlID="txtArea" runat="server" />
                        <asp:TextBox runat="server" required ="required" ID="txtArea"/>
                    </div>                   
                </div>
                <div class="row">
                    <div class="col s12">
                        <asp:Button Text="Agregar area" ID="btnAgregar"  CssClass="btn right waves-effect waves-light white-text" runat="server" OnClick="btnAgregar_Click"  />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
