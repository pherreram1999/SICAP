var today = new Date();
var dd = String(today.getDate()).padStart(2, '0');
var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
var yyyy = today.getFullYear();

today = yyyy + '-' + mm + '-' + dd;

var fechaInicialProyecto = document.getElementById("ContentPlaceHolder1_txtFechaInicialProyecto");
fechaInicialProyecto.min = today;
fechaInicialProyecto.value = today;

var fechaFinalProyecto = document.getElementById("ContentPlaceHolder1_txtFechaFinalProyecto");
fechaFinalProyecto.min = today;

var fechaEntregaActividad = document.getElementById("ContentPlaceHolder1_txtfechaEntregaActividad");
fechaEntregaActividad.min = today;

var fechaLimite = function () {
    fechaEntregaActividad.max = fechaFinalProyecto.value;
}

fechaFinalProyecto.addEventListener("change", fechaLimite);


