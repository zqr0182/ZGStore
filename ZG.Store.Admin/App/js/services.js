var prodAdminServices = angular.module('prodAdminServices', ['ngResource']);

prodAdminServices.factory('ProdService', ['$resource', function ($resource) {
    //return $resource('product/list', {}, {});
    return {
        products: $resource('product/list', {}, {}),
        product: $resource('product/edit/:prodId', {}, {})
    };
}]);