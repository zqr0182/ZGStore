var prodAdminServices = angular.module('prodAdminServices', ['ngResource']);

prodAdminServices.factory('ProdService', ['$resource', function ($resource) {
    return {
        products: $resource('product/list', {}, {}),
        product: $resource('product/edit/:prodId', {}, {})
    };
}]);