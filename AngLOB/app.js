((function () {
    'use strict';
    var app = angular.module('exampleApp',
                ['ui.router',
                    'ui.mask',
                    'ui.bootstrap',
                    'common.services']);
    app.config(function ($provide) {
        $provide.decorator("$exceptionHandler", [
            "$delegate", function ($delegate) {
                return function (exception, cause) {
                    exception.message = "Please contact the helpdesk \n Message:"
                                        + exception.message;
                    $delegate(exception, cause);
                    alert(exception.message);
                };
            }
        ]);
    });
    app.config(['$stateProvider', '$urlRouterProvider',
            function ($stateProvider, $urlRouterProvider) {
                $urlRouterProvider.otherwise('/');
                $stateProvider
                    .state('home', {
                        url: '/',
                        templateUrl: 'welcomeView.html'
                    })
                    .state('productDetail', {
                        url: '/products/:productID',
                        templateUrl: 'productDetailView.html',
                        controller: 'productDetailCtrl as vm',
                        resolve: {
                            productResource: 'productResource',
                            product: function (productResource, $stateParams) {
                                var productID = $stateParams.productID;
                                return productResource.get(
                                    { productID: productID }
                                    ).$promise;
                            }
                        }
                    })
                    .state('productEdit', {
                        abstract: true,
                        url: '/products/edit/:productID',
                        templateUrl: 'productEditView.html',
                        controller: 'productEditCtrl as vm',
                        resolve: {
                            productResource: 'productResource',
                            product: function (productResource, $stateParams) {
                                var productID = $stateParams.productID;
                                return productResource.get(
                                    { productID: productID }
                                    ).$promise;
                            }
                        }
                    })
                    .state('productEdit.info', {
                        url: '/info',
                        templateUrl: 'productEditInfoView.html'
                    })
                    .state('productEdit.price', {
                        url: '/price',
                        templateUrl: 'productEditPriceView.html'
                    })
                    .state('productEdit.tags', {
                        url: '/tags',
                        templateUrl: 'productEditTagsView.html'
                    })
                    .state('productList', {
                        url: '/products',
                        templateUrl: 'productlistView.html',
                        controller: 'productListCtrl as vm'
                    })
                    .state('priceAnalytics', {
                        url: '/priceAnalytics',
                        templateUrl: 'priceAnalyticsView.html',
                        controller: 'priceAnalyticsCtrl',
                        resolve: {
                            productResource: 'productResource',
                            products: function (productResource) {
                                return productResource.query(
                                    function (response) {
                                    },
                                    function (response) {
                                        if (response.status == 404) {
                                            alert("Error accessing resource:" +
                                                response.config.method + " " +
                                                response.config.url);
                                        } else {
                                            alert(response.statusText);
                                        }
                                    }).$promise;
                            }
                        }
                    });
            }]);

})());