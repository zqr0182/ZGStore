angular.module('storeAdminControllers').controller('SupplierListCtrl', ['$scope', '$location', 'SupplierService', 'CommonFunctions',
  function ($scope, $location, SupplierService, CommonFunctions) {
      $scope.filterByStatus = 'active';
      $scope.getSuppliers = function () {
          $scope.suppliers = SupplierService.supplier.query({ filterByStatus: $scope.filterByStatus });
      }
      $scope.getSuppliers();

      $scope.go = function (path) {
          $location.path(path);
      }

      $scope.failedDeactivations = [];
      $scope.deactivateSupplier = function (sup)
      {
          if (window.confirm('Are you sure you want to inactivate this supplier?'))
          {
              SupplierService.deactivateSupplier.remove({ id: sup.Id }, {}, function (value, responseHeaders) {
                  CommonFunctions.changeStatusHelper(false, sup, $scope.failedDeactivations, value);
              });
          }
      }
      
      $scope.isDeactivationFailed = function (id) {
          return CommonFunctions.isItemFound($scope.failedDeactivations, id);
      }

      $scope.failedActivations = [];
      $scope.activateSupplier = function (sup) {
          SupplierService.activateSupplier.save({}, { id: sup.Id }, function (value, responseHeaders) {
              CommonFunctions.changeStatusHelper(true, sup, $scope.failedActivations, value);
          });
      }

      $scope.isActivationFailed = function (id) {
          return CommonFunctions.isItemFound($scope.failedActivations, id);
      }
  }]);