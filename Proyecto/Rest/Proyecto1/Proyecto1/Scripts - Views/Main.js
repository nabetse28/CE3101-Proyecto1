var main = angular.module('Main', []);

main.controller("mainController", function ($scope, $http, $location) {
    $http.get('http://localhost:64698/api/Persona/GetPersona?id=' + window.localStorage.getItem("id"))
        .then(function (response) {
            console.log("Geting");
            $scope.perfil = response.data;
            console.log("Geted");
        });
});


