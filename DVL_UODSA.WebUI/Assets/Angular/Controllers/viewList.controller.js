app.controller("viewListController", function ($scope, $http, $window) {

    $scope.changeView = function () {
        if ($scope.listView) {
            $scope.listView = false;
            $scope.gridView = true;
        }
        else {
            $scope.listView = true;
            $scope.gridView = false;
        }
    };

    function init() {
        $scope.listView = true;
        $scope.gridView = false;
    }

    init();
});