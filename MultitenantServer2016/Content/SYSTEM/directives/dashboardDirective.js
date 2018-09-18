"use strict";

angular.module('gmsManagement').directive('tmsDashboard', [function () {
    return {
        scope: {
        },
        template: '<ps-dashboard></ps-dashboard>',
        link: function (scope) {
            scope.title = 'Dashboard';
            scope.gridsterOpts = {
                columns: 12,
                margins: [20, 20],
                outerMargin: false,
                pushing: true,
                floating: true,
                swapping: false
            };

            scope.widgetsDefinitions = [
                    //{
                    //    title: 'Temperature',
                    //    settings: {
                    //        sizeX: 2,
                    //        sizeY: 2,
                    //        minSizeX: 2,
                    //        minSizeY: 2,
                    //        template: '<widget-temperature></widget-temperature>',
                    //        widgetSettings: {
                    //            id: 1000
                    //        }
                    //    }
                    //},
                 {
                     title: 'Customers',
                     settings: {
                         sizeX: 7,
                         sizeY: 4,
                         minSizeX: 2,
                         minSizeY: 2,
                         template: '<widget-customers></widget-customers>',
                         widgetSettings: {
                             id: 5000
                         }
                     }
                 }
                 //,
                 // {
                 //     title: 'Orders',
                 //     settings: {
                 //         sizeX: 3,
                 //         sizeY: 3,
                 //         minSizeX: 2,
                 //         minSizeY: 2,
                 //         template: '<widget-orders></widget-orders>',
                 //         widgetSettings: {
                 //             id: 1000
                 //         }
                 //     }
                 // }

            ];

            scope.widgets = [

                {
                    title: 'Second',
                    sizeX: 7,
                    sizeY: 4,
                    row: 0,
                    col: 0,
                    template: '<widget-customers></widget-customers>',
                    widgetSettings: {
                        id: 5000
                    }
                }
            ];
        }
    }
}]);