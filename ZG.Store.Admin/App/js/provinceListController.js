angular.module('storeAdminControllers').controller('ProvinceListCtrl', ['$scope', 'ProvinceService', 'CountryService', 'CommonFunctions',
  function ($scope, ProvinceService, CountryService, CommonFunctions) {
      $scope.allCountries = CountryService.countryIdNames.query({ filterByStatus: 'Active' });
      $scope.provinces = ProvinceService.get.query(function (data) {
          var countryIdName = $scope.provinces.CountryIdName;
          countryIdName = CommonFunctions.getItemById(countryIdName.Id, $scope.allCountries);
      });
      $scope.alerts = [];

      $scope.add = function()
      {
          $scope.provinces.push({ Active: true });
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