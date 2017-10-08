var app = angular.module('myApp', []);
app.controller('myController', ['Route',function ($scope, $http) {
    $scope.id = $scope.id;
    $scope.password = $scope.password;

    $scope.log = function (id, password) {
        console.log("Ya entre");
        console.log(id, password);
        $http.get("http://localhost:64698/api/Persona/SignInVerification?id=" + id + "&" + "contraseña=" + password)
            .then(function (response) {
                $scope.res = response;
                if (response.data == true) {
                    console.log("Logged");
                } else {
                    console.log("The Id and password are not correct");
                }
            });


    };
}]);

app.config("Route", function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "main.html"
        })
        .when("/register", {
            templateUrl: "register.html"
        });

});