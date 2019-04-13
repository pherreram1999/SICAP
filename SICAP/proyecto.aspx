<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="proyecto.aspx.cs" Inherits="SICAP.proyecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido card-panel animated fadeIn">
        <h3 class="section">Crear un nuevo proyecto</h3>
        <div class="divider"></div>
        <div class="section"></div>


        <div class="row">
            <div class="input-field col s12">
                <asp:Label Text="Nombre del proyecto" AssociatedControlID="txtNombre" runat="server" />
                <asp:TextBox runat="server" ID="txtNombre" />
            </div>
        </div>

        <div class="row">
            <div class="input-field col s12 m2">
                <asp:Label Text="Fecha de inicio" runat="server" />
                <asp:TextBox ID="txtFechaInicialProyecto" runat="server" TextMode="Date" />
            </div>
            <div class="input-field col s12 m3">
                <asp:Label Text="Fecha de Termino" runat="server" />
                <asp:TextBox ID="txtFechaFinalProyecto" runat="server" TextMode="Date" />
            </div>

            <div class="col s12 m7">
                  
            </div>

        </div>

        <div class="row">
            <div class="input-field col s12">
                <asp:Label Text="Obeservaciones" AssociatedControlID="txtObservaciones" runat="server" />
                <asp:TextBox ID="txtObservaciones" CssClass="materialize-textarea" TextMode ="MultiLine" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col s12">

                <ul class="collapsible">
                    <li>
                      <div class="collapsible-header"><i class="material-icons">add</i>Agregar Actividad</div>
                      <div class="collapsible-body">
                          <div class="row">
                              <div class="input-field col s12 m9">
                                  <asp:Label Text="Nombre de la actividad"  runat="server" />
                                  <asp:TextBox ID="txtNombreActividad" placeholder="Escriba el nombre la actividad" runat="server" />
                              </div>

                              <div class="input-field col s12 m3">
                                  <asp:Label Text="Fecha de entrega" runat="server" />
                                  <asp:TextBox ID="txtfechaEntregaActividad" TextMode="Date" runat="server" />
                              </div>
                          </div>

                          <div class="row">
                              <div class="input-field col s12">
                                  <asp:Label Text="Observaciones" AssociatedControlID="txtObservacionesActividad" runat="server" />
                                  <asp:TextBox ID="txtObservacionesActividad" runat="server" />
                              </div>
                          </div>

                          <div class="row">
                              <asp:LinkButton runat="server" >Agregar Actividad<i class="material-icons left">add</i></asp:LinkButton>
                          </div>
                      </div>
                    </li>                    
                </ul>
            </div>

        </div>
        
        <div class="row">
            <div class="col s12 m6 card-panel">
                <asp:GridView ID="gvUsuarioPorSeleccionar" CssClass="responsive-table" OnSelectedIndexChanged="gvUsuarioPorSeleccionar_SelectedIndexChanged" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField DataField="id_usuario" HeaderText="ID" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="paterno" HeaderText="Apellido Paterno" />
                        <asp:BoundField DataField="materno" HeaderText="Apellido Materno" />
                        <asp:BoundField DataField="area" HeaderText="Area" />
                        <asp:ButtonField ButtonType="Link" CommandName="Select" Text="agregar" />
                    </Columns>
                </asp:GridView>
            </div>
        
            <div class="col s12 m6 card-panel">
                <asp:GridView runat="server" CssClass="responsive-video" ID="gvUsuarioSeleccionados">
                    <Columns>
                        <asp:BoundField DataField="id_usuario" HeaderText="ID" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="paterno" HeaderText="Apellido Paterno" />
                        <asp:BoundField DataField="materno" HeaderText="Apellido Materno" />
                        <asp:BoundField DataField="area" HeaderText="Area" />
                        <asp:ButtonField ButtonType="Link" CommandName="Select" Text="Quitar" />
                    </Columns>
                </asp:GridView>
            </div>
            
         </div>
                            

                                    
                                

                                
                                
                                    
                                

        <div class="row">            
            <div class="col s12 m6">
                <h5 class="section">Actividades</h5>
                <div class="divider"></div>                
                <div class="col s12">
                    <asp:GridView ID="gvActividades" CssClass="responsive-table" runat="server"></asp:GridView>
                </div>
            </div>

            <div class="col s12 m6">
                
            </div>
        </div>                                   

    </div>




    <script src="Recursos/Proyecto.js"></script>
</asp:Content>
