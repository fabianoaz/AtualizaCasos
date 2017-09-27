
var meuApp = angular.module('moduloPrincipal', []);

meuApp.controller('ControllerInicial', function ControllerInicial($scope) {
	
	$scope.nomeAplicacao = 'Minha Aplicacao AngularJS';
	
	$scope.lista = [
		{nome: 'Fabiano',idade: 37},
		{nome: 'Aniele',idade: 26}
		];
	});

meuApp.controller('segundoController', function segundoController($scope){

	$scope.testeController = 'Dado do segundo controlller'

});

meuApp.controller('draftController', function draftController($scope, $http){

	$scope.draft;
	
	var url = './ConsultaSQL.asmx/consultaDraft';

	$http.get(url).then(function(response){
		$scope.draft = response.data;
	}, function(err){
		console.log(err);
	});
});

meuApp.controller('futureController', function futureController($scope, $http){

	$scope.future;
	
	var url = './ConsultaSQL.asmx/consultaFuture';

	$http.get(url).then(function(response){
		$scope.future = response.data;
	}, function(err){
		console.log(err);
	});
});

meuApp.controller('finalController', function finalController($scope, $http){

	$scope.final;
	
	var url = './ConsultaSQL.asmx/consultaFinal';

	$http.get(url).then(function(response){
		$scope.final = response.data;
	}, function(err){
		console.log(err);
	});
});
