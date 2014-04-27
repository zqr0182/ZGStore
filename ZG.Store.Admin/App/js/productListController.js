angular.module('storeAdminControllers').controller('ProductListCtrl', ['$scope', '$location', 'ProdService', 'CommonFunctions',
  function ($scope, $location, ProdService, CommonFunctions) {
      $scope.filterByStatus = 'active';
      $scope.getProducts = function () {
          $scope.products = ProdService.products.get({ filterByStatus: $scope.filterByStatus });
      }
      $scope.getProducts();      

      $scope.go = function (path) {
          $location.path(path);
      }

      $scope.failedDeactivations = [];
      $scope.deactivateProd = function (prod)
      {
          if (window.confirm('Are you sure you want to inactivate this product?'))
          {
              ProdService.deactivateProduct.remove({ id: prod.Id }, {}, function (value, responseHeaders) {
                  CommonFunctions.changeStatusHelper(false, prod, $scope.failedDeactivations, value);
              });
          }
      }
      
      $scope.isDeactivationFailed = function (id) {
          return CommonFunctions.isItemFound($scope.failedDeactivations, id);
      }

      $scope.failedActivations = [];
      $scope.activateProd = function (prod) {
          ProdService.activateProduct.save({}, { id: prod.Id }, function (value, responseHeaders) {
              CommonFunctions.changeStatusHelper(true, prod, $scope.failedActivations, value);
              });
      }

      $scope.isActivationFailed = function (id) {
          return CommonFunctions.isItemFound($scope.failedActivations, id);
      }
  }]);