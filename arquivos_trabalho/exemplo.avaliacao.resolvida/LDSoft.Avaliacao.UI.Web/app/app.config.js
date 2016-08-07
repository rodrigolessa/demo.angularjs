angular.module('ldsoft.avaliacao')
    .config([
        '$routeProvider', function ($routeProvider) {
            $routeProvider
                .when('/usuarioGit',
                {
                    controller: 'usuarioGitController',
                    templateUrl: 'usuarioGit.html'
                })
                .when('/usuarioGit/:login',
                {
                    controller: 'usuarioGitDetalheController',
                    templateUrl: 'usuarioGitDetalhe.html'
                })
                .otherwise({
                    redirectTo: '/'
                });
        }
    ]);