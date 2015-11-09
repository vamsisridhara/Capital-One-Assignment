(function () {
    'use strict';
    var app = angular.module('gffiAdminApp', ['gffiAdminService']);
    app.controller("gffiAdminController",
        ["$scope", "gffiAdminServiceFactory",
            function ($scope, gffiAdminServiceFactory) {
            $scope.lobs = [];
            $scope.selectedLob = '';
            $scope.sivalue = '';
            $scope.getLob = function () {
                gffiAdminServiceFactory.getLob().then(function success(response) {
                    //$scope.lobs = response.data;
                    if(angular.isDefined(response.data) && angular.isArray(response.data)){
                        angular.forEach(response.data, function (value, key) {
                            $scope.lobs.push(value.LobName);
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
            
            $scope.drivers = [];

            $scope.addDriver = function (driver) {
                $scope.drivers.push(driver.driverName);
                console.log($scope.drivers.length);
            };


            $scope.getLob();
        }]);
}());