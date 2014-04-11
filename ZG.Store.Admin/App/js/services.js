var prodAdminServices = angular.module('prodAdminServices', ['ngResource']);

prodAdminServices.factory('ProdService', ['$resource', function ($resource) {
    return {
        products: $resource('product/list/:filterByStatus', {}, {}),
        product: $resource('product/edit/:prodId', {}, {}),
        deactivateProduct: $resource('product/deactivate/:prodId', {}, {}),
        activateProduct: $resource('product/activate', {}, {}),
        productImage: $resource('product/deleteimage/:imageName/:prodId', {}, {})
    };
}]);