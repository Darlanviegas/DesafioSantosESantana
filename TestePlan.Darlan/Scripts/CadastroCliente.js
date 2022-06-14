////$(function () {
////    $("input[data-tipo=''cpf'']").mask("000.000.000-00");
////    $("input[data-tipo=''cnpj'']").mask("00.000.000/0001-00");
////});
window.onload = function () {
    ValorInicialpagina();
};

function ValorInicialpagina() {
    $('#TipoCliente').val(0);
    $("#Documento").mask("00.000.000/0001-00");

}

$('#TipoCliente').on('change', function () {
    alert(this.value);
    $("#Documento").val("");
    this.value == 1 ? $("#Documento").mask("000.000.000-00") : $("#Documento").mask("00.000.000/0001-00");
    
});
