((function () {
    'use strict';
    angular.module('exampleApp')
        .controller('productDetailCtrl',
                ['product', productDetailCtrl]);
    function productDetailCtrl(product) {
        var vm = this;
        vm.product = product;
        vm.title = 'Product Detail : ' + vm.product.productName;
        if (vm.product.tags) {
            vm.product.tagList = vm.product.tags.toString();
        }
    }
})());