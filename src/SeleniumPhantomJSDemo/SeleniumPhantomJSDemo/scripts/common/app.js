var app = angular.module("spd", ["ngRoute"]);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/customers/', {
            templateUrl: spd.url.create('CustomerViews/List'),
            controller: 'customersController'
        })
        .when('/customers/:customerId/edit', {
            templateUrl: spd.url.create('CustomerViews/Edit'),
            controller: 'editCustomerController'
        })
        .when('/customers/add', {
            templateUrl: spd.url.create('CustomerViews/Add'),
            controller: 'addCustomerController'
        })
        .when('/customers/:customerId', {
            templateUrl: spd.url.create('CustomerViews/Details'),
            controller: 'customerDetailsController'
        })
        .otherwise({
            redirectTo: '/customers'
        });;
}]);