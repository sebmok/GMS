(function () {
    'use strict';

    angular
        .module('gmsManagement')
        .controller('DashboardCtrl',
                    ['sidebarResource', 'actionbarResource', 
                        DashboardCtrl]);

        function DashboardCtrl(sidebarResource, actionbarResource) {
        var vm = this;

        sidebarResource.query(function (data) {
            vm.sidebar = data;
        });

        actionbarResource.query(function (data) {
            vm.actionbar = data;
        });

    

        activate();

        function activate() { }
    }
})();
