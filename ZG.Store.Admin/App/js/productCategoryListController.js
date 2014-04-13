angular.module('storeAdminControllers').controller('ProductCategoryListCtrl', ['$scope', '$location', 'ProdCategoryService',
  function ($scope, $location, ProdCategoryService) {
      $scope.filterByStatus = 'active';
      $scope.getProductCategories = function () {
          $scope.categories = ProdCategoryService.categories.get({ filterByStatus: $scope.filterByStatus });
      }
      $scope.getProductCategories();

      $scope.go = function (path) {
          $location.path(path);
      }

      $scope.failedDeactivations = [];
      $scope.deactivateCategory = function (cat)
      {
          if (window.confirm('Are you sure you want to inactivate this category?'))
          {
              ProdCategoryService.deactivateCategory.remove({catId: cat.Id }, {}, function (value, responseHeaders) {
                  changeCategoryStatusHelper(false, cat, $scope.failedDeactivations, value);
              });
          }
      }
      
      $scope.isDeactivationFailed = isItemFound;

      $scope.failedActivations = [];
      $scope.activateCategory = function (cat) {
          ProdCategoryService.activateCategory.save({ id: cat.Id }, {}, function (value, responseHeaders) {
              changeCategoryStatusHelper(true, cat, $scope.failedActivations, value);
              });
      }

      $scope.isActivationFailed = isItemFound;

      var changeCategoryStatusHelper = function (isActivation, cat, arrayOfId, serverResult)
      {
          if (serverResult.Success) {
              cat.Active = isActivation ? true : false;
              var index = arrayOfId.indexOf(cat.Id);
              if (index > -1) {
                  arrayOfId.splice(index, 1);
              }
          }
          else {
              arrayOfId.push(cat.Id);
          }
      }

      var isItemFound = function (array, item) {
          return array.indexOf(item) > -1;
      }
  }]);