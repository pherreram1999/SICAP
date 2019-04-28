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
                <asp:TextBox ID="txtFechaInicialProyecto" AutoPostBack="true" OnTextChanged="txtFechaInicialProyecto_TextChanged" required="required" CssClass="validate" runat="server" TextMode="Date" />
            </div>
            <div class="input-field col s12 m3">
                <asp:Label Text="Fecha de Termino" runat="server" />
                <asp:TextBox ID="txtFechaFinalProyecto" AutoPostBack="true" OnTextChanged="txtFechaFinalProyecto_TextChanged" required="required" CssClass="validate" runat="server" TextMode="Date" />
            </div>

            <div class="col s12 m7">
                  
            </div>

        </div>

        <div class="row">
            <div class="input-field col s12">
                <asp:Label Text="Obeservaciones" AssociatedControlID="txtObservaciones" runat="server" />
                <asp:TextBox ID="txtObservaciones" required="required" CssClass="materialize-textarea validate" TextMode ="MultiLine" runat="server" />
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
        <div class="row">
            <div class="col s12">
                <p>
                    *Puede seleccionar varios usuarios manteniendo presionado Ctrl y dando clic en los usuarios
                </p>
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
                                  <asp:Label CssClass="section" Text="Observaciones" runat="server" />
                                  <br />
                                  <asp:TextBox ID="txtObservacionesActividad"  CssClass="materialize-textarea" runat="server" />
                              </div>
                          </div>

                          <div class="row">
                              <asp:LinkButton runat="server" ID="btnAgregarActividad" OnClick="btnAgregarActividad_Click" >Agregar Actividad<i class="material-icons left">add</i></asp:LinkButton>
                          </div>
                      </div>
                    </li>                  
                </ul>
            </div>
        </div>                                  

        <div class="row">
            <div class="col s12">
                <asp:ListBox ID="lbxActividades" CssClass="browser-default fixSelect z-depth-2" runat="server"></asp:ListBox>
            </div>
        </div>


        <div class="row">
            <div class="section"></div>
            
            <asp:Button ID="btnCrearProyecto" CssClass="btn right" runat="server" Text="Crear Proyecto" OnClick="btnCrearProyecto_Click" />
        </div>


    </div>

<%--    <script src="Utelirias/Proyecto.js"></script>--%>
</asp:Content>
