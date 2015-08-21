////* global $ */

var app = angular.module('controleDeTarefa', ['ngRoute']);

app.controller('tarefaController', tarefaController);
app.controller('funcionarioController', funcionarioController);
app.controller('manterFuncionarioController', manterFuncionarioController);

//TODO: Definir rotas
app.config(function($routeProvider) {
  $routeProvider
    .when('/',{controller:tarefaController,templateUrl:'tarefa.html'})
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