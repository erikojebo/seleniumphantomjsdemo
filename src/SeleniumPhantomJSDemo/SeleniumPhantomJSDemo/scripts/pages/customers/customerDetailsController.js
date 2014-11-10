angular.module("spd").controller("customerDetailsController", function ($scope, $http, $routeParams, page) {

    page.setTitle("Customer´details");

    $http.get(spd.url.create("api/customers/" + $routeParams.customerId))
        .success(function(data) {
            $scope.customer = data;
        });
});