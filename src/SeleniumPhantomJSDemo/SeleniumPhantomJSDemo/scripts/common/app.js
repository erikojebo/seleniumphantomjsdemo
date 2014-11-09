var app = angular.module("spd", ["ngRoute"]);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/customers/', {
            templateUrl: spd.url.create('CustomerViews/List'),
            controller: 'customersController'
        })
        .when('/customers/:customerId', {
            templateUrl: spd.url.create('CustomerViews/Details'),
            controller: 'customerDetailsController'
        })
        .otherwise({
            redirectTo: '/customers'
        });;
}]);