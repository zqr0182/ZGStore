/// <reference path="../scripts/angular.js" />

var adminApp = angular.module('storeAdminApp', ['ngRoute', 'storeAdminControllers', 'adminServices', 'angularFileUpload']);

adminApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
    .when('/product/edit/:prodId', { templateUrl: 'app/partials/productEdit.html', controller: 'EditProductCtrl' })
    .when('/product', { templateUrl: 'app/partials/productlist.html', controller: 'ProductListCtrl' })
    .when('/productcategory/edit/:catId', { templateUrl: 'app/partials/categoryEdit.html', controller: 'EditProductCategoryCtrl' })
    .when('/productcategory', { templateUrl: 'app/partials/categorylist.html', controller: 'ProductCategoryListCtrl' })
    .when('/home', { templateUrl: 'app/partials/home.html', controller: '' })
    .otherwise({ redirectTo: '/home' });
}]);

