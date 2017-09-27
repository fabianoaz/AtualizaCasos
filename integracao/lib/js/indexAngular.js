
var app = angular.module('moduloPaginaInicial', []);

app.controller('IndexCtrl', function IndexCtrl($scope, $window) {

    $scope.nomeAplicacao = "Pagina Inicial";

    $scope.abreWSAtualizaInformacoes = function () {
        $window.open("AtualizaSQL.asmx", "blank", "", false);
    }

    $scope.abreWSRetornaInformacoes = function () {
        $window.open("ConsultaSQL.asmx", "blank", "", false);
    }

    $scope.retornaDraft = function () {
        $window.open("ConsultaSQL.asmx?op=consultaDraft", "blank", "", false);
    }

    $scope.retornaFuture = function () {
        $window.open("ConsultaSQL.asmx?op=consultaFuture", "blank", "", false);
    }

    $scope.retornaFinal = function () {
        $window.open("ConsultaSQL.asmx?op=consultaFinal", "blank", "", false);
    }

    $scope.listaCasos = function () {
        $window.open("WebPages/listaCasos.html", "blank", "", false);
    }

    $scope.atualizaCasos = function () {
        $window.open("WebPages/atualizaCasos.html", "blank", "", false);
    }
    $scope.listaEatualiza = function () {
        $window.open("WebPages/listaEatualiza.html", "blank", "", false);
    }
	    $scope.listaTempos = function () {
        $window.open("WebPages/listaTempos.html", "blank", "", false);
    }
	
});