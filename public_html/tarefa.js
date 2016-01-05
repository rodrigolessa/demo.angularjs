var tarefaController = function ($scope, $http, $rootScope) {
  $scope.pagina = "Início";
  
  var self = this;
  var urlServico = $rootScope.urlServico;
  
  self.funcionario = {};
  
  $http.get(urlServico)
    .success(function(result, status, headers, config) {
      self.funcionario = result[0];
    })
  
  self.todos = [
    {text:'learn angular', done:true},
    {text:'build an angular app', done:false}
  ];
  
  self.addTodo = function() {
    self.todos.push({text:self.todoText, done:false});
    self.todoText = '';
  };
  
  self.remaining = function() {
    var count = 0;
    angular.forEach(self.todos, function(todo) {
      count += todo.done ? 0 : 1;
    });
    return count;
  };
  
  self.archive = function() {
    var oldTodos = self.todos;
    self.todos = [];
    angular.forEach(oldTodos, function(todo) {
      if (!todo.done) self.todos.push(todo);
    });
  };
  
}

// Injetando dependência
tarefaController.$inject = ['$scope', '$http', '$rootScope'];