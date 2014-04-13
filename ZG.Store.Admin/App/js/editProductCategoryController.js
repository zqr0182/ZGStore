angular.module('storeAdminControllers').controller('EditProductCategoryCtrl', ['$scope', '$http', '$routeParams', 'ProdCategoryService',
  function ($scope, $http, $routeParams, ProdCategoryService) {
      $scope.cat = ProdCategoryService.category.get({ catId: $routeParams.catId });
      $scope.isSaveSuccessful = false;
      $scope.errors = null;

      $scope.saveProductCategory = function () {
          ProdCategoryService.category.save({}, $scope.cat, function (data) {
              if (data.Success) {
                  $scope.isSaveSuccessful = true;
              }
              else {
                  $scope.errors = data.Errors;
              }
          });
      }
  }]);