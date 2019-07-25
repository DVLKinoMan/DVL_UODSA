app.controller("sortListController", function ($scope, $http, $window) {

    $scope.firstItemClick = function () {
        $scope.currentList.push($scope.firstList[$scope.selectedFirstListIndex]);

        var isFirstListLastElement = $scope.selectedFirstListIndex == $scope.firstList.length - 1;

        if (isFirstListLastElement) {
            if ($scope.selectedSecondListIndex < 1)
                $scope.currentList = $scope.currentList.concat($scope.secondList);
            else
                $scope.currentList = $scope.currentList.concat($scope.secondList.skip($scope.selectedSecondListIndex));
            $scope.lists.push($scope.currentList);

            //$scope.lists.Remove($scope.firstList);
            //$scope.lists.Remove($scope.secondList);
            $scope.lists.shift();
            $scope.lists.shift();
            $scope.currentList = [];

            if ($scope.lists.length == 1) {
                displaySortedList();
                return;
            }
            else {
                $scope.firstList = $scope.lists[0];
                $scope.secondList = $scope.lists[1];
                $scope.selectedFirstListIndex = 0;
                $scope.selectedSecondListIndex = 0;
            }
        }
        else $scope.selectedFirstListIndex++;
    }

    $scope.secondItemClick = function () {
        $scope.currentList.push($scope.secondList[$scope.selectedSecondListIndex]);

        var isSecondListLastElement = $scope.selectedSecondListIndex == $scope.secondList.length - 1;

        if (isSecondListLastElement) {
            if ($scope.selectedFirstListIndex < 1)
                $scope.currentList = $scope.currentList.concat($scope.firstList);
            else
                $scope.currentList = $scope.currentList.concat($scope.firstList.skip($scope.selectedFirstListIndex));
            $scope.lists.push($scope.currentList);

            //$scope.lists.Remove($scope.firstList);
            //$scope.lists.Remove($scope.secondList);
            $scope.lists.shift();
            $scope.lists.shift();
            $scope.currentList = [];

            if ($scope.lists.length == 1) {
                displaySortedList();
                return;
            }
            else {
                $scope.firstList = $scope.lists[0];
                $scope.secondList = $scope.lists[1];
                $scope.selectedFirstListIndex = 0;
                $scope.selectedSecondListIndex = 0;
            }
        }
        else $scope.selectedSecondListIndex++;
    }

    $scope.saveSortedList = function () {
        $scope.list.Items = $scope.sortedList;

        var _data = JSON.stringify({ list: $scope.list });

        var post = $http({
            method: "POST",
            url: "/List/SaveSortedList",
            dataType: 'json',
            data: _data,
            headers: { "Content-Type": "application/json" }
        }).then(function (response) {
            //todo
            //Some Kind of Message
            window.location.href = "/List/MySortedLists";
            return;
        }, function (err) {
            return;
        });
    };

    function getList() {
        var _data = JSON.stringify({ listID: $scope.ID });

        var get = $http({
            method: "POST",
            url: "/List/GetList",
            dataType: 'json',
            data: _data,
            headers: { "Content-Type": "application/json" }
        });

        get.success(function (data, status) {
            $scope.list = data;
            initialize();
        });

        get.error(function (data, status) {
            $window.alert(data.Message);
        });
    }

    function displaySortedList() {
        $scope.sortedList = $scope.lists[0];

        for (var i = 1; i <= $scope.sortedList.length; i++)
            $scope.sortedList[i - 1].sortedNumber = i;

        $scope.enableTwoItems = false;
        $scope.enableSortingList = true;
    }

    function initialize() {
        $scope.currentList = [];
        $scope.lists = [];

        $scope.list.Items.forEach(function (item) {
            var l = [];
            l.push(item);
            $scope.lists.push(l);
        });

        $scope.firstList = $scope.lists[0];
        $scope.secondList = $scope.lists[1];
        $scope.selectedFirstListIndex = 0;
        $scope.selectedSecondListIndex = 0;
    }

    $scope.init = function (id) {
        $scope.ID = id;
        getList();
        $scope.enableTwoItems = true;
        $scope.enableSortingList = false;
    }
});