var main = angular.module('Main', []);
main.controller("mainController", function ($scope, $http, $location) {

    $scope.id = window.localStorage.getItem("id");



});