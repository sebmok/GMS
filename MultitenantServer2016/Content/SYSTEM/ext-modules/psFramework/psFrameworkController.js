
'use strict';

angular
    .module('psFramework')
    .controller('psFrameworkController',
        ['$scope', '$rootScope', '$window', '$timeout', '$location', '$http', 'sessionStorage', 'localStorage', 'auth',
            function ($scope, $rootScope, $window, $timeout, $location, $http, sessionStorage, localStorage, auth) {

                var user = window.sessionStorage.getItem('uid');

                if (user == null) {
                    console.log("AUTHORIZATION REQUIRED ");

                } else {
                    $scope.loadActionBar = function () {
                        $http({
                            url: SERVICE_BASE + '/rest/dashboard/getActionBars',
                            method: 'GET',
                            params: { ulpid: user }
                        }).then(function (response) {
                            angular.copy(response.data, $scope.actionBar);
                            //console.log(response.data)
                        }, function (response) {
                            alert(response.data);
                        });
                }

                $scope.isMenuVisible = true;
                $scope.isMenuButtonVisible = true;
                $scope.isMenuVertical = true;
                $scope.actionBar = [];
               
                $scope.auth = auth;

                
                }

                $scope.$on('ps-menu-item-selected-event', function (evt, data) {
                    $scope.routeString = data.route;
                    $location.path(data.route);
                    checkWidth();
                    broadcastMenuState();
                });

                $scope.$on('ps-menu-orientation-changed-event', function (evt, data) {
                    $scope.isMenuVertical = data.isMenuVertical;
                });

                $($window).on('resize.psFramework', function () {
                    $scope.$evalAsync(function () {
                        checkWidth();
                        broadcastMenuState();
                    });
                });

                $scope.$on("$destroy", function () {
                    $($window).off("resize.psFramework"); // remove the handler added earlier
                });

                // Used for calculate screen size
                var checkWidth = function () {
                    var width = Math.max($($window).width(), $window.innerWidth);
                    $scope.isMenuVisible = (width >= 768);
                    $scope.isMenuButtonVisible = !$scope.isMenuVisible;

                };

                // Used for menu button click
                $scope.menuButtonClicked = function () {
                    $scope.isMenuVisible = !$scope.isMenuVisible;
                   
                    broadcastMenuState();
                    $scope.$evalAsync();
                };

                $scope.logout = function () {

                    sessionStorage.remove('accessToken');
                    sessionStorage.remove('refreshToken');                    
                    sessionStorage.remove('profile');
                    localStorage.remove('profile');                  
                    sessionStorage.remove('uid');
                    localStorage.remove('accessToken');
                    localStorage.remove('members');
                    localStorage.remove('sidebars');
                    localStorage.remove('actionbars');                    


                    window.location.replace("/");

                };

                // show menu
                var broadcastMenuState = function () {
                    $rootScope.$broadcast('ps-menu-show',
                        {
                            show: $scope.isMenuVisible,
                            isVertical: $scope.isMenuVertical,
                            allowHorizontalToogle: !$scope.isMenuButtonVisible,
                            allowHorizontalToogle: !$scope.isVertical
                        });
                };

                $timeout(function () {
                    checkWidth();

                }, 0);

            }


        ]);