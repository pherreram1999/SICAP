﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="SICAP.registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido card-panel animated fadeIn">
        <div class="row">
            <div class="col s12">
                <h4 class="section">Registro</h4>
                <div class="divider"></div>
            </div>
        </div>

        <div class="row">
            <asp:Image ID="imgPerfil" ImageUrl="sources/Materialize/Imagenes/perflDefault.png" CssClass="imagen responsive-img circle col s4 m1" runat="server"/>

            <div class="file-field input-field col s12 m4">
                <div class="btn blue">
                    <span>Seleccionar Foto</span>
                    <asp:FileUpload ID="fuPerfil" runat="server" />
                </div>
                <div class="file-path-wrapper">
                    <input class="file-path validate" type="text" placeholder="Favor de cargar una foto pata el perfil">
                </div>
            </div>
            
            <asp:LinkButton ID="lbPerfil" CssClass="col s12 m2" runat="server">Cargar Foto</asp:LinkButton>


        </div>

        <div class="row">            
            <div class="input-field col s12 m4">
                <i class="material-icons prefix">account_circle</i>
                <asp:TextBox ID="txtNombre" required ="required" CssClass="validate" runat="server" ></asp:TextBox>
                <asp:Label ID="lblNombre" AssociatedControlID="txtNombre" runat="server" Text="Nombre"></asp:Label>                                
            </div>

            <div class="input-field col s12 m4">
                <asp:TextBox ID="txtPaterno" runat="server" />
                <asp:Label Text="Apellido Paterno" AssociatedControlID="txtPaterno" runat="server" />
            </div>

            <div class="input-field col s12 m4">
                <asp:TextBox runat="server" ID="txtMaterno"  required ="required" CssClass="validate"/>
                <asp:Label Text="Apellido Materno" AssociatedControlID="txtMaterno" runat="server" />
            </div>
            
        </div>

        <div class="row">

            <div class="input-field col s12 m4">
                <i class="material-icons prefix">email</i>
                <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="validate" required="required" runat="server"></asp:TextBox>
                <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" runat="server" Text="Correo Electronico"></asp:Label>
            </div>
            <div class="input-field col s12 m4">
                <i class="material-icons prefix">phone</i>
                <asp:TextBox ID="txtTelefono" TextMode="Phone" runat="server"  required ="required" CssClass="validate"></asp:TextBox>
                <asp:Label Text="Numero telefonico" AssociatedControlID="txtTelefono" runat="server" />
            </div>

        </div>
        
        <div class="row">
            <div class="input-field col s12 m4">
                <i class="material-icons prefix">arrow_drop_down</i>
                <asp:DropDownList ID="ddlRol" runat="server">
                    <asp:ListItem Text="Elija rol de usuario" disabled Selected />
                    <asp:ListItem Text="Administrador" />
                    <asp:ListItem Text="Usuario" />
                </asp:DropDownList>
            </div>
            <div class="input-field col s12 m4">
                <i class="material-icons prefix">vpn_key</i>
                <asp:TextBox ID="txtContrasena" CssClass="validate" TextMode="Password" required="required" runat="server"></asp:TextBox>
                <asp:Label ID="lblContrasena" AssociatedControlID="txtContrasena" runat="server" Text="Contrasena"></asp:Label>
            </div>
            <div class="input-field col s12 m4">
                <i class="material-icons prefix">vpn_key</i>
                <asp:TextBox ID="txtConfirmarContrasena" TextMode="Password" CssClass="validate" required="required" runat="server"></asp:TextBox>
                <asp:Label Text="Confirmar contraseña" AssociatedControlID="txtConfirmarContrasena" runat="server" />
            </div>
        </div>

        <div class="row">
            <div class="input-field col s12 m4">
                <i class="material-icons prefix">school</i>
                <asp:TextBox ID="txtEspecialidad" CssClass="validate" required="required" runat="server"></asp:TextBox>
                <asp:Label Text="Especialidad" AssociatedControlID="txtEspecialidad" runat="server" />
            </div>
            <div class="input-field col s12 m4">
                <i class="material-icons prefix">supervised_user_circle</i>
                <asp:DropDownList ID="ddlArea" runat="server">
                    <asp:ListItem Text="Elija area" disabled Selected />
                </asp:DropDownList>
            </div>

        </div>

        <div class="row">
            <div class="section">                
                <asp:Button ID="btnRegisrar"  CssClass="btn right" runat="server" Text="Registrar" OnClick="btnRegisrar_Click" />
            </div>
        </div>

    </div>
</asp:Content>
