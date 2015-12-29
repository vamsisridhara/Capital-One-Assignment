(function () {
    "use strict";
    var app = angular.module("app", ['ngRoute']);
    app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/', { templateUrl: '/expense.html' })
            .when('/admin', { templateUrl: '/admin.html' })
            .otherwise({ redirectTo: '/' })
    }]);
}());