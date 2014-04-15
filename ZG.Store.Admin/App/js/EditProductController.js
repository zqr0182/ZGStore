angular.module('storeAdminControllers').controller('EditProductCtrl', ['$scope', '$http', '$routeParams', 'ProdService', 'ProdCategoryService', '$timeout', '$upload',
  function ($scope, $http, $routeParams, ProdService, ProdCategoryService, $timeout, $upload) {
      $scope.allProdCategories = ProdCategoryService.categoryIdNames.query(function (data) {
          $scope.selectedOptions = [data[0], data[1]];
      });
      
      if ($routeParams.prodId > 0) {
          $scope.prod = ProdService.product.get({ prodId: $routeParams.prodId }, function (data) {
              var currentProdCats = [];              

              $scope.prod.ProductCategories.forEach(function (pc) {
                  $scope.allProdCategories.forEach(function (pc2) {
                      if (pc.Id == pc2.Id) {
                          currentProdCats.push(pc2);
                      }
                  });
              });

              if (currentProdCats.length > 0)
              {
                  $scope.prod.ProductCategories = currentProdCats;
              }
          });
      }
      $scope.showDeleteImageSuccessfulMsg = false;
      $scope.showDeleteImageFailureMsg = false;
      $scope.deleteImageFailureMsg = '';
      $scope.isSaveSuccessful = false;
      $scope.errors = null;
      $scope.deleteProductImage = function (imageName) {
          if (window.confirm('Are you sure you want to delete this image?')) {
              var imageNameNoExtension = imageName.split('.').splice(0, 1)[0];
              ProdService.productImage.remove({ prodId: $scope.prod.Id, imageName: imageName }, {}, function (value, responseHeaders) {
                  if (value.Success) {
                      $scope.showDeleteImageSuccessfulMsg = true;
                      $scope.prod.ProductImageNames = value.Images;
                  }
                  else {
                      $scope.showDeleteImageFailureMsg = true;
                      $scope.deleteImageFailureMsg = value.Error;
                  }
              });
          }
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
          var url = ($routeParams.prodId > 0) ? "/product/edit" : "/product/create";
          $upload.upload({
              url: url,
              method: 'POST',
              headers: { 'my-header': 'my-header-value' },
              data: { prod: $scope.prod },
              file: $scope.selectedFiles,
              fileFormDataName: 'myFile1, myFile2'
          }).progress(function (evt) {
              $scope.progress = 'percent: ' + parseInt(100.0 * evt.loaded / evt.total);
          }).then(function (response) {
              if (response.data.Success) {
                  $scope.isSaveSuccessful = true;
                  $scope.errors = null;
                  for (var i = 0; i < $scope.selectedFiles.length; i++) {
                      $scope.prod.ProductImageNames.push($scope.selectedFiles[i].name);
                  }
              }
              else {
                  $scope.isSaveSuccessful = false;
                  $scope.errors = response.data.Errors;
              }
          }, null);
      }
  }]);