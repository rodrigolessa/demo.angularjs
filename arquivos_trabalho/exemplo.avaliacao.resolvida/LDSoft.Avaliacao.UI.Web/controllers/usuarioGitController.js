var usuarioGitController = function ($scope, $http) {
    /* jshint validthis:true */
    var vm = this;

    vm.titulo = 'Lista de Usuários do GitHub';
    vm.urlUsuarioGit = 'https://api.github.com/users';
    vm.usuarios = {};
    vm.obterUsuarios = function (inicio) {
        $http.get(vm.urlUsuarioGit + '?since=' + inicio)
            .success(function (result, status, headers, config) {
                vm.usuarios = result;
            });
    };

    vm.obterUsuarios(1);
}

angular
    .module('ldsoft.avaliacao')
    .controller('usuarioGitController', usuarioGitController);

//usuarioGitController.$inject = ['$scope', '$http'];