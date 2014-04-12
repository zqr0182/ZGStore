angular.module('storeAdminControllers').controller('ProductCategoryListCtrl', ['$scope', '$location', 'ProdCategoryService',
  function ($scope, $location, ProdCategoryService) {
      $scope.filterByStatus = 'active';
      $scope.getProductCategories = function () {
          $scope.productCategories = ProdCategoryService.categories.get({ filterByStatus: $scope.filterByStatus });
      }
      $scope.getProductCategories();

      $scope.go = function (path) {
          $location.path(path);
      }

      //$scope.failedDeactivations = [];
      //$scope.deactivateProd = function (prod)
      //{
      //    if (window.confirm('Are you sure you want to inactivate this product?'))
      //    {
      //        ProdService.deactivateProduct.remove({ prodId: prod.Id }, {}, function (value, responseHeaders) {
      //            changeProductStatusHelper(false, prod, $scope.failedDeactivations, value);
      //        });
      //    }
      //}
      
      //$scope.isDeactivationFailed = isItemFound;

      //$scope.failedActivations = [];
      //$scope.activateProd = function (prod) {
      //    ProdService.activateProduct.save({ id: prod.Id }, {}, function (value, responseHeaders) {
      //            changeProductStatusHelper(true, prod, $scope.failedActivations, value);
      //        });
      //}

      //$scope.isActivationFailed = isItemFound;

      //var changeProductStatusHelper = function(isActivation, prod, arrayOfId, serverResult)
      //{
      //    if (serverResult.Success) {
      //        prod.Active = isActivation ? true : false;
      //        var index = arrayOfId.indexOf(prod.Id);
      //        if (index > -1) {
      //            arrayOfId.splice(index, 1);
      //        }
      //    }
      //    else {
      //        arrayOfId.push(prod.Id);
      //    }
      //}

      //var isItemFound = function (array, item) {
      //    return array.indexOf(item) > -1;
      //}
  }]);