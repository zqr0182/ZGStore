/// <reference path="../scripts/angular.js" />

var adminApp = angular.module('storeAdminApp', ['ngRoute', 'storeAdminControllers']);

adminApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/products/:productId', { templateUrl: 'Views/Product/Create.cshtml', controller: 'CreateProductCtrl' })
    .when('/products', { templateUrl: 'Views/Product/List.cshtml', controller: 'ProductListCtrl' })
    .otherwise({ redirectTo: '/products' });
}]);

