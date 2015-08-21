var manterFuncionarioController = function ($scope, $routeParams) {
  $scope.pagina = "Novo Funcionário";
  $scope.id = $routeParams.id;
}

manterFuncionarioController.$inject = ['$scope'];