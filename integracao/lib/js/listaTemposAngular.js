
var app = angular.module('moduloTempos', []);

app.controller('ControllerTempos', function ControllerTempos($scope, $http, $filter, $window) {

    $scope.nomeAppLista = 'Lista de Tempos';

    // $scope.fnEstimado = function() {

    //    $scope.estimado;
    
    //    var url = './../ConsultaSQL.asmx/listaTempoEstimado';
    
    //    $http.get(url).then(function (response) {
    //        $scope.estimado = response.data;
    //    }, function (err) {
    //        console.log(err);
    //        });

    // }

    // $scope.fnRealizado = function() {
        
    //     $scope.realizado;

    //     var url = './../ConsultaSQL.asmx/listaTempoRealizado';

    //     $http.get(url).then(function (response) {
    //         $scope.realizado = response.data;
    //     }, function (err) {
    //         console.log(err);
    //     });
    // }

    $scope.fnTempos = function(data) {

        //$window.alert("Parametro: " + data);

        var quebraData = data.split("/");

        var dia = quebraData[0];
        var mes = quebraData[1];
        var anohora = quebraData[2];

        var quebraDataHora = anohora.split(" ");

        var ano = quebraDataHora[0];
        var hora = quebraDataHora[1];

        var dataParam = ano+"-"+mes+"-"+dia+" "+hora;

         //$window.alert("Dia: " + dia + "\nMes: " + mes + "\nAno Hora: " + anohora + "\nAno: " + ano + "\nHora: " + hora + "\nData Parametro: " + dataParam);
        
        $scope.limitTempo = 6;
        
        $scope.tempos;

        var url = './../ConsultaSQL.asmx/calculoTempo?dataHora='+dataParam;

        $http.get(url).then(function (response) {
            $scope.tempos = response.data;
        }, function (err) {
            console.log(err);
        });
    }

    $scope.fnDataRegressivos = function () {

        $scope.dias;

        var url = './../ConsultaSQL.asmx/listaDataRegressivos'

        $http.get(url).then(function (response) {
            $scope.dias = response.data;
        }, function (err) {
            console.log(err);
        });

    }

	});


