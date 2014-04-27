angular.module('storeAdminControllers').controller('ShippingProviderListCtrl', ['$scope', '$location', 'ShippingProviderService', 'CommonFunctions',
  function ($scope, $location, ShippingProviderService, CommonFunctions) {
      $scope.filterByStatus = 'active';
      $scope.getShippingProviders = function () {
          $scope.shippingProviders = ShippingProviderService.shippingProvider.query({ filterByStatus: $scope.filterByStatus }, function (data) {
              var result = data;
          });
      }
      $scope.getShippingProviders();

      $scope.go = function (path) {
          $location.path(path);
      }

      $scope.failedDeactivations = [];
      $scope.deactivateShippingProvider = function (sp)
      {
          if (window.confirm('Are you sure you want to inactivate this shipping provider?'))
          {
              ShippingProviderService.deactivateShippingProvider.remove({ id: sp.Id }, {}, function (value, responseHeaders) {
                  CommonFunctions.changeStatusHelper(false, sp, $scope.failedDeactivations, value);
              });
          }
      }
      
      $scope.isDeactivationFailed = function (id) {
          return CommonFunctions.isItemFound($scope.failedDeactivations, id);
      }

      $scope.failedActivations = [];
      $scope.activateShippingProvider = function (sp) {
          ShippingProviderService.activateShippingProvider.save({}, { id: sp.Id }, function (value, responseHeaders) {
              CommonFunctions.changeStatusHelper(true, sp, $scope.failedActivations, value);
          });
      }

      $scope.isActivationFailed = function (id) {
          return CommonFunctions.isItemFound($scope.failedActivations, id);
      }
  }]);