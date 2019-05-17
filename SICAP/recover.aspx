<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recover.aspx.cs" Inherits="SICAP.recover" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>recover</title>
    <link href="Recursos/materialize.css" rel="stylesheet" />
    <link href="Recursos/material-icons.css" rel="stylesheet" />
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

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
        <div class="row">
            <div class="col s12 m3"></div>
            <div class="card-panel col s12 m6">
                <div class="row fm">
                    <a href="./default.aspx" class="right">volver</a>
                    <h5 class="section">Recuperar contraseña</h5>
                    <div class="divider"></div>
                    <p class="section">
                        Ingresa la direccion de correo electronico con la que te encuentres registrado para que se te mande una nueva contraseña.
                    </p>

                    <div class="input-field">
                        <asp:Label Text="Correo electronico" AssociatedControlID="txtEmail" runat="server" />
                        <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="activate" runat="server" />
                    </div>
                    <asp:Button Text="Enviar Correo" ID="btnRecuperar" CssClass="btn right" runat="server" OnClick="btnRecuperar_Click" />

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

</body>
</html>
