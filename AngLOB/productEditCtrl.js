((function () {
    'use strict';
    angular.module('exampleApp')
        .controller('productEditCtrl',
                ['product','$state', productEditCtrl]);
    function productEditCtrl(product, $state) {
        var vm = this;
        vm.product = product;
        if (vm.product && vm.product.productID) {
            vm.title = 'Edit:' + vm.product.productName;
        } else {
            vm.title = 'New Product';
        }
        vm.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();
            vm.opened = !vm.opened;
        };

        vm.submit = function () {
            vm.product.$save(function (data) {
                toastr.success('save done!');
            });
        };
        
        vm.cancel = function () {
            $state.go('productList');
        };

        vm.addTags = function (tags) {
            if (tags) {
                var array = tags.split(',');
                vm.product.tags = vm.product.tags ? vm.product.tags.concat(array) : array;
                vm.newTags = '';
            } else {
                alert('enter tags');
            }
        };
        vm.removeTag = function (index) {
            vm.product.tags.splice(index, 1);
        };
    }
})());