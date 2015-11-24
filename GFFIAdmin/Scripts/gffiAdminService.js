(function () {
    'use strict';
    var gffiAdminService = angular.module('gffiAdminService', []);
    gffiAdminService.factory('gffiAdminServiceFactory',
        ['$http','$q',
        function ($http,$q) {
            var service = {
                getLob: getLob,
                getPortfolios: getPortfolios,
                deletePortfolio : deletePortfolio
            };
            return service;

            function getPortfolios() {
                var defer = $q.defer();
                $http({
                    method: 'GET',
                    url: '/gffiadmin/getportfolios'
                }).then(function (data) {
                    defer.resolve(data);
                });
                return defer.promise;
            }

            function deletePortfolio(id) {
                var defer = $q.defer();
                $http({
                    method: 'DELETE',
                    url: '/gffiadmin/deleteportfolio/' + id
                }).then(function (data) {
                    defer.resolve(data);
                });
                return defer.promise;
            }


            function getLob() {
                var defer = $q.defer();
                $http({
                    method: 'GET',
                    url: '/gffiadmin/getlob'
                }).then(function (data) {
                    defer.resolve(data);
                });
                return defer.promise;
            }
        }
        ]);
})();