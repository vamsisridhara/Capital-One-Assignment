(function () {
    'use strict';
    var commuteService = angular.module('commuteService', []);
    commuteService.factory('commuteServiceFactory',
        ['$http',
        function ($http) {
            var service = {
                getServiceStatus: getServiceStatus,
                getddlLines: getddlLines,
                gettrains: gettrains,
                getstations: getstations,
                getnexttrain: getnexttrain
            };
            return service;

            function getServiceStatus() {
                return $http({
                    method: 'GET',
                    url: '/commute/getServiceStatus'
                });
            }

            function getddlLines() {
                return $http({
                    method: 'GET',
                    url: '/commute/getlines'
                });
            }

            function gettrains(newVal) {
                return $http({
                    method: 'GET',
                    url: '/commute/gettrains/' + newVal
                });

            }

            function getstations() {
                return $http({
                    method: 'GET',
                    url: '/commute/getstationnames'
                });
            }

            function getnexttrain(newVal) {
                return $http({
                    method: 'GET',
                    url: '/commute/getnexttrains/' + newVal
                });
            }

        }
        ]);
})();