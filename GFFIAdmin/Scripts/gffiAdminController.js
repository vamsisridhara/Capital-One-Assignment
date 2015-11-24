(function () {
    'use strict';
    var app = angular.module('gffiAdminApp', ['gffiAdminService']);
    app.controller("gffiAdminController",
        ["$scope", "gffiAdminServiceFactory",
            function ($scope, gffiAdminServiceFactory) {
                $scope.lobs = [];
                $scope.drivers = [];
                $scope.selectedLob = '';
                $scope.sivalue = '';
                $scope.getLob = function () {
                    $("#spinner").show();
                    gffiAdminServiceFactory.getLob().then(function success(response) {
                        if (angular.isDefined(response.data) && angular.isArray(response.data)) {
                            angular.forEach(response.data, function (value, key) {
                                $scope.lobs.push(value.LobName);
                                $("#spinner").hide();
                            });
                        }
                    });
                };
                $scope.getSIValue = function (newValue) {
                    switch (newValue) {
                        case 'Auto':
                            $scope.sivalue = 'Yes'; break;
                        case 'Bank Loans':
                            $scope.sivalue = 'No'; break;
                        default:
                            $scope.sivalue = 'Yes'; break;
                    }
                };


                $scope.addDriver = function (driver) {
                    $scope.drivers.push(driver.driverName);
                    console.log($scope.drivers.length);
                };


                $scope.getLob();

            }]);
}());