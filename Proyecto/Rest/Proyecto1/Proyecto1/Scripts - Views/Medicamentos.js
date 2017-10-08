var medicamentos = angular.module('Medicamentos', []);
medicamentos.controller("medicamentosController", function ($scope, $http, $location) {
    $http.get('http://localhost:64698/api/MedicamentoxSucursal/GetMedicamentoxSucursal?id=' + '1')
        .then(function (response) {
            console.log("Geting");
            $scope.medicamentosid = response.data;
            console.log("Geted");
        });
});