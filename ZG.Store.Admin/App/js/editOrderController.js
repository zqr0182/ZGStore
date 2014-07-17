angular.module('storeAdminControllers').controller('EditOrderCtrl', ['$scope', '$routeParams', 'OrderService', 'OrderStatusService', 'ShippingProviderService', 'CommonFunctions',
    function ($scope, $routeParams, OrderService, OrderStatusService, ShippingProviderService, CommonFunctions) {
        $scope.order = OrderService.order.get({ id: $routeParams.id });
        $scope.allOrderStatus = OrderStatusService.statusIdNames.query();
        $scope.allShippingProviders = ShippingProviderService.shippingProviderIdNames.query();
        $scope.alerts = [];

        $scope.saveOrder = function()
        {
            $scope.alerts = [];
            var order = { Id: $scope.order.Id, OrderStatusId: $scope.order.OrderStatusId, ShippingProviderId: $scope.order.ShippingProviderId, Active: $scope.order.Active };

            OrderService.save.save({}, order, function (data) {
                if (data.Success) {
                    $scope.alerts.push({ type: 'success', msg: 'Order saved successfully.' });
                }
                else {
                    data.Errors.forEach(function (item) {
                        $scope.alerts.push({ type: 'danger', msg: item });
                    });
                }
            }, function (error) {
                $scope.alerts.push({ type: 'danger', msg: 'Unable to update order. Please try again later.' });
            });
        }

}]);