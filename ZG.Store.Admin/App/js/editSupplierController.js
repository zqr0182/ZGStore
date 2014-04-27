angular.module('storeAdminControllers').controller('EditSupplierCtrl', ['$scope', '$http', '$routeParams', 'SupplierService', 'CommonFunctions',
  function ($scope, $http, $routeParams, SupplierService, CommonFunctions) {
      if ($routeParams.id > 0) {
          $scope.sup = SupplierService.supplierEdit.get({ id: $routeParams.id });
      }
      $scope.isSaveSuccessful = false;
      $scope.errors = null;
      $scope.pattern = CommonFunctions.regExpPattern();

      $scope.saveSupplier = function () {

          var service;
          if ($routeParams.id > 0)
          {
              service = SupplierService.supplierEdit;
          }
          else {
              service = SupplierService.supplierCreate;
          }

          service.save({}, $scope.sup, function (data) {
              if (data.Success) {
                  $scope.isSaveSuccessful = true;
              }
              else {
                  $scope.errors = data.Errors;
              }
          });
      }
  }]);