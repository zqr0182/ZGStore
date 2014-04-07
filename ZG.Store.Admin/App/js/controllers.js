var controllers = angular.module('storeAdminControllers', []);

controllers.controller('EditProductCtrl', ['$scope', '$http', '$routeParams', 'ProdService', '$timeout', '$upload', 
  function ($scope, $http, $routeParams, ProdService, $timeout, $upload) {
      $scope.prod = ProdService.product.get({ prodId: $routeParams.prodId });
      $scope.isSuccessful = false;
      $scope.errors = null;
      $scope.deleteProductImage = function(imageName)
      {
          ProdService.product.deleteProductImage();
      }
      
      $scope.onFileSelect = function ($files) {
          $scope.progress = '';
          $scope.selectedFiles = $files;
          $scope.dataUrls = [];
          for (var i = 0; i < $files.length; i++) {
              var $file = $files[i];

              if (window.FileReader && $file.type.indexOf('image') > -1) {
                  var fileReader = new FileReader();
                  fileReader.readAsDataURL($files[i]);
                  var loadFile = function (fileReader, index) {
                      fileReader.onload = function (e) {
                          $timeout(function () {
                              $scope.dataUrls[index] = e.target.result;
                          });
                      }
                  }(fileReader, i);
              }
          }
      }

      $scope.saveProd = function () {
          //ProdService.product.save({}, $scope.prod, function (value, responseHeaders) {
          //    $scope.resultOfSave = value.Message;
          $upload.upload({
              url: '/product/edit',
              method: 'POST',
              headers: { 'my-header': 'my-header-value' },
              data: { prod: $scope.prod },
              file: $scope.selectedFiles,
              fileFormDataName: 'myFile1, myFile2'
          }).progress(function (evt) {
              $scope.progress = 'percent: ' + parseInt(100.0 * evt.loaded / evt.total);
          }).then(function (response) {
              if (response.data.Success) {
                  $scope.isSuccessful = true;
                  $scope.errors = null;
                  for (var i = 0; i < $scope.selectedFiles.length; i++) {
                      $scope.prod.ProductImageNames.push($scope.selectedFiles[i].name);
                  }
              }
              else {
                  $scope.isSuccessful = false;
                  $scope.errors = response.data.Errors;
              }
          }, null);
      }
  }]);

controllers.controller('ProductListCtrl', ['$scope', '$location', 'ProdService',
  function ($scope, $location, ProdService) {
      $scope.Products = ProdService.products.get();
      $scope.go = function (path) {
          $location.path(path);
      }
  }]);