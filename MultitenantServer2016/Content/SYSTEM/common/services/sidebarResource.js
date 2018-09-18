(function () {
    'use strict';

    angular
        .module('common.services')
        .factory('sidebarResource', ['$resource', 'localStorage', sidebarResource]);

 
    function sidebarResource($resource, localStorage) {


       return $resource(SERVICE_BASE + "/:musrId")
    }
})();