(function () {
    'use strict';
    var gffiAdminService = angular.module('gffiAdminService', []);
    gffiAdminService.factory('gffiAdminServiceFactory',
        ['$http',
        function ($http) {
            var service = {
                getLob: getLob
            };
            return service;

            function getLob() {
                return $http({
                    method: 'GET',
                    url: '/gffiadmin/getlob'
                });
            }
        }
        ]);
})();