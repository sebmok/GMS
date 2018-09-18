(function () {
    'use strict';

    angular
        .module('gmsManagement')
        .factory('sidebarService', sidebarService);

    sidebarService.$inject = ['$http', '$timeout', 'localStorage', 'sessionStorage'];

    function sidebarService($http, $timeout, localStorage, sessionStorage) {
        var service = {
            getSidebar: getSidebar
        };

        var sidebar = [];

        return service;

        function getSidebar() {

            var user = window.localStorage.getItem('uid');

            $http({
                url: SERVICE_BASE + '/rest/dashboard/getSidebars',
                method: 'GET',
                params: { ulpid: user }
            }).then(function (response) {
                angular.copy(response.data, sidebar);


            }, function (response) {
                //alert(response.data);
                

            });
            console.log(sidebar);
        }
    }
})();