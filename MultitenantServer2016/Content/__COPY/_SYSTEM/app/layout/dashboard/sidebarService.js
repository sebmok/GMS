(function () {
    'use strict';

    angular
        .module('app')
        .factory('sidebarService', sidebarService);

    sidebarService.$inject = ['$http'];

    function sidebarService($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData() { }
    }
})();