(function (app) {
    'use strict';

    angular
        .module('app')
        .directive('sidebar', sidebar);

    sidebar.$inject = ['$window'];

    function sidebar($window) {
        // Usage:
        //     <topBarDirective></topBarDirective>
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: 'E',
            replace: true,
            templateUrl: 'Content/SYSTEM/app/layout/sidebarTemplate.html'

        };
        return directive;

        function link(scope, element, attrs) {
        }
    }

})();