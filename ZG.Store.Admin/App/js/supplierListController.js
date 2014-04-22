angular.module('storeAdminControllers').controller('SupplierListCtrl', ['$scope', '$location', 'SupplierService',
  function ($scope, $location, SupplierService) {
      $scope.filterByStatus = 'active';
      $scope.getSuppliers = function () {
          $scope.suppliers = SupplierService.supplier.query({ filterByStatus: $scope.filterByStatus }, function (data) {
              var result = data;
          });
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
                  changeSupplierStatusHelper(false, sup, $scope.failedDeactivations, value);
              });
          }
      }
      
      $scope.isDeactivationFailed = isItemFound;

      $scope.failedActivations = [];
      $scope.activateSupplier = function (sup) {
          SupplierService.activateSupplier.save({}, { id: sup.Id }, function (value, responseHeaders) {
              changeSupplierStatusHelper(true, sup, $scope.failedActivations, value);
          });
      }

      $scope.isActivationFailed = isItemFound;

      var changeSupplierStatusHelper = function(isActivation, sup, arrayOfId, serverResult)
      {
          if (serverResult.Success) {
              sup.Active = isActivation ? true : false;
              var index = arrayOfId.indexOf(sup.Id);
              if (index > -1) {
                  arrayOfId.splice(index, 1);
              }
          }
          else {
              arrayOfId.push(sup.Id);
          }
      }

      var isItemFound = function (array, item) {
          return array.indexOf(item) > -1;
      }
  }]);