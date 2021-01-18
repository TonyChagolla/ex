$(function () {
    var $btnGetCiudades = $('#btnGetCiudades');
    var $btnBuscar = $('#btnBuscar');
    var $btnInsertar = $('#btnInsertar');
    var $btnEliminar = $('#btnEliminar');
    var $btnActualizar = $('#btnActualizar');
    var $tbxBuscar = $('#tbxBuscar');
    var $tbxActID = $('#tbxActID');
    var $tbxActualizar = $('#tbxActualizar');
    var $tbxInsertar = $('#tbxInsertar');
    var $tbxEliminar = $('#tbxEliminar');
    var $selectPais = $('#selectPais');
    var $selectEstado = $('#selectEstado');
    var $gvCiudad = $('#Grid');

    $.ajax({
        
        type: 'POST',
        url: 'https://localhost:44383/WebService1.asmx/GetPaises',
        success: function (res) {
            var htmlcode = '<select class="select" id=selectPais>';
            var paises = $.parseJSON(res.lastChild.textContent);
            $.each(paises, function (i, pais) {
                htmlcode += '<option value="' + pais.pais_id + '">' + pais.nombre + "</option>";
            });
            htmlcode += '</select>';
            $('#pais').html(htmlcode);
        },
        error: function () {
            alert('error cargando paises');
        }
    });

    getEstado(1);

    $('#pais').delegate('#selectPais', 'change', function () {
        getEstado($('#selectPais').val());
    });

    function getEstado(pais_id) {
        var settings = {
            "url": "https://localhost:44383/WebService1.asmx/GetEstados",
            "method": "POST",
            "timeout": 0,
            "headers": {
                "Content-Type": "application/x-www-form-urlencoded"
            },
            "data": {
                "pais_id": pais_id
            }
        };

        $.ajax(settings).done(function (res) {
            var htmlcode = '<select class="select" id=selectEstado>';
            var estados = $.parseJSON(res.lastChild.textContent);
            $.each(estados, function (i, estado) {
                htmlcode += '<option value="' + estado.estado_id + '">' + estado.nombre + "</option>";
            });
            htmlcode += '</select>';
            $('#estado').html(htmlcode);
        });
        
    }


    $($btnBuscar).on('click', function () {
        event.preventDefault();
        if ($($tbxBuscar).val() == '') {
            alert('Ingresa el nombre de la ciudad');
            return;
        }
        var root = document.location.host;
        var apiRUL = 'https://' + root + '/WebService1.asmx/GetCiudad'
        var settings = {
            "url": "https://localhost:44383/WebService1.asmx/GetCiudad",
            "method": "POST",
            "timeout": 0,
            "headers": {
                "Content-Type": "application/x-www-form-urlencoded"
            },
            "data": {
                "ciudad": $($tbxBuscar).val()
            }
        };

        $.ajax(settings).done(function (response) {
            var res = $.parseJSON(response.lastChild.textContent);
            var table = "<table class='table'><tr><th>ID</th><th>Ciudad</th><th>Estado</th><th>País</th></tr>";
            $.each(res, function (i, res_) {
                table += '<tr"><td>' + res_.ciudad_id + '</td><td>' + res_.Ciudad + '</td><td>' + res_.Estado + '</td><td>' + res_.Pais + '</td></tr>'
            });
            table += "</table>";
            $($gvCiudad).html(table);
        });
    });

    $($btnGetCiudades).on('click', function () {
        event.preventDefault();
        getCiudades();
    });

    function getCiudades() {
        var root = document.location.host;
        var apiRUL = 'https://' + root + '/WebService1.asmx/GetCiudad'
        var settings = {
            "url": "https://localhost:44383/WebService1.asmx/GetCiudades",
            "method": "POST",
            "timeout": 0,
        };

        $.ajax(settings).done(function (response) {
            var res = $.parseJSON(response.lastChild.textContent);
            var table = "<table class='table'><tr><th>ID</th><th>Ciudad</th><th>Estado</th><th>País</th></tr>";
            $.each(res, function (i, res_) {
                table += '<tr"><td>' + res_.ciudad_id + '</td><td>' + res_.Ciudad + '</td><td>' + res_.Estado + '</td><td>' + res_.Pais + '</td></tr>'
            });
            table += "</table>";
            $($gvCiudad).html(table);
        });
    }

    $($btnEliminar).on('click', function () {
        event.preventDefault();
        var ciudadID = $($tbxEliminar).val()
        if (ciudadID == '' || !$.isNumeric(ciudadID)) {
            alert('Ingresa un ID Valido');
            return;
        }
        var root = document.location.host;
        var apiRUL = 'https://' + root + '/WebService1.asmx/deleteCiudad'
        var settings = {
            "url": "https://localhost:44383/WebService1.asmx/deleteCiudad",
            "method": "POST",
            "timeout": 0,
            "headers": {
                "Content-Type": "application/x-www-form-urlencoded"
            },
            "data": {
                "ciudad_id": ciudadID
            }
        };

        $.ajax(settings).done(function (response) {
            getCiudades();
        });
    });



    $($btnActualizar).on('click', function () {
        event.preventDefault();
        var ciudad = $($tbxActualizar).val();
        var id_ciudad = $($tbxActID).val()
        if (ciudad == '' || id_ciudad == '' || !$.isNumeric(id_ciudad)) {
            alert('Ingresa un nombre de ciudad y un id de ciudad valido');
            return;
        }

        var settings = {
            "url": "https://localhost:44383/WebService1.asmx/updateCiudad",
            "method": "POST",
            "timeout": 0,
            "headers": {
                "Content-Type": "application/x-www-form-urlencoded"
            },
            "data": {
                "ciudad_id": id_ciudad,
                "newName": ciudad
            }
        };

        $.ajax(settings).done(function (res) {
            getCiudades();
        });
    });


    $($btnInsertar).on('click', function () {
        event.preventDefault();
        if ($($tbxInsertar).val() == '') {
            alert('Ingresa el nombre de la ciudad');
        }
        var estado_id = $('#selectEstado').val();
        var ciudad = $($tbxInsertar).val();

        var settings = {
            "url": "https://localhost:44383/WebService1.asmx/insertCiudad",
            "method": "POST",
            "timeout": 0,
            "headers": {
                "Content-Type": "application/x-www-form-urlencoded"
            },
            "data": {
                "estado_id": estado_id,
                "nombre": ciudad
            }
        };

        $.ajax(settings).done(function (res) {
            getCiudades();
        });
        
    });
});