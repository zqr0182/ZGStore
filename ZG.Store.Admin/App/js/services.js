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
        categoryIdNames: $resource('productcategory/GetActiveCategoryIdNames', {}, {}),
        categoryEdit: $resource('productcategory/edit/:catId', {}, {}),
        categoryCreate: $resource('productcategory/create', {}, {}),
        deactivateCategory: $resource('productcategory/deactivate/:catId', {}, {}),
        activateCategory: $resource('productcategory/activate', {}, {}),
    };
}]);

adminServices.factory('SupplierService', ['$resource', function ($resource) {
    return {
        supplier: $resource('supplier/GetSuppliers/:filterByStatus', {}, {}),
        supplierIdNames: $resource('supplier/GetSupplierIdNames/:filterByStatus', {}, {}),
        supplierEdit: $resource('supplier/edit/:supId', {}, {}),
        supplierCreate: $resource('supplier/create', {}, {}),
        deactivateSupplier: $resource('supplier/deactivate/:id', {}, {}),
        activateSupplier: $resource('supplier/activate', {}, {}),
    };
}]);

adminServices.factory('CommonFunctions', [function () {
    return {
        getArrayById: function (array1, array2) {
            var result = [];

            array1.forEach(function (item1) {
                array2.forEach(function (item2) {
                    if (item1.Id == item2.Id) {
                        result.push(item2);
                    }
                });
            });

            return result;
        },
        getItemById: function (id, array) {
            var results = array.filter(function (item) {
                return item.Id == id;
            });

            if(results != null)
            {
                return results[0];
            }

            return null;
        },
        sum: function(val1, val2)
        {
            return val1 + val2;
        }
    };
}]);