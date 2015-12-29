((function () {
    'use strict';
    var app = angular.module('productResourceMock', ['ngMockE2E']);
    app.run(function ($httpBackend) {
        var products = [
            {
                productID: 1,
                imageURL: '',
                productName: 'Leaf Rake',
                productCode: 'Tissues',
                productDate: 'May 24 1980',
                price: 20.95
            },
            {
                productID: 2,
                imageURL: '',
                productName: 'Hammer',
                productCode: 'GDN-100',
                productDate: 'March 19 2009',
                price: 19.95
            },
            {
                productID: 3,
                imageURL: '',
                productName: 'Hammer',
                productCode: 'GDN-100',
                productDate: 'March 19 2009',
                price: 19.95
            },
            {
                productID: 4,
                imageURL: '',
                productName: 'Hammer',
                productCode: 'GDN-100',
                productDate: 'March 19 2009',
                price: 19.95
            }
        ];
        var productURL = '/api/products';
        $httpBackend.whenGET(productURL).respond(products);

        var regex = new RegExp(productURL + '/[0-9][0-9]*', '');
        $httpBackend.whenGET(regex).respond(function (method, url, data) {
            var product = { productID: 0 };
            var params = url.split('/');
            var id = params[params.length - 1];
            if (id > 0) {
                for (var i = 0; i < products.length ; i++) {
                    if (products[i].productID == id) {
                        product = products[i]; break;
                    }
                }
            }
            return [200, product, {}];
        });

        $httpBackend.whenPOST(productURL).respond(function (method, url, data) {
            var product = angular.fromJson(data);
            if (!product.productID) {
                product.productID = products[products.length - 1].productID + 1;
                products.push(product);
            } else {
                for (var i = 0; i < products.length ; i++) {
                    if (products[i].productID == product.productID) {
                        products[i] = product;
                        break;
                    }
                }
            }
            return [200, product, {}];
        });

        //$httpBackend.whenGET('/app/').passThrough();

    });
})());