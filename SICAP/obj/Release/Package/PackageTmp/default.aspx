﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SICAP._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Inicio</title>
    <link href="Recursos/materialize.css" rel="stylesheet" />
    <link href="Recursos/material-icons.css" rel="stylesheet" />
    <link href="Recursos/animate.css" rel="stylesheet" />

    <style>

    form {
        position: fixed;
        top: 0;
        left:0;
        right:0;
        bottom:0;
        display: flex;
        justify-content:center;
        align-items:center;
    }

    .fm {
        padding:24px;

    }
    .fx {
        padding:0px 24px;

    }


    </style>
</head>
<body  id="fondo">
    <form id="form1" runat="server"  autocomplete="off">
    <div class="container">
        <div class="row">
            <div class="col s12 m4 animated fadeInUp"></div>
            <div class="card-panel col s12 m4">

                <div class="row fm">
                    <div class="col s12 center-align">
                        <img class="responsive-img" src="Recursos/logoSICAP.png" />
                    </div>
                </div>
                
                <div class="row fm">

                    <div class="input-field col s12">
                        <asp:Label Text="Correo Electronico" AssociatedControlID="txtCorreo" runat="server" />
                        <asp:TextBox runat="server" ID="txtCorreo" required="required" TextMode="Email"/>
                    </div>
                    <div class="input-field col s12">
                        <asp:Label Text="Contraseña" AssociatedControlID="txtContrasena" runat="server" />
                        <asp:TextBox runat="server" ID="txtContrasena" required="required" TextMode="Password"/>
                    </div>
                    <div class="col s12">
                        <asp:Button Text="Iniciar" ID="btnIniciar" CssClass="btn blue" runat="server" OnClick="btnIniciar_Click1" />
                    </div>
                    
                </div>
                <div class="row fx">
                    <div class="col s12">
                        <a href="./recover.aspx">recuperar contraseña</a>
                    </div>
                </div>

            </div>
        </div>
    </div>
    </form>

    <script src="Recursos/materialize.js"></script>
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            M.AutoInit();
        });
    </script>
    <script>
        var fondo = document.getElementById("fondo");
        var imagen = Math.floor((Math.random() * 10) + 1) + ".jpg";
        fondo.setAttribute("style", "background: url(Fondos/" + imagen + "); background-size: cover;")
    </script>
</body>
</html>
