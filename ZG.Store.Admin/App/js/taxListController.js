angular.module('storeAdminControllers').controller('TaxListCtrl', ['$scope', 'TaxService', 'CountryService', 'StateService', 'ProvinceService', 'CacheService', 'CommonFunctions',
  function ($scope, TaxService, CountryService, StateService, ProvinceService, CacheService, CommonFunctions) {
      $scope.isFormDirty = false;
      $scope.alerts = [];
      $scope.pattern = CommonFunctions.regExpPattern();
      $scope.selectedCountry;
      $scope.allCountries = CountryService.countryIdNames.query(); 

      var deregisterWatch;
      $scope.getTaxes = function () {
          var country = $scope.selectedCountry;
          if (country.Name == "UNITED STATES")
          {
              var statesKey = 'allStates';
              $scope.allStates = CacheService.cache.get(statesKey);
              if(!$scope.allStates)
              {
                  StateService.stateIdNames.query(function (data) {
                      $scope.allStates = data;
                      CacheService.put(statesKey, data);
                  });
              }
          }

          if (country.Name == "CHINA" || country.Name == "CANADA") {
              var provincesKey = $scope.selectedCountry.Id + '-provinces';
              $scope.allProvinces = CacheService.cache.get(provincesKey);
              if(!$scope.allProvinces)
              {
                  ProvinceService.provinceIdNames.query({ countryId: $scope.selectedCountry.Id }, function (data) {
                      $scope.allProvinces = data;
                      CacheService.put(provincesKey, data);
                  });
              }
          }

          $scope.alerts = [];
          if (deregisterWatch) {
              $scope.isFormDirty = false;
              deregisterWatch();
          }

          $scope.taxes = TaxService.get.query({ countryId: country.Id }, function (data) {
              deregisterWatch = $scope.$watch('taxes', function (newValue, oldValue) {
                  if (!angular.equals(newValue, oldValue)) {
                      $scope.isFormDirty = true;
                  }
              }, true);
          });
      }      

      $scope.add = function()
      {
          $scope.alerts = [];
          $scope.taxes.push({ CountryId: $scope.selectedCountry.Id, Fixed: false, Active: true });
      }

      $scope.delete = function(tax)
      {
          CommonFunctions.removeFromArray($scope.taxes, tax);
      }

      $scope.save = function()
      {
          $scope.alerts = [];
          TaxService.save.save($scope.taxes, function (data) {
              $scope.isFormDirty = false;
              if (data.Success) {
                  $scope.alerts.push({ type: 'success', msg: 'Taxes saved successfully.' });
              }
              else {
                  data.Errors.forEach(function (item) {
                      $scope.alerts.push({ type: 'danger', msg: item });
                  });
              }
          }, function (error) {
              $scope.alerts.push({ type: 'danger', msg: 'Unable to upsert taxes. Please try again later.' });
          });
      }
  }]);