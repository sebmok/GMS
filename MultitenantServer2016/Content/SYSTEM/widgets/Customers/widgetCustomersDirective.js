"use strict";

angular.module('gmsManagement').directive('widgetCustomers', [
'dataService', function (dataService) {
    return {
        templateUrl: 'Content/SYSTEM/widgets/Customers/widgetCustomersTemplate.html',
        link: function (scope, el, attrs) {
            dataService.getEmployee(scope.item.widgetSettings.id)
            .then(function (data) {
                scope.selectedEmployee = data;
            });
        }
    };
}]);