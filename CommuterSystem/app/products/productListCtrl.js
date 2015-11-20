(function () {
    "use strict";
    var app = angular.module("productManagement")
                .controller("ProductListCtrl", ProductListCtrl);

    function ProductListCtrl(){
        var vm = this;
        vm.products = [
                    {
                        "productID": "1",
                        "productName": "Leaf Bake",
                        "productCode": "GDN-0011",
                        "releaseDate": "March 19 2009",
                        "description": "Leaf",
                        "cost": 9.00,
                        "price": 19.95,
                        "category": "garden",
                        "tags": ["leaf", "tool"],
                        "imageURL": "http://"
                    },
                    {
                        "productID": "5",
                        "productName": "Leaf Bake",
                        "productCode": "GDN-0011",
                        "releaseDate": "March 19 2009",
                        "description": "Leaf",
                        "cost": 9.00,
                        "price": 19.95,
                        "category": "garden",
                        "tags": ["leaf", "tool"],
                        "imageURL": "http://"

                    }

        ];

    }
})();
