//* global $ */

//TODO: Configurar rotas
//var app = angular.module('app', ['ngRoute']);
// function tarefaListaController($scope) {
//   $scope.pagina = "home";
// }

//TODO: Injetando dependência, Controle
// tarefaListaController.$inject = ['$scope'];
// app.controller('tarefaListaController', tarefaListaController);

//TODO: Definir rotas
//app.config(function($routeProvider){
//$routeProvider
//.when('/',{controller:tarefaListaController,templateUrl:'tarefa.html'})
//.when('/funcionario',{controller:funcionarioController,templateUrl:'funcionario.html'})
//.otherwise({templateUrl:'404.html'})
//});

angular.module('tarefaApp', [])
  .controller('TodoListController', function() {

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

});

//TODO: Exibir contador progresivo de tempo de tarefa
// $(function(){
// 
//   moment().format();
// 
//   $("#stopwatch").text(moment("20150728", "YYYYMMDD").fromNow());
// 
// });