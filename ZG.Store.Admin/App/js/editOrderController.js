angular.module('storeAdminControllers').controller('EditOrderCtrl', ['$scope', '$routeParams', 'OrderService', 'OrderStatusService', 'ShippingProviderService', 'CommonFunctions',
    function ($scope, $routeParams, OrderService, OrderStatusService, ShippingProviderService, CommonFunctions) {
        $scope.order = OrderService.order.get({ id: $routeParams.id });
        $scope.allOrderStatus = OrderStatusService.statusIdNames.query();
        $scope.allShippingProviders = ShippingProviderService.shippingProviderIdNames.query();

}]);