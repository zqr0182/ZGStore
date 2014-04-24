﻿angular.module('storeAdminControllers').controller('EditSupplierCtrl', ['$scope', '$http', '$routeParams', 'SupplierService', 'CommonFunctions',
  function ($scope, $http, $routeParams, SupplierService, CommonFunctions) {
      if ($routeParams.supId > 0) {
          $scope.sup = SupplierService.supplierEdit.get({ supId: $routeParams.supId });
      }
      $scope.isSaveSuccessful = false;
      $scope.errors = null;
      $scope.pattern = CommonFunctions.regExpPattern();

      $scope.saveSupplier = function () {

          var service;
          if ($routeParams.supId > 0)
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