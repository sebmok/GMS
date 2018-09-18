"use strict";

angular.module('gmsManagement').factory('dataService',
    ['$timeout', function ($timeout) {

                var locations = [
        {
            id: 1000,
            name: 'Some first',
            temperature: 55,
            guides: 15,
            rafts: 18,
            vests: 200
        },

        {
            id: 101,
            name: 'Some second',
            temperature: 25,
            guides: 1,
            rafts: 8,
            vests: 20
        }];

        var employees = [{
            id: 5000,
            name: 'asdasdasd',
            location: 'qwesfddf asd'

        },
        {
            id: 50200,
            name: 'asd',
            location: 'qwesd'

        }];

        var getLocations = function () {
            return $timeout(function () {
                return locations;
            }, 500);
        };

        var getLocation = function (id) {
            return $timeout(function () {
                for (var i = 0; i < locations.length; i++)
                    if (locations[i].id == id)
                        return locations[i];
                return undefined;
            }, 300);
        };

        var getEmployees = function () {
            return $timeout(function () {
                return employees;
            }, 500);
        };

        var getEmployee = function (id) {
            return $timeout(function () {
                for (var i = 0; i < employees.length; i++)
                    if (employees[i].id == id)
                        return employees[i];
                return undefined;
            }, 300);
        };

        return {
            getLocations: getLocations,
            getLocation: getLocation,
            getEmployees: getEmployees,
            getEmployee: getEmployee



        };
    }]);