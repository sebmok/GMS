angular.module('app.actionBar', ['auth0'])
    .controller('actionBar', function ($scope, $http, auth) {
        $scope.actionBar = [];
        $scope.isBusy = true;
        $scope.auth = auth;
        var user = window.localStorage.getItem('uid');

        function getActionBar() {
            $http({
                url: SERVICE_BASE + '/rest/dashboard/getActionBars',
                method: 'GET',
                params: { ulpid: user }
            }).then(function (response) {
                angular.copy(response.data, $scope.actionBar);



            }, function (response) {
                alert(response.data);
            }).then(function () {
                $scope.isBusy = false;
            });
        }

        getActionBar();

    });
