app.controller("InventoryController", ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {
    $scope.ListOfProduct;
    $scope.Status;

    $scope.Close = function () {
        $location.path('/ProductList');
    }

    //Get all employee and bind with html table
    $http.get("api/inventory").success(function (data) {
        $scope.ListOfProduct = data;
    })
    .error(function (data) {
        $scope.Status = "data not found";
    });

    //Add new Inventory
    $scope.Add = function () {
        var ProductData = {
            Name: $scope.Name,
            Price: $scope.Price,
            Quantity: $scope.Quantity,
            CreatedDate: $scope.CreatedDate
        };
        $http.post("api/inventory", ProductData).success(function (data) {
            $location.path('/ProductList');
        }).error(function (data) {
            console.log(data);
            $scope.error = "Something wrong when adding new Inventory " + data.ExceptionMessage;
        });
    }

    //Fill the Inventory records for update
    if ($routeParams.prodId) {
        $scope.Id = $routeParams.prodId;
        $http.get('api/inventory/' + $scope.Id).success(function (data) {
            $scope.Name = data.Name;
            $scope.Price = data.Price;
            $scope.Quantity = data.Quantity;
            $scope.CreatedDate = data.CreatedDate;
        });
    }

    //Update the Inventory records
    $scope.Update = function () {
        var InventoryData = {
            ID: $scope.Id,
            Name: $scope.Name,
            Price: $scope.Price,
            Quantity: $scope.Quantity,
            CreatedDate: $scope.CreatedDate,
        };
        if ($scope.Id > 0) {
            $http.put("api/inventory", InventoryData).success(function (data) {
                $location.path('/ProductList');
            }).error(function (data) {
                console.log(data);
                $scope.error = "Something wrong when adding updating Inventory " + data.ExceptionMessage;
            });
        }
    }

    //Delete the selected Inventory from the list
    $scope.Delete = function () {
        if ($scope.Id > 0) {
            $http.delete("api/inventory/" + $scope.Id).success(function (data) {
                $location.path('/ProductList');
            }).error(function (data) {
                console.log(data);
                $scope.error = "Something wrong when adding Deleting Inventory " + data.ExceptionMessage;
            });
        }
    }
}]);