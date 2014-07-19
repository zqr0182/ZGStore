angular.module('storeAdminControllers').controller('StoreConfigListCtrl', ['$scope', 'StoreConfigurationService', 'CacheService', 'CommonFunctions',
  function ($scope, StoreConfigurationService, CacheService, CommonFunctions) {
      $scope.isFormDirty = false;
      $scope.alerts = [];
      $scope.filterByStatus = 'active';

      var deregisterWatch;
      $scope.getStoreConfigs = function () {
          $scope.alerts = [];
          if (deregisterWatch) {
              $scope.isFormDirty = false;
              deregisterWatch();
          }

          $scope.storeConfigs = StoreConfigurationService.get.query({ filterByStatus: $scope.filterByStatus }, function (data) {
              deregisterWatch = $scope.$watch('storeConfigs', function (newValue, oldValue) {
                  if (!angular.equals(newValue, oldValue)) {
                      $scope.isFormDirty = true;
                  }
              }, true);
          });
      }

      $scope.getStoreConfigs();

      $scope.add = function()
      {
          $scope.alerts = [];
          $scope.storeConfigs.push({ Active: true});
      }

      $scope.delete = function(config)
      {
          CommonFunctions.removeFromArray($scope.storeConfigs, config);
      }

      $scope.save = function()
      {
          $scope.alerts = [];
          StoreConfigurationService.save.save({ filterByStatus: $scope.filterByStatus }, $scope.storeConfigs, function (data) {
              $scope.isFormDirty = false;
              if (data.Success) {
                  $scope.storeConfigs = data.StoreConfigurations;
                  $scope.alerts.push({ type: 'success', msg: 'StoreConfigurations saved successfully.' });
              }
              else {
                  data.Errors.forEach(function (item) {
                      $scope.alerts.push({ type: 'danger', msg: item });
                  });
              }
          }, function (error) {
              $scope.alerts.push({ type: 'danger', msg: 'Unable to upsert StoreConfigurations. Please try again later.' });
          });
      }
  }]);