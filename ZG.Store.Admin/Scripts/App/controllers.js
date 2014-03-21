var controllers = angular.module('storeAdminControllers', []);

controllers.controller('EditProductCtrl', ['$scope', '$http',
  function ($scope, $http) {
      $scope.P1 = 'test';
  }]);

controllers.controller('ProductListCtrl', ['$scope', '$routeParams',
  function ($scope, $routeParams) {
      $scope.P1 = 'test';
  }]);