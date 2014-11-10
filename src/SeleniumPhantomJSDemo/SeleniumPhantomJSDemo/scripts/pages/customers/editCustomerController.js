angular.module("spd").controller("editCustomerController", function($scope, $http, $location, $routeParams, page) {

    page.setTitle("Edit customer");

    $http.get(spd.url.create("api/customers/" + $routeParams.customerId))
        .success(function(data) {
            $scope.customer = data;
        });


    $scope.save = function() {
        $http.put(spd.url.create("api/customers/"), $scope.customer)
            .success(function() {
                $location.path("/customers");
            }).error(function() {

            });
    };
});