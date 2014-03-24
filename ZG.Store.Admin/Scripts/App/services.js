var prodAdminServices = angular.module('prodAdminServices', ['ngResource']);

prodAdminServices.factory('ProdService', ['$resource', function ($resource) {
    return $resource('product/list', {});
}]);