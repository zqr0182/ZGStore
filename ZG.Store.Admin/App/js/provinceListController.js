angular.module('storeAdminControllers').controller('ProvinceListCtrl', ['$scope', 'ProvinceService', 'CountryService', 'CommonFunctions',
  function ($scope, ProvinceService, CountryService, CommonFunctions) {
      $scope.isFormDirty = false;
      $scope.alerts = [];
      $scope.selectedCountry;
      $scope.allCountries = CountryService.countryIdNamesOfCanadaChina.query();

      var deregisterWatch;
      $scope.getProvinces = function () {
          $scope.alerts = [];
          if (deregisterWatch) {
              $scope.isFormDirty = false;
              deregisterWatch();
          }

          $scope.provinces = ProvinceService.get.query({ countryId: $scope.selectedCountry.Id }, function (data) {             
              deregisterWatch = $scope.$watch('provinces', function (newValue, oldValue) {
                  if (!angular.equals(newValue, oldValue)) {
                      $scope.isFormDirty = true;
                  }
              }, true);
          });
      }      

      $scope.add = function()
      {
          $scope.alerts = [];
          $scope.provinces.push({CountryId: $scope.selectedCountry.Id, Active: true });
      }

      $scope.delete = function(province)
      {
          CommonFunctions.removeFromArray($scope.provinces, province);
      }

      $scope.save = function()
      {
          ProvinceService.save.save($scope.provinces, function (data) {
              $scope.isFormDirty = false;
              $scope.alerts = [];
              $scope.alerts.push({ type: 'success', msg: 'Provinces saved successfully.' });
          }, function (error) {
              $scope.alerts = [];
              error.Errors.forEach(function (item) {
                  $scope.alerts.push({ type: 'danger', msg: item });
              });
          });
      }
  }]);