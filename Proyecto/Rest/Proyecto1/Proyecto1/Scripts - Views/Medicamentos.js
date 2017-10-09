var medicamentos = angular.module('Medicamentos', []);
medicamentos.controller("medicamentosController", function ($scope, $http, $location) {
    $http.get('http://localhost:64698/api/MedicamentoxSucursal/GetMedicamentoxSucursal?id=' + window.localStorage.getItem("idSucursal"))
        .then(function (response) {
            console.log("IdSuc", window.localStorage.getItem("idSucursal"));
            $scope.medicamentosid = response.data;
        });
});