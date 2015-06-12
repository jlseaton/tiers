var appMainModule = angular.module('appMain', []);

appMainModule.controller('userViewModel', function ($scope, $http, $location) {
    $scope.title = 'Users:';

    $scope.users = [
        { ID: 1, Name: "User 1", Data: 1.1 },
        { ID: 2, Name: "User 2", Data: 2.2 }
    ];

    $scope.showUser = function (user) {
        alert('Selected: ' + user.Name);
    };

    $scope.loading = true;
    $scope.editMode = false;

    $http.get('http://localhost:58228/api/users').success(function (data) {
        $scope.users = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading users!";
        $scope.loading = false;
    });
});
