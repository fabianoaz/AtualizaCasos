
var app = angular.module('moduloPrincipal', []);

app.controller('ControllerInicial', function ControllerInicial($scope) {

		$scope.nomeAppLista = 'Lista de Casos';
	
	});


app.controller('draftController', function draftController($scope, $http){

	$scope.draft;
	
	var url = './../ConsultaSQL.asmx/consultaDraft';

	$http.get(url).then(function(response){
		$scope.draft = response.data;
	}, function(err){
		console.log(err);
	});	
});

app.controller('futureController', function futureController($scope, $http){

	$scope.future;
	
	var url = './../ConsultaSQL.asmx/consultaFuture';

	$http.get(url).then(function(response){
		$scope.future = response.data;
	}, function(err){
		console.log(err);
	});
});

app.controller('finalController', function finalController($scope, $http){

	$scope.final;
	
	var url = './../ConsultaSQL.asmx/consultaFinal';

	$http.get(url).then(function(response){
		$scope.final = response.data;
	}, function(err){
		console.log(err);
        });
});


