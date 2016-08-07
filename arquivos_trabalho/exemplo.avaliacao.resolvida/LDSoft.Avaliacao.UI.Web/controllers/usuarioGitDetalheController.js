var usuarioGitDetalheController = function ($scope, $http, $routeParams) {
    /* jshint validthis:true */
    var vm = this;

    vm.titulo = 'Usuário do GitHub Detalhe';
    vm.urlUsuarioGit = 'https://api.github.com/users';
    vm.login = $routeParams.login;
    vm.usuario = {};
    vm.repositorios = {};

    // Obter detalhes do usuário
    $http.get(vm.urlUsuarioGit + '/' + vm.login)
        .success(function (result, status, headers, config) {
            vm.usuario = result;
        });

    // Listar repositórios do usuário
    $http.get(vm.urlUsuarioGit + '/' + vm.login + '/repos')
        .success(function (result, status, headers, config) {
            vm.repositorios = result;
        });
}

angular
    .module('ldsoft.avaliacao')
    .controller('usuarioGitDetalheController', usuarioGitDetalheController);