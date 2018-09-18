(function () {
    'use strict';

    angular
        .module('app')
        .directive('topbar', topbar);

    topbar.$inject = ['$window'];

    function topbar($window) {
        // Usage:
        //     <topbar></topbar>
        // Creates:
        // 
        var directive = {
            link: link,
            replace: true,
            restrict: 'EA',
            templateUrl: '/Content/SYSTEM/app/layout/dashboard/topbar.html'

        };
        return directive;

        function link(scope, element, attrs) {
        }
    }

})();