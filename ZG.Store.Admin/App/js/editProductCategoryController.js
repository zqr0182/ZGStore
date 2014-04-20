angular.module('storeAdminControllers').controller('EditProductCategoryCtrl', ['$scope', '$http', '$routeParams', 'ProdCategoryService',
  function ($scope, $http, $routeParams, ProdCategoryService) {
      if ($routeParams.catId > 0) {
          $scope.cat = ProdCategoryService.categoryEdit.get({ catId: $routeParams.catId });
      }
      $scope.isSaveSuccessful = false;
      $scope.errors = null;

      $scope.saveProductCategory = function () {

          var service;
          if ($routeParams.catId > 0)
          {
              service = ProdCategoryService.categoryEdit;
          }
          else {
              service = ProdCategoryService.categoryCreate;
          }

          service.save({}, $scope.cat, function (data) {
              if (data.Success) {
                  $scope.isSaveSuccessful = true;
              }
              else {
                  $scope.errors = data.Errors;
              }
          });
      }
  }]);