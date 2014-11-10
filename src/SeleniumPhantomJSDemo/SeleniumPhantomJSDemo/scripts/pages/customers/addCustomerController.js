angular.module("spd").controller("addCustomerController", function ($scope, $http, $location, page) {

    page.setTitle("Add customer");

    $scope.customer = {};

    $scope.add = function () {
        $http.post(spd.url.create("api/customers/"), $scope.customer)
        .success(function() {
            $location.path("/customers");
        }).error(function() {
            
        });
    }
});