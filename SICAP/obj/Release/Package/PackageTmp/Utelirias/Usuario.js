var fuArchivo = document.getElementById("fuArchivo"),
    txtNombre = document.getElementById("ContentPlaceHolder1_txtNombre"),
    txtPaterno = document.getElementById("ContentPlaceHolder1_txtPaterno"),
    txtMaterno = document.getElementById("ContentPlaceHolder1_txtMaterno"),
    txtEmail = document.getElementById("ContentPlaceHolder1_txtEmail"),
    txtTelefono = document.getElementById("ContentPlaceHolder1_txtTelefono"),
    //dllRol = document.getElementById("ContentPlaceHolder1_ddlRol").disabled = true,
    txtContrasena = document.getElementById("ContentPlaceHolder1_txtContrasena"),
    txtConfirmarContrasena = document.getElementById("ContentPlaceHolder1_txtConfirmarContrasena"),
    txtEspecialidad = document.getElementById("ContentPlaceHolder1_txtEspecialidad"),    
    btnGuardar = document.getElementById("ContentPlaceHolder1_btnRegisrar");
btnModificar = document.getElementById("btnModificar");
// dllArea = document.getElementById("ContentPlaceHolder1_ddlArea").disabled = true;






    var activar = function () {

        if (btnModificar.text == "Cancelar Modificacion") {
            location.href = "./usuarios.aspx";
        }
        else {
            btnModificar.text = "Cancelar Modificacion"
            btnModificar.className = "btn red right";
        }



        fuArchivo.classList.remove("disabled");
        btnGuardar.classList.remove("disabled");
        txtNombre.removeAttribute("disabled");
        txtPaterno.removeAttribute("disabled");
        txtMaterno.removeAttribute("disabled");
        txtEmail.removeAttribute("disabled");
        txtTelefono.removeAttribute("disabled");
        txtContrasena.removeAttribute("disabled");
        txtConfirmarContrasena.removeAttribute("disabled");
        txtEspecialidad.removeAttribute("disabled");
        dllRol = document.getElementById("ContentPlaceHolder1_ddlRol").disabled = false;
        dllArea = document.getElementById("ContentPlaceHolder1_ddlArea").disabled = false;

        contrasenas[0].classList.remove("esconder");
        contrasenas[1].classList.remove("esconder");
}

    btnModificar.addEventListener("click", activar);

    //var vaciar = function () {

    //    txtConfirmarContrasena.text = "";
    //    txtContrasena.text = "";
    //}

    //txtConfirmarContrasena.addEventListener("click", vaciar);
    //txtContrasena.accessKey("click", vaciar);
