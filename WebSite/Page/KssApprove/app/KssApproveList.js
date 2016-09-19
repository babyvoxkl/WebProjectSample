var app = angular.module('KssApproveListApp', ['ngResource']);
app.factory('Request', ['$resource', function ($resource) {
    return $resource('http://localhost:8733/api/KssAprroveService/GetApproveList/:request');
}]);
app.controller("KssApproveListController", ['$scope', 'Request',function ($scope, Request)
{
    
}]);

//app.controller('KssApproveListController', function ($scope, $http) {
//    //$http.get("/try/angularjs/data/Customers_JSON.php")
//    //.success(function (response) { $scope.names = response.records; });    

//});