angular.module('storeAdminControllers').controller('ProductListCtrl', ['$scope', '$location', 'ProdService',
  function ($scope, $location, ProdService) {
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
              ProdService.deactivateProduct.remove({ prodId: prod.Id }, {}, function (value, responseHeaders) {
                  if(value.Success)
                  {
                      prod.Active = false;
                      var index = $scope.failedDeactivations.indexOf(prod.Id);
                      if(index > -1)
                      {
                          $scope.failedDeactivations.splice(index, 1);
                      }
                  }
                  else {
                      $scope.failedDeactivations.push(prod.Id);
                  }
              });
          }
      }
      
      $scope.isDeactivationFailed = isItemFound;

      $scope.failedActivations = [];
      $scope.activateProd = function (prod) {
          ProdService.activateProduct.save({ id: prod.Id }, {}, function (value, responseHeaders) {
                  if (value.Success) {
                      prod.Active = true;
                      var index = $scope.failedActivation.indexOf(prod.Id);
                      if (index > -1) {
                          $scope.failedActivation.splice(index, 1);
                      }
                  }
                  else {
                      $scope.failedActivation.push(prod.Id);
                  }
              });
      }

      $scope.isActivationFailed = isItemFound;

      var changeProductStatusHelper = function(prod, arrayOfId, serverResult)
      {
          if (serverResult.Success) {
              prod.Active = true;
              var index = $scope.failedActivation.indexOf(prod.Id);
              if (index > -1) {
                  $scope.failedActivation.splice(index, 1);
              }
          }
          else {
              $scope.failedActivation.push(prod.Id);
          }
      }

      var isItemFound = function (array, item) {
          return array.indexOf(item) > -1;
      }
  }]);