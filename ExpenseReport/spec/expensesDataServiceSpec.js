describe("expenses Data Service", function () {

    beforeEach(module('app'));

    it('should return three expense items', inject(function (expensesDataService) {
        expect(expensesDataService.getexpenses().length).toBe(3);
    }));

    it('should return a taxi expense item', inject(function (expensesDataService) {
        var expenseItems = expensesDataService.getexpenses();
        var testexpenseItem = new ExpenseItem('TAXI1', 'test1', 991.00);
        expect(expenseItems).toContain(testexpenseItem);
    }));

    describe("reasonable expenses", function () {
        var taxi;
        var dinner;

        beforeEach(function () {
            jasmine.addMatchers(customMatchers);
        });

        beforeEach(function () {
            taxi = new ExpenseItem('TAXI1', 'test1', 9.00);
            dinner = new ExpenseItem('TAXI2', 'test2', 559.00);
        });

        it('taxi should be a reasonable expense item', function () {
            expect(taxi).toBeAReasonableExpense();
        });
        it('dinner should not be a reasonable expense item', function () {
            expect(dinner).not.toBeAReasonableExpense();
        });

    });

});