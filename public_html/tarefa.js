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