$(document).ready(SetupControl);


function SetupControl() {
    f_cargar_tipocomplejo();
}

function f_cargar_tipocomplejo() {

    // Cargando las familias
    $.ajax({
        method: 'POST',
        url: '~/../../TipoComplejo/f_tipocomplejo',
        data: {},
        dataType: 'json',
        success: function (data) {
            $("#cbotipocomplejo").empty();
            $('<option value="0">-- SELECCIONAR -- </option>').appendTo("#cbotipocomplejo");
            $.each(data.Records, function (i, v) {
                $('<option value="' + v.TipoID + '">' + v.NombreTipo + '</option>').appendTo("#cbotipocomplejo");
            });
        },
        error: function (e) {
            console.log(e);
        }
    });
}