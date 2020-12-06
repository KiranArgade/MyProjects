var app = angular.module('InventoryApp', ['ngRoute']);

// configure our routes
app.config(function ($routeProvider) {
    $routeProvider.when('/ProductList', { //Routing for show list of Product
        templateUrl: '/App/Views/ProductList.html',
        controller: 'InventoryController'
    }).when('/AddProduct', { //Routing for add Product
        templateUrl: '/App/Views/AddProduct.html',
        controller: 'InventoryController'
    })
    .when('/EditProduct/:prodId', { //Routing for geting single Product details
        templateUrl: '/App/Views/EditProduct.html',
        controller: 'InventoryController'
    })
    .when('/DeleteProduct/:prodId', { //Routing for delete Product
        templateUrl: '/App/Views/DeleteProduct.html',
        controller: 'InventoryController'
    })
    .otherwise({ //Default Routing
        controller: 'InventoryController'
    })
});