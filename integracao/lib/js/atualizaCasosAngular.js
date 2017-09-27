
var app = angular.module('moduloAtualizacao', []);

app.controller('NomeAplicacao', function NomeAplicacao($scope){
	
	$scope.nomeAppAtualiza = "Atualizacao de Status dos Casos";
	
});


app.controller('AtualizaTodos', function AtualizaTodos($scope, $http) {

    $scope.draftFutureTodos = function () {

        var url = '../AtualizaSQL.asmx/AtualizaDraftFutureTodas';

        $http.get(url).then(function (response) {
            $scope.draft = response.data;
        }, function (err) {
            console.log(err);
        });
    }

    $scope.futureDraftTodos = function () {

        var url = '../AtualizaSQL.asmx/AtualizaFutureDraftTodas';

        $http.get(url).then(function (response) {
            $scope.draft = response.data;
        }, function (err) {
            console.log(err);
        });
    }

    $scope.futureFinalTodos = function () {

        var url = '../AtualizaSQL.asmx/AtualizaFutureFinalTodas';

        $http.get(url).then(function (response) {
            $scope.draft = response.data;
        }, function (err) {
            console.log(err);
        });
    }
	
	$scope.alertaD = function () {
        var retVal = confirm("Confirma a atualização de TODOS registros?");
        if (retVal == true) {
				$scope.draftFutureTodos();
                alert('Atualizado!');
			}else{
                alert('Cancelado!');
            }
		}
		
	$scope.alertaF = function () {
        var retVal = confirm("Confirma a atualização de TODOS registros?");
        if (retVal == true) {
				$scope.draftFutureTodos();
                alert('Atualizado!');
			}else{
                alert('Cancelado!');
            }
		}

	$scope.alertaFN = function () {
        var retVal = confirm("Confirma a atualização de TODOS registros?");
        if (retVal == true) {
				$scope.futureFinalTodos();
                alert('Atualizado!');
			}else{
                alert('Cancelado!');
            }
		}		
	
})



app.controller('AtualizaEspecificos', function AtualizaEspecificos($scope, $http) {

    $scope.draftFutureEspecifico = function (dem) {

        var url = '../AtualizaSQL.asmx/AtualizaDraftFutureEspecifico?demanda=' + dem;

        $http.get(url).then(function (response) {
            $scope.draft = response.data;
        }, function (err) {
            console.log(err);
        });
    }

    $scope.futureDraftEspecifico = function (dem) {

        var url = '../AtualizaSQL.asmx/AtualizaFutureDraftEspecifico?demanda=' + dem;
        
        $http.get(url).then(function (response) {
            $scope.draft = response.data;
        }, function (err) {
            console.log(err);
        });
    }

    $scope.futureFinalEspecifico = function (dem) {

        var url = '../AtualizaSQL.asmx/AtualizaFutureFinalEspecifico?demanda=' + dem;

        $http.get(url).then(function (response) {
            $scope.draft = response.data;
        }, function (err) {
            console.log(err);
        });
    }

});