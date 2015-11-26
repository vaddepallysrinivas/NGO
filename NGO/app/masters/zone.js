'use strict';

angular.module('ngo').controller('zone', zone);
zone.$inject = ['$state', '$scope', 'zoneService', 'uiGridConstants', 'modalService'];

function zone($state, $scope, zoneService, uiGridConstants, modalService) {

    var vm = {
        model: {},
        init: init,
        getZoneList: getZoneList,
        designGrid: designGrid,
        gridColumns: gridColumns,
        editRow: editRow,
        deleteRow: deleteRow,
        errorMessage: [],
        create: create,
        //save: save,
        clear: clear
        //crudNotification: crudNotification,
        //getColor: getColor

    };



    init();

    return vm;

    function init() {
        clear();
        designGrid();
        getZoneList();
    }
    function clear() {

        vm.model.zonecode = "";
        vm.model.zoneName = "";
        vm.model.isActive = false;
        vm.submitted = false;
        vm.errorMessage = []
    }

    function create() {
    }

    function save() {
    }
    function designGrid() {

        gridColumns();
        vm.gridZones = {
            enableFiltering: true,
            enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
            enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
            enableGridMenu: true,
            enableSelectAll: true,
            columnDefs: vm.model.columms
        }
    }
    function editRow(code, row) {
        vm.model.type = 2;
        vm.model.zonecode = row.entity.code;
        vm.model.zoneName = row.entity.zoneName;
        vm.model.isActive = row.entity.isActive;
    }


    function gridColumns() {

        vm.model.columms = [
           {
               name: 'edit',
               displayName: 'Edit',
               width: 50,
               enableColumnMenu: false,
               enableFiltering: false,
               pinnedLeft: true,
               cellTemplate:
           '<button class="btn btn-bcd" ng-click="grid.appScope.vm.editRow(row.entity.code,row);" href="#">&nbsp;Edit</button>'
           },
           {
               name: 'delete',
               displayName: 'Delete',
               width: 50,
               enableColumnMenu: false,
               pinnedLeft: true,
               enableFiltering: false,
               cellTemplate:
           '<button class="btn btn-bcd" ng-click="grid.appScope.vm.deleteRow(row.entity.code,row);" href="#">&nbsp;Delete</button>'
           },
            { name: 'code', displayName: "ZoneCode" },
           { name: 'zoneName', displayName: "NotificationText" },
           { name: 'isActive', displayName: "IsActive" },
           { name: 'createdBy', displayName: "CreatedBy" },
           { name: 'createdDate', displayName: "CreatedDate" },
           { name: 'modifiedBy', displayName: "ModifiedBy" },
           { name: 'modifiedDate', displayName: "ModifiedDate" },
        ]


    }

    function deleteRow(code, row) {
        vm.model.type = 4;

        var modalOptions = {
            closeButtonText: 'Cancel',
            actionButtonText: 'Delete',
            headerText: 'Delete ' + row.entity.code + '?',
            bodyText: 'Are you sure you want to delete this Code?'
        };

        modalService.showModal({}, modalOptions).then(function (result) {
            if (result == 1) {
                var objNotification = {
                    code: row.entity.code,
                    zoneName: row.entity.zoneName,
                    isActive: row.entity.isActive

                };
                // crudNotification(objNotification);
            }
        });



    }


    function getZoneList() {
        zoneService.getZoneList().then(function (res) {
            vm.gridZones.data = res.data;

            vm.gridZones.columnDefs.forEach(function (colDef) {
                var numChars = (new String(colDef.name)).length;
                colDef.width = numChars * 15;
            });
        });

    }

}