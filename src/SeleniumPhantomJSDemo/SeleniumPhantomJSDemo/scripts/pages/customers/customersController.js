angular.module("spd").controller("customersController", function($scope, $http, page) {

    page.setTitle("Customers");

    $http.get(spd.url.create('api/customers')).success(function (customers) {

        function initializeCustomerViewModel(customer) {
            customer.fullName = function() {
                return customer.firstName + " " + customer.lastName;
            };
        }

        for (var i = 0; i < customers.length; i++) {
            initializeCustomerViewModel(customers[i]);
        }

        $scope.customers = customers;
    });
});