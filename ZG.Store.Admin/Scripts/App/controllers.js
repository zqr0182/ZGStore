var controllers = angular.module('storeAdminControllers', []);

controllers.controller('EditProductCtrl', ['$scope', '$http',
  function ($scope, $http) {
      $scope.P1 = 'test';
  }]);

controllers.controller('ProductListCtrl', ['$scope', '$routeParams', 'ProdService',
  function ($scope, $routeParams, ProdService) {
      $scope.Products = ProdService.get();
  }]);