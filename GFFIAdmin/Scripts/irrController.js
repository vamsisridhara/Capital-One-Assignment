(function () {
    'use strict';
    var app = angular.module('gffiAdminApp', ['gffiAdminService']);
    app.controller("irrController",
        ["$scope", "gffiAdminServiceFactory",
            function ($scope, gffiAdminServiceFactory) {
                $scope.ports = [];
                $scope.getPortfolios = function () {
                    $("#spinner").show();
                    gffiAdminServiceFactory.getPortfolios().then(function success(response) {
                        if (angular.isDefined(response.data) && angular.isArray(response.data)) {
                            angular.forEach(response.data, function (value, key) {
                                $scope.ports.push(value);
                                $("#spinner").hide();
                            });
                        }
                    });
                };
                $scope.deletePort = function (id) {

                    gffiAdminServiceFactory.deletePortfolio(id).then(function success(response) {
                        if (angular.isDefined(response.data) && angular.isArray(response.data)) {
                            $scope.ports = [];
                            angular.forEach(response.data, function (value, key) {
                                $scope.ports.push(value);
                            });
                        }
                    });
                }

                $scope.getPortfolios();
            }]);
}());