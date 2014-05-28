angular.module('storeAdminControllers').controller('OrderListCtrl', ['$scope', '$location', 'OrderService', 'CommonFunctions',
  function ($scope, $location, OrderService, CommonFunctions) {
      $scope.filterByStatus = 'active';
      $scope.getOrders = function () {
          $scope.orders = OrderService.orders.get({ filterByStatus: $scope.filterByStatus });
      }
      $scope.getOrders();

      $scope.go = function (path) {
          $location.path(path);
      }

      $scope.failedDeactivations = [];
      $scope.deactivateOrder = function (order)
      {
          if (window.confirm('Are you sure you want to inactivate this order?'))
          {
              OrderService.deactivateOrder.remove({ id: order.Id }, {}, function (value, responseHeaders) {
                  CommonFunctions.changeStatusHelper(false, order, $scope.failedDeactivations, value);
              });
          }
      }
      
      $scope.isDeactivationFailed = function (id) {
          return CommonFunctions.isItemFound($scope.failedDeactivations, id);
      }

      $scope.failedActivations = [];
      $scope.activateOrder = function (order) {
          OrderService.activateOrder.save({}, { id: order.Id }, function (value, responseHeaders) {
              CommonFunctions.changeStatusHelper(true, order, $scope.failedActivations, value);
              });
      }

      $scope.isActivationFailed = function (id) {
          return CommonFunctions.isItemFound($scope.failedActivations, id);
      }
  }]);