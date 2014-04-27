﻿/// <reference path="../scripts/angular.js" />

var adminApp = angular.module('storeAdminApp', ['ngRoute', 'storeAdminControllers', 'adminServices', 'angularFileUpload']);

adminApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
    .when('/product/create', { templateUrl: 'app/partials/productEdit.html', controller: 'EditProductCtrl' })
    .when('/product/edit/:prodId', { templateUrl: 'app/partials/productEdit.html', controller: 'EditProductCtrl' })
    .when('/product', { templateUrl: 'app/partials/productlist.html', controller: 'ProductListCtrl' })
    .when('/productcategory/edit/:catId', { templateUrl: 'app/partials/productCategoryEdit.html', controller: 'EditProductCategoryCtrl' })
    .when('/productcategory/create', { templateUrl: 'app/partials/productCategoryEdit.html', controller: 'EditProductCategoryCtrl' })
    .when('/productcategory', { templateUrl: 'app/partials/productCategoryList.html', controller: 'ProductCategoryListCtrl' })
    .when('/supplier/edit/:id', { templateUrl: 'app/partials/SupplierEdit.html', controller: 'EditSupplierCtrl' })
    .when('/supplier/create', { templateUrl: 'app/partials/SupplierEdit.html', controller: 'EditSupplierCtrl' })
    .when('/supplier', { templateUrl: 'app/partials/supplierlist.html', controller: 'SupplierListCtrl' })
    .when('/home', { templateUrl: 'app/partials/home.html', controller: '' })
    .otherwise({ redirectTo: '/home' });
}]);

