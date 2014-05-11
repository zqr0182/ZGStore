angular.module('storeAdminControllers').controller('UserListCtrl', ['$scope', 'UserService', 'CacheService', 'CommonFunctions',
  function ($scope, UserService, CacheService, CommonFunctions) {
      $scope.isFormDirty = false;
      $scope.alerts = [];
      $scope.pattern = CommonFunctions.regExpPattern();
      $scope.filterByStatus = 'active';

      var deregisterWatch;
      $scope.getUsers = function () {
          $scope.alerts = [];
          if (deregisterWatch) {
              $scope.isFormDirty = false;
              deregisterWatch();
          }

          $scope.users = UserService.get.query({ filterByStatus: $scope.filterByStatus }, function (data) {
              deregisterWatch = $scope.$watch('users', function (newValue, oldValue) {
                  if (!angular.equals(newValue, oldValue)) {
                      $scope.isFormDirty = true;
                  }
              }, true);
          });
      }

      $scope.getUsers();

      $scope.add = function()
      {
          $scope.alerts = [];
          $scope.users.push({ Active: true });
      }

      $scope.delete = function(user)
      {
          CommonFunctions.removeFromArray($scope.users, user);
      }

      $scope.save = function()
      {
          $scope.alerts = [];
          UserService.save.save($scope.users, function (data) {
              $scope.isFormDirty = false;
              if (data.Success) {
                  $scope.alerts.push({ type: 'success', msg: 'Users saved successfully.' });
              }
              else {
                  data.Errors.forEach(function (item) {
                      $scope.alerts.push({ type: 'danger', msg: item });
                  });
              }
          }, function (error) {
              $scope.alerts.push({ type: 'danger', msg: 'Unable to upsert users. Please try again later.' });
          });
      }
  }]);