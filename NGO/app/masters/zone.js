'use strict';

angular.module('ngo').controller('zone', notification);
zone.$inject = ['$state', '$scope', 'zoneService', 'uiGridConstants', 'modalService'];

function zone($state, $scope, notificationService, uiGridConstants, modalService) {

    var vm = {
        model: {},
        init: init,
        getZoneList: getZoneList,
        designGrid: designGrid,
        gridColumns: gridColumns,
        editRow: editRow,
        deleteRow: deleteRow,
        create: create,
        save: save,
        clear: clear,
        crudNotification: crudNotification,
        getColor: getColor

    };

    init();

    return vm;

    function save(ncForm) {
        vm.submitted = true;
        if (ncForm.$valid) {

            var objNotification = {
                code: vm.model.notificationCode,
                notificationText: vm.model.notificationText,
                feeAmount: vm.model.feeAmount,
                isActive: vm.model.isActive,
                type: vm.model.type
            };

            crudNotification(objNotification, vm.model.type);

        }
    }
    function editRow(code, row) {
        vm.model.type = 2;
        vm.model.notificationCode = row.entity.code;
        vm.model.notificationText = row.entity.notificationText;
        vm.model.feeAmount = row.entity.feeAmount;
        vm.model.isActive = row.entity.isActive;
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
                    notificationText: row.entity.notificationText,
                    feeAmount: row.entity.feeAmount,
                    type: vm.model.type
                };
                crudNotification(objNotification);
            }
        });



    }

    function crudNotification(objNotification) {

        notificationService.crudNotification(objNotification).then(function (res) {
            var message = '';
            if (vm.model.type == 1)
                message = "saved";
            else if (vm.model.type == 2)
                message = "updated";
            else if (vm.model.type == 4)
                message = "Deleted";

            var modalOptions = {
                closeButtonText: '',
                actionButtonText: 'Ok',
                headerText: 'Message',
                bodyText: 'Record ' + message + ' successfully.....!'
            };

            modalService.showModal({}, modalOptions).then(function (result) {
                getNotificationsList();
                clear();
            });




        });

    }


    function clear() {

        vm.model.notificationCode = "";
        vm.model.notificationText = "";
        vm.model.feeAmount = "";
        vm.model.isActive = false;
        vm.submitted = false;
    }

    function create() {
        clear();
        notificationService.getNotificationCode().then(function (res) {
            vm.model.notificationCode = res.data;
        });

    }


    function init() {
        vm.model.type = 1;
        clear();
        designGrid();
        getNotificationsList();
    }


    function designGrid() {

        gridColumns();
        vm.gridNotifications = {
            enableFiltering: true,
            enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
            enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
            enableGridMenu: true,
            enableSelectAll: true,
            onRegisterApi: function (gridApi) {
                vm.model.gridApi = gridApi;
                // vm.model.gridApi.selection.on.rowSelectionChanged($scope, bindRowData);
            },
            columnDefs: vm.model.columms
        }
    }

    function getColor(row, col) {
        if (col.entity.isActive == true) {
            return 'green';
        }
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
             { name: 'code', displayName: "code", cellClass: function (row, col) { return vm.getColor(row, col) } },
            { name: 'notificationText', displayName: "NotificationText", cellClass: function (row, col) { return vm.getColor(row, col) } },
            { name: 'feeAmount', displayName: "FeeAmount", cellClass: function (row, col) { return vm.getColor(row, col) } },
            { name: 'isActive', displayName: "IsActive", cellClass: function (row, col) { return vm.getColor(row, col) } },
            { name: 'createdBy', displayName: "CreatedBy", cellClass: function (row, col) { return vm.getColor(row, col) } },
            { name: 'createdDate', displayName: "CreatedDate", cellClass: function (row, col) { return vm.getColor(row, col) } },
            { name: 'modifiedBy', displayName: "ModifiedBy", cellClass: function (row, col) { return vm.getColor(row, col) } },
            { name: 'modifiedDate', displayName: "ModifiedDate", cellClass: function (row, col) { return vm.getColor(row, col) } },
        ]


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