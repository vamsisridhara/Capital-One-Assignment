(function () {
    'use strict';
    var app = angular.module("commuteCtrl", ['commuteService']);
    app.controller("commuteController",
        ["$scope", "commuteServiceFactory", function ($scope, commuteServiceFactory) {
            $scope.trains = [];
            $scope.stations = [];

            $scope.linename = '';
            $scope.nexttrain = '';

            $scope.GetServiceStatus = function () {
                commuteServiceFactory.getServiceStatus().then(function success(response) {
                    $scope.serviceStatus = response.data;
                });
            }
            $scope.GetddlLines = function () {
                commuteServiceFactory.getddlLines().then(function success(response) {
                    $scope.ddlLines = response.data;
                });
            }

        }]);
}());