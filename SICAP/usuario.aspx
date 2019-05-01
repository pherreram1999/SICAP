<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="SICAP.usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contenido">
        <div class="row">
            <asp:HyperLink ID="hlDesUsu" NavigateUrl="#modalDeshabilitar" Text="Deshabilitar Usuario" CssClass="waves-effect waves-light btn-flat cyan white-text modal-trigger left" runat="server" />
            <asp:HyperLink ID="hlHabUsu" Text="Habilitar Usuario" Visible = "false" NavigateUrl="#modalHabilitar" CssClass="waves-effect waves-light btn-flat green white-text modal-trigger right" runat="server" />
        </div>
    </div>

    <div class="contenido card-panel animated fadeIn">
        
        <div class="row">

            <div class="col s12">

                <asp:HyperLink Text="Volver Usuarios" NavigateUrl="~/usuarios.aspx" CssClass="left" runat="server" />                
                <asp:LinkButton Text="Modificar" ID="btnHabilitar" runat="server" CssClass="btn right" OnClick="btnHabilitar_Click" />
                
                <h4 class="section">Datos del usuario</h4>
                <div class="divider"></div>
            </div>
        </div>        

        <div class="row">
            <asp:Image ID="imgPerfil" ImageUrl="zImagenes/perflDefault.png" CssClass="imagen responsive-img circle col s4 m1" runat="server"/>

            <div class="file-field input-field col s12 m4">
                <div id="fuArchivo" class="btn blue">
                    <span>Seleccionar Foto</span>
                    <asp:FileUpload ID="fuPerfil" runat="server" Enabled ="false"/>
                </div>
                <div class="file-path-wrapper">
                    <input class="file-path validate" type="text" placeholder="Favor de cargar una foto pata el perfil">
                </div>
            </div>
            
            <asp:LinkButton ID="lbPerfil" CssClass="col s12 m2" runat="server" OnClick="lbPerfil_Click">Cargar Foto</asp:LinkButton>


        </div>

        <div class="row">            
            <div class="input-field col s12 m4">
                <i class="material-icons prefix">account_circle</i>
                <asp:TextBox ID="txtNombre" Enabled="false" required ="required" CssClass="validate disabled" runat="server" ></asp:TextBox>
                <asp:Label ID="lblNombre" AssociatedControlID="txtNombre" runat="server" Text="Nombre"></asp:Label>                                
            </div>

            <div class="input-field col s12 m4">
                <asp:TextBox ID="txtPaterno" Enabled="false" required ="required" CssClass="validate" runat="server" />
                <asp:Label Text="Apellido Paterno" AssociatedControlID="txtPaterno" runat="server" />
            </div>

            <div class="input-field col s12 m4">
                <asp:TextBox runat="server" ID="txtMaterno" Enabled="false" required ="required" CssClass="validate"/>
                <asp:Label Text="Apellido Materno" AssociatedControlID="txtMaterno" runat="server" />
            </div>
            
        </div>

        <div class="row">

            <div class="input-field col s12 m4">
                <i class="material-icons prefix">email</i>
                <asp:TextBox ID="txtEmail" Enabled="false" TextMode="Email" CssClass="validate" required="required" runat="server"></asp:TextBox>
                <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" runat="server" Text="Correo Electronico"></asp:Label>
            </div>
            <div class="input-field col s12 m4">
                <i class="material-icons prefix">phone</i>
                <asp:TextBox ID="txtTelefono" Enabled="false" TextMode="Phone" runat="server"  required ="required" CssClass="validate"></asp:TextBox>
                <asp:Label Text="Numero telefonico" AssociatedControlID="txtTelefono" runat="server" />
            </div>

        </div>
        
        <div class="row">
            <div class="input-field  col s12 m4">                
                <asp:DropDownList Enabled="false" ID="ddlRol" runat="server">
                    <asp:ListItem Text="Elija rol de usuario"  />
                    <asp:ListItem Text="Administrador" />
                    <asp:ListItem Text="Usuario" />
                </asp:DropDownList>
            </div>
            <div class="input-field  col s12 m8">
                <asp:HyperLink NavigateUrl="#modal" Text="Cambiar Contraseña" ID="hlCambiarPass" CssClass="waves-effect waves-light btn modal-trigger" runat="server" />                
            </div>

        </div>

        <div class="row">
            <div class="input-field col s12 m4">
                <i class="material-icons prefix">school</i>
                <asp:TextBox  ID="txtEspecialidad" Enabled="false" CssClass="validate" required="required" runat="server"></asp:TextBox>
                <asp:Label Text="Especialidad" AssociatedControlID="txtEspecialidad" runat="server" />
            </div>
            <div class="input-field col s12 m4">
                <i class="material-icons prefix">supervised_user_circle</i>
                <asp:DropDownList   ID="ddlArea" Enabled="false" runat="server">
                    <asp:ListItem Text="Elija area" disabled="disabled" Selected />
                </asp:DropDownList>
            </div>

        </div>

        <div class="row">
            <div class="section">                
                <asp:Button ID="btnRegisrar" Enabled="false"  CssClass="btn right" runat="server" Text="Guardar" OnClick="btnRegisrar_Click" />
            </div>
        </div>


        <div class="row">
            <div class="col s12">
                <ul class="collapsible">
                    <li>
                      <div class="collapsible-header"><i class="material-icons">work</i>Proyectos en los que participa</div>
                      <div class="collapsible-body">
                          <div class="row">
                              <asp:GridView runat="server" AutoGenerateColumns ="false" CssClass="responsive-table" ID="gvProyectosUsu">
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
                    </li>                  
                </ul>
            </div>
        </div>  



    </div>


    <div id="modal" class="modal">
        <div class="modal-content">
            <%-- toda la estructura va aqui --%>
            <h5 class="section">Cambiar Contraseña</h5>
            <div class="divider"></div>
            <p class="section">
                Favor de ingresar tu actual contraseña y confirmar la nueva contraseña
            </p>
            <div class="row">
                <div class="input-field col s12 m4">
                    <asp:Label Text="Contraseña Actual" AssociatedControlID="txtOldContrasena" runat="server" />
                    <asp:TextBox runat="server" TextMode="Password" ID="txtOldContrasena" />
                </div>
                <div class="input-field col s12 m4">
                    <asp:Label Text="Nueva Contraseña" AssociatedControlID="txtNewContrasena" runat="server" />
                    <asp:TextBox runat="server" TextMode="Password" ID="txtNewContrasena" />
                </div>
                <div class="input-field col s12 m4">
                    <asp:Label Text="Confirmar Contraseña" AssociatedControlID="txtConfirmarContrasena"  runat="server" />
                    <asp:TextBox runat="server" ID="txtConfirmarContrasena" TextMode="Password" />
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <asp:LinkButton Text="Cambiar Contraseña" class="modal-close waves-effect waves-green btn-flat" OnClick="btnCambiarContrasena_Click" ID="btnCambiarContrasena" runat="server" />
            <%--<a href="#!" >Agree</a>--%>
        </div>
    </div>

    
    <div id="modalDeshabilitar" class="modal">
        <div class="modal-content">
            <%-- toda la estructura va aqui --%>
            <h5 class="section">¿ Seguro de deshabilitar el Usuario?</h5>
            <div class="divider"></div>
            
            <div class="row">
                <h6>
                    Recuerde que podra habilitar el usuario en cualquier momento
                </h6>
            </div>
        </div>
        <div class="modal-footer">
            <asp:LinkButton Text="Deshabilitar Usuario" class="modal-close waves-effect waves-green btn-flat" OnClick="btnDeshabilitarUusuario_Click1" ID="btnDeshabilitarUusuario" runat="server" />
            <%--<a href="#!" >Agree</a>--%>
        </div>
    </div>

    <div id="modalHabilitar" class="modal">
        <div class="modal-content">
            <%-- toda la estructura va aqui --%>
            <h5 class="section">¿Desea habilitar el usuario?</h5>
            <div class="divider"></div>
            
            <div class="row">
                <h6>
                    El usuario podra volver iniciar sesión.
                </h6>
            </div>
        </div>
        <div class="modal-footer">
            <asp:LinkButton Text="Habilitar Usuario" class="modal-close waves-effect waves-green btn-flat" OnClick="btnHabilitarUsuario_Click" ID="btnHabilitarUsuario" runat="server" />
            <%--<a href="#!" >Agree</a>--%>
        </div>
    </div>




 
  

</asp:Content>
