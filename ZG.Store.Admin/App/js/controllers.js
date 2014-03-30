var controllers = angular.module('storeAdminControllers', []);

controllers.controller('EditProductCtrl', ['$scope', '$http', '$routeParams', 'ProdService',
  function ($scope, $http, $routeParams, ProdService) {
      $scope.prod = ProdService.product.get({ prodId: $routeParams.prodId });
      $scope.resultOfSave = '';
      $scope.saveProd = function () {
          ProdService.product.save({}, $scope.prod, function (value, responseHeaders) {
              $scope.resultOfSave = value.Message;
          })
      }
  }]);

controllers.controller('ProductListCtrl', ['$scope', '$location', 'ProdService',
  function ($scope, $location, ProdService) {
      $scope.Products = ProdService.products.get();
      $scope.go = function (path) {
          $location.path(path);
      }
  }]);