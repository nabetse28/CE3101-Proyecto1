var main = angular.module('Main', []);
main.controller("mainController", function ($scope, $http, $location) {


    console.log(window.localStorage.getItem("id"));

});