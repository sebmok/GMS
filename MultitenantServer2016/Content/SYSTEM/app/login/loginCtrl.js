(function () {
    'use strict';

    angular
        .module('tms.login', ['auth0'])
        .controller('loginController', loginController);

    loginController.$inject = ['$scope', 'auth', '$location', 'sessionStorage', 'localStorage'];

    function loginController($scope, auth, $location, sessionStorage, localStorage) {
        $scope.title = 'loginController';
        $scope.login = function () {
            auth.signin({
                authParams: {
                    scope: 'openid offline_access',
                }

            }, function (profile, token, access_token, state, refresh_token) {

                //store.set('token', token);
                sessionStorage.set('refreshToken', refresh_token);

                $location.path('/');

            }, function (error) {
                console.log(" Authorization Error ", error);
            });
        }


        activate();

        function activate() { }
    }
})();
