'use strict';

angular
    .module('psMenu')
    .controller('psMenuController',
        ['$scope', '$rootScope', '$http', 'localStorage', 'sessionStorage', 'sidebarService',
            function ($scope, $rootScope, $http, localStorage, sessionStorage, sidebarService) {

               
                var user = window.sessionStorage.getItem('uid');

                if (user == null) {
                    console.log(" AUTHORIZATION REQUIRED ");

                } else {

                    $scope.loadSidebar = function () {
                        $http({
                            url: SERVICE_BASE + '/rest/dashboard/getSidebars',
                            method: 'GET',
                            params: { ulpid: user }
                        }).then(function (response) {
                            angular.copy(response.data, $scope.siteMenu);
                            //console.log(response.data)
                        }, function (response) {
                            alert(response.data);
                        });
                }

                $scope.showMenu = true;               
                $scope.isVertical = true;
                $scope.openMenuScope = null;
                $scope.allowHorizontalToogle = false;
                $scope.loadingMenu = true;
                $scope.siteMenu = [];               

               //sidebarService.getSidebar();             
                
              
                }         
              

                this.getActiveElement = function () {
                    return $scope.activeElement;
                };

                this.setActiveElement = function (el) {
                    $scope.activeElement = el;
                };

                this.isVertical = function () {
                    return $scope.isVertical;
                };

                this.setRoute = function (route) {
                    $rootScope.$broadcast('ps-menu-item-selected-event',
                        { route: route });
                };

                this.setOpenMenuScope = function (scope) {
                    $scope.openMenuScope = scope;
                };

                this.setCloseMenuScope = function (scope) {
                    $scope.closeMenuScope = scope;
                };                   
             

                $scope.toggleMenuOrientation = function () {
                    if ($scope.openMenuScope)
                        $scope.openMenuScope.closeMenu();

                    $scope.isVertical = !$scope.isVertical;

                    $rootScope.$broadcast('ps-menu-orientation-changed-event',
                     { isMenuVertical: $scope.isVertical });
                };


                // ==========================
                // 
                //  Hiding pop-up after click outside pop-up
                //
                //============================

                angular.element(document).bind('click', function (e) {
                    if ($scope.openMenuScope && !$scope.isVertical) {
                        if ($(e.target).parent().hasClass('ps-selectable-item'))
                            $scope.openMenuScope.closeMenu();
                        return;


                        $scope.$apply(function () {
                            $scope.openMenuScope.closeMenu();

                        });
                        e.preventDefault();
                        e.stopPropagation();
                    }

                });

                // ==========================
                // 
                //  Hiding menu after MenuButton Clicked
                //
                //============================
                $scope.$on('ps-menu-show', function (evt, data) {
                    $scope.showMenu = data.show;                  
                    $scope.isVertical = data.isVertical;
                    $scope.allowHorizontalToogle = !data.allowHorizontalToogle;

                    $rootScope.$broadcast('ps-menu-orientation-changed-event',
                      { isMenuVertical: $scope.isVertical }

                      );
                });             
               
            }
        ]);