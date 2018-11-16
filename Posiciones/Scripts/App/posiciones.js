$(document).ready(function () {
    buscarPalabras();
})

function buscarPosicion(cual) {
    var params = {
        Palabra: cual
    }
    $.ajax({
        data: JSON.stringify(params),
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: "/Api/PosicionesApi/BuscarPosicion",
    })
    .done(function (data, textStatus, jqXHR) {
        var posiciones = "[" + data.Resultados.join("],[") + "]";
        if ($("#" + cual).is(":visible")){
            $("#" + cual).html(posiciones).slideUp();
        }else{
            $("#" + cual).html(posiciones).slideDown();
        }
        buscarPalabras();
        
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        console.log("La solicitud a fallado: " + textStatus);
    });
}

function buscarPalabras() {
    $.ajax({
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: "/Api/PosicionesApi/TraerPalabras",
    })
    .done(function (data, textStatus, jqXHR) {
        armarGrilla(data);
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        console.log("La solicitud a fallado: " + textStatus);
    });
}

function armarGrilla(data) {

    if ($("#grillaUl").length > 0) {
        $("#grillaUl").remove();
    }
    
    var ul = $("<ul id='grillaUl'>").addClass("list-group").appendTo("#grilla");
    for (var i = 0; i < data.length; i++) {
        
        var li = $("<li>").addClass("list-group-item d-flex justify-content-between align-items-center").html(data[i].Palabra + " fue elegida").appendTo(ul);
        $("<span>").addClass("badge badge-primary badge-pill").html(data[i].Cantidad + " veces").appendTo(li);
    }
}