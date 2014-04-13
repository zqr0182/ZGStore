var adminServices = angular.module('adminServices', ['ngResource']);

adminServices.factory('ProdService', ['$resource', function ($resource) {
    return {
        products: $resource('product/list/:filterByStatus', {}, {}),
        product: $resource('product/edit/:prodId', {}, {}),
        deactivateProduct: $resource('product/deactivate/:prodId', {}, {}),
        activateProduct: $resource('product/activate', {}, {}),
        productImage: $resource('product/deleteimage/:imageName/:prodId', {}, {})
    };
}]);

adminServices.factory('ProdCategoryService', ['$resource', function ($resource) {
    return {
        categories: $resource('productcategory/list/:filterByStatus', {}, {}),
        category: $resource('productcategory/edit/:catId', {}, {}),
        deactivateCategory: $resource('productcategory/deactivate/:catId', {}, {}),
        activateCategory: $resource('productcategory/activate', {}, {}),
    };
}]);