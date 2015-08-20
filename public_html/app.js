//* global $ */

var app = angular.module('controleDeTarefa', ['ngRoute']);

function tarefaController($scope) {
  $scope.pagina = "inicio";
  
  var self = this;
  
  self.todos = [
    {text:'learn angular', done:true},
    {text:'build an angular app', done:false}];
  
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

//TODO: Injetando dependência, Controle para listar tarefas
tarefaController.$inject = ['$scope'];
app.controller('tarefaController', tarefaController);


function funcionarioController($scope) {
  $scope.pagina = "Funcionário";
}

funcionarioController.$inject = ['$scope'];
app.controller('funcionarioController', funcionarioController);


function manterFuncionarioController($scope, $routeParams) {
  $scope.pagina = "Novo Funcionário";
  $scope.id = $routeParams.id;
}

manterFuncionarioController.$inject = ['$scope'];
app.controller('manterFuncionarioController', manterFuncionarioController);

//TODO: Definir rotas
app.config(function($routeProvider) {
  $routeProvider
    .when('/',{controller:listarTarefaController,templateUrl:'tarefa.html'})
    .when('/funcionario',{controller:funcionarioController,templateUrl:'funcionario.html'})
    .when('/funcionari/:id',{controller:manterFuncionarioController,templateUrl:'manterFuncionario.html'})
    .otherwise({templateUrl:'404.html'})
});

//TODO: Exibir contador progresivo de tempo de tarefa
// $(function(){
// 
//   moment().format();
// 
//   $("#stopwatch").text(moment("20150728", "YYYYMMDD").fromNow());
// 
// });