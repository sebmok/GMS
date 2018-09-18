(function() {
    'use strict';

    angular
        .module('app')
        .directive('sidebar', sidebar);

    sidebar.$inject = ['$window'];
    
    function sidebar ($window) {
        // Usage:
        //     <sidebar></sidebar>
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: 'EA',
            templateUrl: '/Content/SYSTEM/app/layout/dashboard/sidebar.html'
            
        };
        return directive;

        function link(scope, element, attrs) {
        }
    }

})();