app.controller("createListController", function ($scope, $http, $window) {
    $scope.ItemsCount = 0;

    $scope.continueCreatingList = function () {
        $scope.enableAddingListItems = true;
        $scope.enableCreatingList = false;
    };

    $scope.backToCreatingList = function () {
        $scope.enableAddingListItems = false;
        $scope.enableCreatingList = true;
    };

    $scope.addItemToList = function () {
        $scope.ItemsCount++;

        var item = {
            Name: $scope.NewItem.Name,
            Description: $scope.NewItem.Description,
            ImageString: $scope.NewItem.ImageString,
            DisableEdit: true,
            ID: $scope.ItemsCount
        };

        $scope.ItemsList.push(item);
        $scope.clearNewItem();
    };

    $scope.deleteListItem = function (item) {
        var index = $scope.ItemsList.indexOf(item);
        if (index > -1) {
            $scope.ItemsList.splice(index, 1);
        }
    };

    $scope.editListItem = function (item) {
        item.DisableEdit = false;
    };

    $scope.saveListItem = function (item) {
        item.DisableEdit = true;
    };

    $scope.saveList = function () {
        $scope.List.Items = $scope.ItemsList;

        var _data = JSON.stringify({ list: $scope.List });

        var post = $http({
            method: "POST",
            url: "/List/SaveList",
            dataType: 'json',
            data: _data,
            headers: { "Content-Type": "application/json" }
        }).then(function (response) {
            //todo
            //Some Kind of Message
            window.location.href = "/";
            return;
        }, function (err) {
            return;
        });
    };

   $scope.setItemImage = function (input, Item) {
        if (input.files && input.files[0]) {
            var currIndex = 0;
            var arr = [];
            for (var i = 0; i < input.files.length; i++) {
                var reader = new FileReader();

                arr.push(input.files[i].name);
                reader.onload = function(e) {
                    //$('#NewItem_Image').attr('src', e.target.result);
                    //$scope.NewItem.Image = e.target.result;

                    $scope.$apply(function() {
                        $scope.NewItem.ImageString = e.target.result;
                        var str = arr[currIndex++];
                        $scope.NewItem.Name = str.substr(0, str.lastIndexOf('.'));
                        $scope.addItemToList();
                    });
                };

                reader.readAsDataURL(input.files[i]);
            }
        }
    };

    $scope.updateMultiple = function() {
        var multiCBox = document.getElementById("multi");
        var fileInput = document.getElementById("NewItem_ImageInput");

        fileInput.multiple = multiCBox.checked;
    }

    $scope.changeItemPicture = function (input) {
        var item = $scope.getItemByID($scope.getIDFromInput(input));

        if (item != null)
            $scope.setItemImage(input, item);
    }

    $scope.getItemByID = function (ID) {
        for (var i = 0; $scope.ItemsList.length; i++)
            if ($scope.ItemsList[i].ID == ID)
                return $scope.ItemsList[i];
        return null;
    };

    $scope.getIDFromInput = function (input) {
        return input.id.substring(16);
    }

    $scope.clearNewItem = function () {
        $scope.NewItem = {};
        document.getElementById("NewItem_Image").src = "../../Assets/Images/defaultImage.png";
    };

    $scope.disabilityOfNextButton = function () {
        if ($scope.List && $scope.List.Name && $scope.List.ItemTypeName)
            return false;
        return true;
    }

    $scope.disabilityOfAddItemToList = function () {
        if ($scope.NewItem && $scope.NewItem.Name)
            return false;
        return true;
    }

    $scope.disabilityOfSaveList = function () {
        if ($scope.ItemsList && $scope.ItemsList.length >= 2 && $scope.ItemsList.all(function (item) {
            if (!item.Name)
                return false;
            return true;
        }))
            return false;
        return true;
    }

    function init() {
        $scope.ItemsList = [];
        $scope.privacyItems = [
            { value: true, text: "Private" },
            { value: false, text: "Public" }
        ];
        $scope.List = {};
        $scope.List.IsPrivate = false;
        $scope.clearNewItem();

        $scope.enableAddingListItems = false;
        $scope.enableCreatingList = true;
    }

    init();
});
