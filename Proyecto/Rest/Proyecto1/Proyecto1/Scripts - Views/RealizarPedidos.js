var rPedidos = angular.module('RPedidos', []);
rPedidos.controller("rPedidosController", function ($scope, $http, $location) {
    $http.get('http://localhost:64698/api/Sucursal/GetAllSucursales')
        .then(function (response) {
            console.log("Geting");
            $scope.sucursales = response.data;
            console.log("Geted");
        });
});