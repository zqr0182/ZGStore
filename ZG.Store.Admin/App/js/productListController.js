angular.module('storeAdminControllers').controller('ProductListCtrl', ['$scope', '$location', 'ProdService',
  function ($scope, $location, ProdService) {
      $scope.Products = ProdService.products.get();
      $scope.go = function (path) {
          $location.path(path);
      }
  }]);