var controllers = angular.module('storeAdminControllers', []);

controllers.controller('EditProductCtrl', ['$scope', '$http', '$routeParams', 'ProdService',
  function ($scope, $http, $routeParams, ProdService) {
      $scope.prod = ProdService.product.get({ prodId: $routeParams.prodId });
  }]);

controllers.controller('ProductListCtrl', ['$scope', '$location', 'ProdService',
  function ($scope, $location, ProdService) {
      $scope.Products = ProdService.products.get();
      $scope.go = function (path) {
          $location.path(path);
      }
  }]);