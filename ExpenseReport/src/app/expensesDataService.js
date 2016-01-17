(function () {
    "use strict";
    angular.module("app")
            .factory("expensesDataService",
                        ['$http', expensesDataService]);

    function expensesDataService($http) {
        var service = {
            getexpenses: getexpenses,
            persistExpenses: persistExpenses
        };
        return service;
        function getexpenses() {
            return [
                 new ExpenseItem('TAXI1', 'test1', 991.00),
                 new ExpenseItem('TAXI2', 'test2', 992.00),
                 new ExpenseItem('TAXI3', 'test3', 993.00)
            ];
        }
        function reportExpenses() {

        }

        function persistExpenses(reportExpenses) {
            var success = true;
            if (success) {
                reportExpenses();
            }
        }
    }

}());