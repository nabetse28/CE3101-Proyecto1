var pedidos = angular.module('Pedidos', []);
pedidos.controller("pedidosController", function ($scope, $http, $location) {
    $http.get('http://localhost:64698/api/Pedido/GetPedidos?id=' + window.localStorage.getItem("id"))
        .then(function (response) {
            console.log("Geting");
            $scope.pedidosid = response.data;
            console.log("Geted");
        });
});