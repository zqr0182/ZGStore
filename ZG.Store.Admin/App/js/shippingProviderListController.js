angular.module('storeAdminControllers').controller('ShippingProviderListCtrl', ['$scope', '$location', 'ShippingProviderService', 'CommonFunctions',
  function ($scope, $location, ShippingProviderService, CommonFunctions) {
      $scope.shippingProviders = ShippingProviderService.get.query();
      $scope.alerts = [];
      $scope.pattern = CommonFunctions.regExpPattern();

      $scope.add = function()
      {
          $scope.shippingProviders.push({Active:true});
      }

      $scope.delete = function (shippingProvider) {
          CommonFunctions.removeFromArray($scope.shippingProviders, shippingProvider);
      }

      $scope.save = function()
      {
          ShippingProviderService.save.save($scope.shippingProviders, function (data) {
              $scope.alerts = [];
              if (data.Success) {
                  $scope.alerts.push({ type: 'success', msg: 'Provinces saved successfully.' });
              }
              else {
                  data.Errors.forEach(function (item) {
                      $scope.alerts.push({ type: 'danger', msg: item });
                  });
              }
          }, function (error) {
              $scope.alerts = [];
              $scope.alerts.push({ type: 'danger', msg: 'Unable to upsert shipping providers. Please try again later.' });
          });
      }
  }]);