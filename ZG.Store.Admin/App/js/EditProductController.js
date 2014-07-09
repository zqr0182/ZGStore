angular.module('storeAdminControllers').controller('EditProductCtrl', ['$scope', '$routeParams', 'ProdService', 'ProdCategoryService', 'SupplierService', 'CommonFunctions', '$timeout', '$upload',
  function ($scope, $routeParams, ProdService, ProdCategoryService, SupplierService, CommonFunctions, $timeout, $upload) {
      $scope.showDeleteImageSuccessfulMsg = false;
      $scope.showDeleteImageFailureMsg = false;
      $scope.deleteImageFailureMsg = '';    
      $scope.pattern = CommonFunctions.regExpPattern();
      $scope.alerts = [];

      $scope.allSuppliers = SupplierService.supplierIdNames.query({ filterByStatus: 'Active' });
      $scope.allProdCategories = ProdCategoryService.categoryIdNames.query();
      
      if ($routeParams.id > 0) {
          $scope.prod = ProdService.product.get({ id: $routeParams.id }, function (data) {
              var currentProdCats = CommonFunctions.getArrayById($scope.prod.ProductCategories, $scope.allProdCategories);
              if (currentProdCats.length > 0)
              {
                  $scope.prod.ProductCategories = currentProdCats;
              }
          });
      }

      $scope.deleteProductImage = function (imageName) {
          if (window.confirm('Are you sure you want to delete this image?')) {
              var imageNameNoExtension = imageName.split('.').splice(0, 1)[0];
              ProdService.productImage.remove({ id: $scope.prod.Id, imageName: imageName }, {}, function (value, responseHeaders) {
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

      $scope.addInventory = function () {
          $scope.prod.Inventories.push({Active: true});
      }

      $scope.deleteInventory = function(inventory)
      {
          CommonFunctions.removeFromArray($scope.prod.Inventories, inventory);
      }

      $scope.saveProd = function () {
          var url = ($routeParams.id > 0) ? "/product/edit" : "/product/create";
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
                  $scope.alerts = [];
                  $scope.alerts.push({ type: 'success', msg: 'Product saved successfully.' });

                  for (var i = 0; i < $scope.selectedFiles.length; i++) {
                      $scope.prod.ProductImageNames.push($scope.selectedFiles[i].name);
                  }
              }
              else {
                  $scope.alerts = [];
                  response.data.Errors.forEach(function (item) {
                      $scope.alerts.push({ type: 'danger', msg: item });
                  });
              }
          }, null);
      }
  }]);