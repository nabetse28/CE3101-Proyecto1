﻿var medicamentos = angular.module('Medicamentos', []);
medicamentos.controller("medicamentosController", function ($scope, $http, $location) {
    $scope.medValues;
    $scope.lastId;
    $http.get('http://localhost:64698/api/MedicamentoxSucursal/GetMedicamentoxSucursal?id=' + window.localStorage.getItem("idSucursal"))
        .then(function (response) {
            console.log("IdSuc", window.localStorage.getItem("idSucursal"));
            $scope.medValues = response.data;
            $scope.medicamentosid = $scope.medValues;
        }); 
    
    $scope.rePedido = function () {
        var pedido = {
            IdCedula: window.localStorage.getItem("id"),
            IdSucursal: window.localStorage.getItem("idSucursal"),
            Estado: 0
        }
        $http.post("http://localhost:64698/api/Pedido/PostPedido", pedido)
            .then(function successCallback(response) {
                console.log(response);
                $http.get('http://localhost:64698/api/Pedido/GetLastPedidoId')
                    .then(function (response) {
                        $scope.lastId = response.data;
                    }); 
                angular.forEach($scope.medValues, function (value, key) {
                    var strIdElem = 'med' + value.IdMedicamento;
                    var cantidadMed = angular.element(document.getElementById(strIdElem)).val();
                    if (cantidadMed > 0 && cantidadMed != '') {
                        var PedidoxMedicamento = {
                            IdPedido: $scope.lastId,
                            IdMedicamento: value.IdMedicamento,
                            Cantidad: cantidadMed,
                            RecetaImg: null
                        };
                        $http.post("http://localhost:64698/api/PedidoxMedicamento/PostPedidoxMedicamento", PedidoxMedicamento)
                            .then(function successCallback(response) {
                                console.log(response);
                            }, function errorCallback(response) {
                                console.log(response);
                            });
                    }
                });
            }, function errorCallback(response) {
                console.log(response);
            });
        
        
    };

});
