﻿var main = angular.module('Main', []);

main.controller("mainController", function mainController($scope, $http, $location) {
    $http.get('http://localhost:64698/api/Persona/GetPersona?id=' + window.localStorage.getItem("id"))
        .then(function (response) {
            console.log("Geting");
            $scope.perfil = response.data;
            console.log("Geted");
        });
    $scope.addEnf = function () {
        window.location = "http://localhost:64698/mywebsite/addenf.html";
    };
});

main.controller("misEnfController", function misEnfController($scope, $http) {
    $http.get('http://localhost:64698/api/EnfermedadxPersona/GetMisEnfermedades?id=' + window.localStorage.getItem("id"))
        .then(function (response) {
            console.log("Geting");
            $scope.misenfermedades = response.data;
            console.log("Geted");
        });
});
