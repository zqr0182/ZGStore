var adminServices = angular.module('adminServices', ['ngResource']);

adminServices.factory('ProdService', ['$resource', function ($resource) {
    return {
        products: $resource('product/list/:filterByStatus', {}, {}),
        product: $resource('product/edit/:id', {}, {}),
        deactivateProduct: $resource('product/deactivate/:id', {}, {}),
        activateProduct: $resource('product/activate', {}, {}),
        productImage: $resource('product/deleteimage/:imageName/:id', {}, {}),
        prodIdNames: $resource('product/GetProductIdNames', {}, {})
    };
}]);

adminServices.factory('ProdCategoryService', ['$resource', function ($resource) {
    return {
        categories: $resource('productcategory/list/:filterByStatus', {}, {}),
        categoryIdNames: $resource('productcategory/GetActiveCategoryIdNames', {}, {}),
        categoryEdit: $resource('productcategory/edit/:id', {}, {}),
        categoryCreate: $resource('productcategory/create', {}, {}),
        deactivateCategory: $resource('productcategory/deactivate/:id', {}, {}),
        activateCategory: $resource('productcategory/activate', {}, {}),
    };
}]);

adminServices.factory('SupplierService', ['$resource', function ($resource) {
    return {
        supplier: $resource('supplier/GetSuppliers/:filterByStatus', {}, {}),
        supplierIdNames: $resource('supplier/GetSupplierIdNames/:filterByStatus', {}, {}),
        supplierEdit: $resource('supplier/edit/:id', {}, {}),
        supplierCreate: $resource('supplier/create', {}, {}),
        deactivateSupplier: $resource('supplier/deactivate/:id', {}, {}),
        activateSupplier: $resource('supplier/activate', {}, {}),
    };
}]);

adminServices.factory('CountryService', ['$resource', function ($resource) {
    return {
        countryIdNamesOfCanadaChina: $resource('country/GetCanadaChina', {}, {}),
        countryIdNames: $resource('country/GetCountryIdNames', {}, {})
    };
}]);

adminServices.factory('StateService', ['$resource', function ($resource) {
    return {
        stateIdNames: $resource('state/GetStateIdNames', {}, {})
    };
}]);

adminServices.factory('ShippingProviderService', ['$resource', function ($resource) {
    return {
        get: $resource('shippingProvider/GetShippingProviders', {}, {}),
        save: $resource('shippingProvider/save', {}, {}),
        shippingProviderIdNames: $resource('shippingProvider/GetShippingProviderIdNames', {}, {})
    };
}]);

adminServices.factory('ProvinceService', ['$resource', function ($resource) {
    return {
        get: $resource('province/GetProvinces/:countryId', {}, {}),
        save: $resource('province/save', {}, {}),
        provinceIdNames: $resource('province/GetProvinceIdNames/:countryId', {}, {})
    };
}]);

adminServices.factory('ShippingService', ['$resource', function ($resource) {
    return {
        get: $resource('shipping/GetShippings/:countryId', {}, {}),
        save: $resource('shipping/save', {}, {})
    };
}]);

adminServices.factory('TaxService', ['$resource', function ($resource) {
    return {
        get: $resource('tax/GetTaxes/:countryId', {}, {}),
        save: $resource('tax/save', {}, {})
    };
}]);

adminServices.factory('UserService', ['$resource', function ($resource) {
    return {
        get: $resource('user/list/:filterByStatus', {}, {}),
        save: $resource('user/save/:filterByStatus', {}, {})
    };
}]);

adminServices.factory('OrderService', ['$resource', function ($resource) {
    return {
        orders: $resource('order/list/:filterByStatus', {}, {}),
        //product: $resource('product/edit/:id', {}, {}),
        deactivateOrder: $resource('order/deactivate/:id', {}, {}),
        activateOrder: $resource('order/activate', {}, {})
    };
}]);

adminServices.factory('CacheService', ['$cacheFactory', function ($cacheFactory) {
    return {
        keys: [],
        cache: $cacheFactory('storeAdminCache'),
        put: function (key, value) {
            this.cache.put(key, value);
            this.keys.push(key);
        }
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
            if (array) {
                var results = array.filter(function (item) {
                    return item.Id == id;
                });

                if (results != null) {
                    return results[0];
                }
            }

            return null;
        },
        changeStatusHelper: function (isActivation, model, arrayOfId, serverResult)
        {
            if (serverResult.Success) {
                model.Active = isActivation ? true : false;
                var index = arrayOfId.indexOf(model.Id);
                if (index > -1) {
                    arrayOfId.splice(index, 1);
                }
            }
            else {
                arrayOfId.push(model.Id);
            }
        },
        isItemFound: function (array, item) {
            return array.indexOf(item) > -1;
        },
        regExpPattern: function(){
            return {
                email: /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/,
                phone: /((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}/,
                zip: /\d{5}(-\d{4})?/,
                decimal: /^\d+(\.\d{1,2})?$/,
                fourDigit: /^\d{1,4}$/,
                tenDigit: /^\d{1,10}$/
            };
        },
        removeFromArray: function(array, item)
        {
            var index = array.indexOf(item);
            array.splice(index, 1);
        }
    };
}]);