(function () {
    'use strict';

    angular
        .module('common.services')
        .factory('actionbarResource', ['$resource', actionbarResource]);


    function actionbarResource($resource) {
        return $resource(SERVICE_BASE + "/:musrId")
    }
})();