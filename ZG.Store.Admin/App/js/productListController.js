angular.module('storeAdminControllers').controller('ProductListCtrl', ['$scope', '$location', 'ProdService',
  function ($scope, $location, ProdService) {
      $scope.filterByStatus = 'active';
      $scope.getProducts = function () {
          $scope.products = ProdService.products.get({ filterByStatus: $scope.filterByStatus });
      }
      $scope.getProducts();      

      $scope.go = function (path) {
          $location.path(path);
      }

      $scope.deactivateFailed = [];
      $scope.deactivateProd = function (prod)
      {
          if (window.confirm('Are you sure you want to inactivate this product?'))
          {
              ProdService.productDeactive.remove({ prodId: prod.Id }, {}, function (value, responseHeaders) {
                  if(value.Success)
                  {
                      prod.Active = false;
                      var index = $scope.deactivateFailed.indexOf(prod.Id);
                      if(index > -1)
                      {
                          $scope.deactivateFailed.splice(index, 1);
                      }
                  }
                  else {
                      $scope.deactivateFailed.push(prod.Id);
                  }
              });
          }
      }
      
      $scope.isDeactivateFailed = function(prodId)
      {
          return $scope.deactivateFailed.indexOf(prodId) > -1;
      }
  }]);