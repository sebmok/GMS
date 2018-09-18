(function(app) {
    'use strict';

    angular
        .module('app')
        .directive('topbar', topbar);

    topbar.$inject = ['$window'];
    
    function topbar ($window) {
        // Usage:
        //     <topBarDirective></topBarDirective>
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: 'E',
            replace: true,
            templateUrl: 'Content/SYSTEM/app/layout/topbarTemplate.html'

        };
        return directive;

        function link(scope, element, attrs) {
        }
    }

})();