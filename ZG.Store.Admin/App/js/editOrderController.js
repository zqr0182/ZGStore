angular.module('storeAdminControllers').controller('EditOrderCtrl', ['$scope', '$routeParams', 'OrderService', 'OrderStatusService', 'CommonFunctions',
    function ($scope, $routeParams, OrderService, OrderStatusService, CommonFunctions) {
        $scope.order = OrderService.order.get({ id: $routeParams.id });
        $scope.allOrderStatus = OrderStatusService.statusIdNames.query();

}]);