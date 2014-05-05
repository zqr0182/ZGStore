angular.module('storeAdminControllers').controller('ShippingListCtrl', ['$scope', 'ShippingService', 'CountryService', 'StateService', 'ProvinceService', 'ProductService', 'ShippingProviderService', 'ShippingService', 'CommonFunctions',
  function ($scope, ShippingService, CountryService, StateService, ProvinceService, ProductService, ShippingProviderService, ShippingService, CommonFunctions) {
      $scope.isFormDirty = false;
      $scope.alerts = [];
      $scope.pattern = CommonFunctions.regExpPattern();
      $scope.selectedCountry;
      $scope.allCountries = CountryService.countryIdNames.query();
      $scope.allStates = StateService.stateIdNames.query();
      $scope.allProvinces = ProvinceService.provinceIdNames.query();
      $scope.allProducts = ProductService.prodIdNames.query();
      $scope.allShippingProviders = ShippingProviderService.shippingProviderIdNames.query();

      var deregisterWatch;
      $scope.getShippings = function () {
          $scope.alerts = [];
          if (deregisterWatch) {
              $scope.isFormDirty = false;
              deregisterWatch();
          }

          $scope.shippings = ShippingService.get.query({ countryId: $scope.selectedCountry.Id }, function (data) {
              deregisterWatch = $scope.$watch('shippings', function (newValue, oldValue) {
                  if (!angular.equals(newValue, oldValue)) {
                      $scope.isFormDirty = true;
                  }
              }, true);
          });
      }      

      $scope.add = function()
      {
          $scope.alerts = [];
          $scope.shippings.push({ CountryId: $scope.selectedCountry.Id, Active: true });
      }

      $scope.delete = function(shipping)
      {
          CommonFunctions.removeFromArray($scope.shippings, shipping);
      }

      $scope.save = function()
      {
          ShippingService.save.save($scope.shippings, function (data) {
              $scope.isFormDirty = false;
              $scope.alerts = [];
              $scope.alerts.push({ type: 'success', msg: 'Shippings saved successfully.' });
          }, function (error) {
              $scope.alerts = [];
              error.Errors.forEach(function (item) {
                  $scope.alerts.push({ type: 'danger', msg: item });
              });
          });
      }
  }]);