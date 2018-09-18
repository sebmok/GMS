angular.module('app.sidebar', [])
    .controller('sidebarCtrl', function ($scope, $http, sessionStorage, localStorage, auth) {
        $scope.SiteMenu = [];

        var user = window.localStorage.getItem('uid');

        function getSidebar() {
            $http({
                url: SERVICE_BASE + '/rest/dashboard/getSidebars',
                method: 'GET',
                params: { ulpid: user }
            }).then(function (response) {
                angular.copy(response.data, $scope.SiteMenu);

            }, function (response) {
                alert(response.data);
            });
        }

        getSidebar();

    });


