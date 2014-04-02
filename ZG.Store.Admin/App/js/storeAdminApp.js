/// <reference path="../scripts/angular.js" />

var adminApp = angular.module('storeAdminApp', ['ngRoute', 'storeAdminControllers', 'prodAdminServices', 'angularFileUpload']);

adminApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/product/edit/:prodId', { templateUrl: 'app/partials/Edit.html', controller: 'EditProductCtrl' })
    .when('/product', { templateUrl: 'app/partials/list.html', controller: 'ProductListCtrl' })
    .otherwise({ redirectTo: '/product' });
}]);

