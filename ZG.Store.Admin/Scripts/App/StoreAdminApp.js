//var phonecatApp = angular.module('phonecatApp', [
//  'ngRoute',
//  'phonecatControllers'
//]);

//phonecatApp.config(['$routeProvider',
//  function ($routeProvider) {
//      $routeProvider.
//        when('/phones', {
//            templateUrl: 'partials/phone-list.html',
//            controller: 'PhoneListCtrl'
//        }).
//        when('/phones/:phoneId', {
//            templateUrl: 'partials/phone-detail.html',
//            controller: 'PhoneDetailCtrl'
//        }).
//        otherwise({
//            redirectTo: '/phones'
//        });
//  }]);

/// <reference path="../scripts/angular.js" />

var adminApp = angular.module('storeAdminApp', ['ngRoute', 'storeAdminControllers']);

adminApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/???', { templateUrl: '', controller: '' })
    .when('/???', { templateUrl: '', controller: '' })
    .otherwise({ redirectTo: '/???' });
}]);