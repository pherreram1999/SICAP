var fuArchivo = document.getElementById("fuArchivo"),
    txtNombre = document.getElementById("ContentPlaceHolder1_txtNombre"),
    txtPaterno = document.getElementById("ContentPlaceHolder1_txtPaterno"),
    txtMaterno = document.getElementById("ContentPlaceHolder1_txtMaterno"),
    txtEmail = document.getElementById("ContentPlaceHolder1_txtEmail"),
    txtTelefono = document.getElementById("ContentPlaceHolder1_txtTelefono"),
    dllRol = document.getElementsByClassName("select-wrapper"),
    txtContrasena = document.getElementById("ContentPlaceHolder1_txtContrasena"),
    txtConfirmarContrasena = document.getElementById("ContentPlaceHolder1_txtConfirmarContrasena"),
    txtEspecialidad = document.getElementById("ContentPlaceHolder1_txtEspecialidad"),    
    btnGuardar = document.getElementById("ContentPlaceHolder1_btnRegisrar");
    btnModificar = document.getElementById("btnModificar");






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
        dllRol[0].removeAttribute("disabled");
        dllRol[2].removeAttribute("disabled");
}

btnModificar.addEventListener("click",activar);


