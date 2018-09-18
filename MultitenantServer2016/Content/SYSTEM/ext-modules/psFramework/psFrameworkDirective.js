'use strict';

angular
    .module('psFramework')
    .directive('psFramework', function () {
       
        return {
            transclude: true,
            scope: {
                title: '@name',
                subtitle: '@',
                iconFile: '@'
            },
            templateUrl: "Content/SYSTEM/ext-modules/psFramework/psFrameworkTemplate.html",
            controller: "psFrameworkController"
            
        }
    });

