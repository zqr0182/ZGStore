angular.module('storeAdminControllers').controller('EditOrderCtrl', ['$scope', '$routeParams', 'OrderService', 'OrderStatusService', 'ShippingProviderService', 'CommonFunctions',
    function ($scope, $routeParams, OrderService, OrderStatusService, ShippingProviderService, CommonFunctions) {
        $scope.order = OrderService.order.get({ id: $routeParams.id });
        $scope.allOrderStatus = OrderStatusService.statusIdNames.query();
        $scope.allShippingProviders = ShippingProviderService.shippingProviderIdNames.query();
        $scope.isSaveSuccessful = false;
        $scope.errors = null;

        $scope.saveOrder = function()
        {
            OrderService.save.save({}, $scope.order, function (data) {
                if (data.Success) {
                    $scope.isSaveSuccessful = true;
                }
                else {
                    $scope.errors = data.Errors;
                }
            });
        }

}]);