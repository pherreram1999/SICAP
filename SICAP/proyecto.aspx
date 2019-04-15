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
        

        
  
        <%-- Es la parte de seleccion de usuario --%>
        
        <h5 class="section">Usuarios</h5>
        <div class="divider"></div>
        <div class="section"></div>
                            
        <div class="row">
            <div class="col s12 m5">
                <asp:ListBox CssClass="browser-default fixSelect z-depth-1 section" ID="lbxUsuarios" SelectionMode="Multiple" runat="server">                    
                </asp:ListBox>
            </div>

            <div class="col s12 m2 center-align">
                <div class="section">
                    <asp:LinkButton CssClass="btn" ID="btnPasar"  runat="server" OnClick="btnPasar_Click" ><i class="material-icons">arrow_forward</i></asp:LinkButton>
                </div>
                <div class="section">
                    <asp:LinkButton CssClass="btn" ID="btnRegresar"  runat="server" OnClick="btnRegresar_Click"><i class="material-icons">arrow_back</i></asp:LinkButton>
                </div>
            </div>

            <div class="col s12 m5">
                <asp:ListBox CssClass="browser-default fixSelect z-depth-1 section" ID="lbxUsuariosSeleccionados" SelectionMode="Multiple" runat="server">                    

                </asp:ListBox>
            </div>

        </div>

        <%-- aqui viene las actividades  // sera util,o bien, se cancela todo  --%>

        <h5 class="section">Actividades</h5>
        <div class="divider"></div>
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
            <div class="col s12">
                <asp:GridView ID="gvActividades" CssClass="responsive-img" runat="server"></asp:GridView>
            </div>
        </div>

    </div>




    <script src="Utelirias/Proyecto.js"></script>
</asp:Content>
