(function () {
    'use strict';

    angular
        .module('app')
        .factory('topBarService', topBarService);

    topBarService.$inject = ['$http'];

    function topBarService($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData() { }
    }
})();