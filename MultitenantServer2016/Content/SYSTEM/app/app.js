(function () {
    'use strict';

    angular.module('gmsManagement', [
        // Angular modules 
        'common.core',
        'common.ui',
        'tms.login'
      
        // Custom modules 

        // 3rd Party Modules

    ]).config(function ($routeProvider, authProvider, $httpProvider, jwtInterceptorProvider) {

        $routeProvider.when('/', {
            redirectTo: "/dashboard",
            requires: 'login'

        }).when('/login', {
            controller: "loginController",
            templateUrl: "Content/SYSTEM/app/login/loginTemplate.html"

        }).when('/dashboard', {
           
            template: '<tms-dashboard></tms-dashboard>'

        }).otherwise({ redirectTo: "/dashboard" });

        authProvider.init({
            domain: AUTH0_DOMAIN,
            clientID: AUTH0_CLIENT_ID,
            loginUrl: '/login'
        });

        var refreshingToken = null;

        jwtInterceptorProvider.tokenGetter = function (sessionStorage, auth, jwtHelper) {
            var token = sessionStorage.get('accessToken');
            var refreshToken = sessionStorage.get('refreshToken');
            if (token) {

                if (!jwtHelper.isTokenExpired(token)) {
                    return sessionStorage.get('accessToken');
                } else {
                    if (refreshingToken === null) {
                        refreshingToken = auth.refreshIdToken(refreshToken).then(function (idToken) {
                            sessionStorage.set('accessToken', idToken);
                            return idToken;

                        }).finally(function () {
                            refreshingToken = null;
                        });
                    }
                    return refreshingToken;
                }
            }
        }

        $httpProvider.interceptors.push('jwtInterceptor');


        authProvider.on('loginSuccess', function ($location, $http, profilePromise, idToken, sessionStorage, localStorage) {
                         

            profilePromise.then(function (profile) {
             
                sessionStorage.remove('profile', profile);
                //localStorage.remove('members', members);
                //localStorage.remove('sidebars', sidebars);
                //localStorage.remove('actionbars', actionbars);


                sessionStorage.set('uid', profile.user_id);
                sessionStorage.set('accessToken', idToken);
                window.sessionStorage['profile'] = angular.toJson(profile);


                window.location.replace("/dashboard");

            });
            $location.path('/');
        });

        authProvider.on('loginFailure', function () {
            alert("Error");
        });

        authProvider.on('authenticated', function ($location) {
            console.log("Authenticated");
        });

    })

    .run(function ($rootScope, auth, localStorage, sessionStorage, jwtHelper, $location) {

        var refreshingToken = null;

        $rootScope.$on('$locationChangeStart', function () {

            var token = sessionStorage.get('accessToken');
            var refreshToken = sessionStorage.get('refreshToken');

            if (token) {
                if (!jwtHelper.isTokenExpired(token)) {
                    console.log("Token OK");
                    if (!auth.isAuthenticated) {
                        auth.authenticate(localStorage.get('profile'), token);
                        console.log("User OK");
                    }
                } else {

                    if (refreshToken) {
                        if (refreshingToken === null) {
                            console.log("Refreshing");
                            refreshingToken = auth.refreshIdToken(refreshToken).then(function (idToken) {
                                sessionStorage.set('accessToken', idToken);
                                auth.authenticate(localStorage.get('profile'), idToken);
                            }).finally(function () {
                                console.log("Refreshing Finished");
                                refreshingToken = null;
                            });
                        }

                        return refreshingToken;

                    } else {
                        $location.path('/login');
                    }
                }
            } else if (!token) {
                $location.path('/login');
            }

        });

        auth.hookEvents();
    });
})();