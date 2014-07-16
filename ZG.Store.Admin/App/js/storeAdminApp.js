/// <reference path="../scripts/angular.js" />

var adminApp = angular.module('storeAdminApp', ['ngRoute', 'storeAdminControllers', 'adminServices', 'angularFileUpload', 'bootstrapLightbox']);

adminApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
    .when('/product/create', { templateUrl: 'app/partials/productEdit.html', controller: 'EditProductCtrl' })
    .when('/product/edit/:id', { templateUrl: 'app/partials/productEdit.html', controller: 'EditProductCtrl' })
    .when('/product', { templateUrl: 'app/partials/productlist.html', controller: 'ProductListCtrl' })
    .when('/productcategory/edit/:id', { templateUrl: 'app/partials/productCategoryEdit.html', controller: 'EditProductCategoryCtrl' })
    .when('/productcategory/create', { templateUrl: 'app/partials/productCategoryEdit.html', controller: 'EditProductCategoryCtrl' })
    .when('/productcategory', { templateUrl: 'app/partials/productCategoryList.html', controller: 'ProductCategoryListCtrl' })
    .when('/supplier/edit/:id', { templateUrl: 'app/partials/SupplierEdit.html', controller: 'EditSupplierCtrl' })
    .when('/supplier/create', { templateUrl: 'app/partials/SupplierEdit.html', controller: 'EditSupplierCtrl' })
    .when('/supplier', { templateUrl: 'app/partials/supplierlist.html', controller: 'SupplierListCtrl' })
    .when('/shippingprovider', { templateUrl: 'app/partials/ShippingProviderlist.html', controller: 'ShippingProviderListCtrl' })
    .when('/province', { templateUrl: 'app/partials/ProvinceList.html', controller: 'ProvinceListCtrl' })
    .when('/shipping', { templateUrl: 'app/partials/ShippingList.html', controller: 'ShippingListCtrl' })
    .when('/tax', { templateUrl: 'app/partials/TaxList.html', controller: 'TaxListCtrl' })
    .when('/user', { templateUrl: 'app/partials/UserList.html', controller: 'UserListCtrl' })
    .when('/order', { templateUrl: 'app/partials/orderlist.html', controller: 'OrderListCtrl' })
    .when('/order/edit/:id', { templateUrl: 'app/partials/orderEdit.html', controller: 'EditOrderCtrl' })
    .when('/home', { templateUrl: 'app/partials/home.html', controller: '' })
    .otherwise({ redirectTo: '/home' });
}]);

adminApp.config(function (LightboxProvider) {
    // set a custom template
    //LightboxProvider.templateUrl = 'lightbox.html';

    /**
     * Calculate the max and min limits to the width and height of the displayed
     *   image (all are optional). The max dimensions override the min
     *   dimensions if they conflict.
     * @param  {Object} dimensions Contains the properties windowWidth,
     *   windowHeight, imageWidth, imageHeight.
     * @return {Object} May optionally contain the properties minWidth,
     *   minHeight, maxWidth, maxHeight.
     */
    LightboxProvider.calculateImageDimensionLimits = function (dimensions) {
        return {
            'minWidth': 100,
            'minHeight': 100,
            'maxWidth': dimensions.windowWidth - 102,
            'maxHeight': dimensions.windowHeight - 136
        };
    };

    /**
     * Calculate the width and height of the modal. This method gets called
     *   after the width and height of the image, as displayed inside the modal,
     *   are calculated. See the default method for cases where the width or
     *   height are 'auto'.
     * @param  {Object} dimensions Contains the properties windowWidth,
     *   windowHeight, imageDisplayWidth, imageDisplayHeight.
     * @return {Object} Must contain the properties width and height.
     */
    LightboxProvider.calculateModalDimensions = function (dimensions) {
        return {
            'width': Math.max(500, dimensions.imageDisplayWidth + 42),
            'height': Math.max(500, dimensions.imageDisplayHeight + 76)
        };
    };
});

