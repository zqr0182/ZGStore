angular.module('storeAdminControllers').controller('ProductCategoryListCtrl', ['$scope', '$location', 'ProdCategoryService', 'CommonFunctions',
  function ($scope, $location, ProdCategoryService, CommonFunctions) {
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
                  CommonFunctions.changeStatusHelper(false, cat, $scope.failedDeactivations, value);
              });
          }
      }
      
      $scope.isDeactivationFailed = function (id) {
          return CommonFunctions.isItemFound($scope.failedDeactivations, id);
      }

      $scope.failedActivations = [];
      $scope.activateCategory = function (cat) {
          ProdCategoryService.activateCategory.save({ id: cat.Id }, {}, function (value, responseHeaders) {
              CommonFunctions.changeStatusHelper(true, cat, $scope.failedActivations, value);
          });
      }

      $scope.isActivationFailed = function (id) {
          return CommonFunctions.isItemFound($scope.failedActivations, id);
      }
  }]);