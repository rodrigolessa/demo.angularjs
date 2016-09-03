// Definir rotas
app.config(function($routeProvider) {
  $routeProvider
    .when('/',
      {
        controller:tarefaController,
        templateUrl:'tarefa.html'
      })
    .when('/funcionario',
      {
        controller:funcionarioController,
        templateUrl:'funcionario.html'
      })
    .when('/funcionario/:id',
      {
        controller:manterFuncionarioController,
        templateUrl:'manterFuncionario.html'
      })
    .otherwise(
      {
        templateUrl:'404.html'
      })
});

//TODO: Definir propriedades para serem acessadas em qualquer parte da aplicação
app.run(function($rootScope) {
  $rootScope.urlFuncionarioServico = 'http://localhost/tarefa.service/api/funcionario';
  $rootScope.urlTarefaServico = 'http://localhost/tarefa.service/api/tarefa';
  $rootScope.idDoFuncionarioLogado = 1;
});