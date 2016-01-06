var tarefaController = function ($scope, $http, $rootScope) {
  $scope.pagina = "Tarefas";
  
  var self = this;
  var urlServico = $rootScope.urlTarefaServico;
  var urlFuncionario = $rootScope.urlFuncionarioServico;
  var idDoFuncionario = $rootScope.idDoFuncionarioLogado;
  
  self.funcionario = {};
  
  // Obtem os dados do funcionário, utilizando API em .Net, que possui lista de tarefas
  $http.get(urlFuncionario + '/' + idDoFuncionario)
    .success(function(result, status, headers, config) {
      self.funcionario = result;
    });
  
  // Salva nova tarefa
  self.addTodo = function() {
    // Add tarefa
    self.funcionario.Tarefas.push(
      {
        IdFuncionario:idDoFuncionario
      , Descricao:self.todoText
      , Executada:false
      });
    // Limpa formulário
    self.todoText = '';
  };
  
  // Guarda quantidade de tarefas NÃO executadas
  self.remaining = function() {
    var count = 0;
    angular.forEach(self.funcionario.Tarefas, function(todo) {
      count += todo.Executada ? 0 : 1;
    });
    return count;
  };
  
  // Arquivar tarefas executadas
  self.archive = function() {
    var oldTodos = self.funcionario.Tarefas;
    self.funcionario.Tarefas = [];
    angular.forEach(oldTodos, function(todo) {
      if (!todo.Executada) self.funcionario.Tarefas.push(todo);
    });
  };
  
}

// Injetando dependência
tarefaController.$inject = ['$scope', '$http', '$rootScope'];