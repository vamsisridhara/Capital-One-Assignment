(function () {
    'use strict';
    angular.module('exampleApp')
        .controller('priceAnalyticsCtrl',
                    ['$scope',
                     'products',
                     '$filter',
                     priceAnalyticsCtrl]);
    function priceAnalyticsCtrl($scope, products, $filter) {
        $scope.title = "Price Analytics";
        $scope.products = products;
        for (var count = 0; count < products.length ; count++) {
            products[count].marginPercent = 200;
            products[count].marginAmount = 200;
        }
        var orderedProductsAmount = $filter("orderBy")(products, "marginAmount");
        var filteredProductsAmount = $filter("limitTo")(orderedProductsAmount, 5);

        var chartDataAmount = [];
        for (var i = 0; i < filteredProductsAmount.length; i++) {
            chartDataAmount.push({
                x: filteredProductsAmount[i].productName,
                y: [
                    filteredProductsAmount[i].cost,
                    filteredProductsAmount[i].price,
                    filteredProductsAmount[i].marginAmount
                ]
            });
        }
        $scope.dataAmount = {
            series: ["Cost", "Price", "Margin Amount"],
            data: chartDataAmount
        };

        $scope.configAmount = {
            title: "Top $ Margin Products",
            tooltips: true,
            labels: false,
            mouseover: function () { },
            mouseout: function () { },
            click: function () { },
            legend: {
                display: true,
                position: 'right'
            }
        };



        var orderedProductsPercent = $filter("orderBy")(products, "marginPercent");
        var filteredProductsPercent = $filter("limitTo")(orderedProductsPercent, 5);
        var chartDataPercent = [];
        for (var i = 0; i < filteredProductsPercent.length ; i++) {
            chartDataPercent.push({
                x: filteredProductsPercent[i].productName,
                y: [filteredProductsPercent[i].marginPercent]
            });
        }
        $scope.dataPercent = {
            series: ["Margin %"],
            data: chartDataPercent
        };
        $scope.configPercent = {
            title: "Top % Margin Products",
            tooltips: true,
            labels: false,
            mouseover: function () { },
            mouseout: function () { },
            click: function () { },
            legend: {
                display: true,
                position: 'right'
            }
        };


    }

}());