angular.module('storeAdminControllers').controller('ProvinceListCtrl', ['$scope', 'ProvinceService', 'CountryService', 'CommonFunctions',
  function ($scope, ProvinceService, CountryService, CommonFunctions) {
      $scope.alerts = [];
      $scope.selectedCountry;
      $scope.allCountries = CountryService.countryIdNames.query();

      $scope.getProvinces = function () {
          $scope.alerts = [];
          $scope.provinces = ProvinceService.get.query({ countryId: $scope.selectedCountry.Id });
      }

      $scope.add = function()
      {
          $scope.alerts = [];
          $scope.provinces.push({CountryId: $scope.selectedCountry.Id, Active: true });
      }

      $scope.save = function()
      {
          ProvinceService.save.save($scope.provinces, function (data) {
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