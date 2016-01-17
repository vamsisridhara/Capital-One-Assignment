(function () {
    'use strict';
    angular.module('app')
        .controller('expensesController',
        ['expensesDataService',
            expensesController]);
    function expensesController(expensesDataService) {
        var vm = this;
        vm.expenseItems = expensesDataService.getexpenses();
    }
}());