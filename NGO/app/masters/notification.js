'use strict';

angular.module('ngo').controller('notification', notification);
notification.$inject = ['$state', '$scope', 'notificationService', 'uiGridConstants'];

function notification($state, $scope, notificationService, uiGridConstants) {

    var vm = {
        model: {},
        init: init,
        getNotificationsList: getNotificationsList,
        designGrid: designGrid,
        gridColumns: gridColumns,
        editRow: editRow,
        create: create,
        save: save,
        clear:clear

    };

    init();

    return vm;

    function save() {
    }
    function clear() {

        vm.model.notificationCode = "";
        vm.model.notificationText = "";
        vm.model.feeAmount = "";
        vm.model.isActive = false;

    }

    function create() {
        clear();
        notificationService.getNotificationCode().then(function (res) {
            vm.model.notificationCode = res.data.code;
        });

    }


    function init() {
        designGrid();
        getNotificationsList();
    }


    function designGrid() {

        gridColumns();
        vm.gridNotifications = {
            enableColumnResizing: true,
            enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
            enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
            //enableRowSelection: true,
          //  enableFiltering: true,
            //enableSelectAll: true,
            selectionRowHeaderWidth: 35,
            rowHeight: 35,
            showGridFooter: true,
            onRegisterApi: function (gridApi) {
                vm.model.gridApi = gridApi;
                // vm.model.gridApi.selection.on.rowSelectionChanged($scope, bindRowData);
            },
            columnDefs: vm.model.columms
        }
    }



    function gridColumns() {

        vm.model.columms = [
            {
                name: 'edit',
                displayName: 'Edit',
                width: 50,
                enableColumnMenu: false,
                pinnedLeft: true,
                cellTemplate:
            '<button class="btn btn-primary btn-xs" ng-click="grid.appScope.vm.editRow(row.entity.code,row);" href="#">&nbsp;Edit</button>'
            },
             { name: 'code', displayName: "code" },
            { name: 'notificationText', displayName: "NotificationText" },
            { name: 'feeAmount', displayName: "FeeAmount" },
            { name: 'isActive', displayName: "IsActive" },
            { name: 'createdBy', displayName: "CreatedBy" },
            { name: 'createdDate', displayName: "CreatedDate" },
            { name: 'modifiedBy', displayName: "ModifiedBy" },
            { name: 'modifiedDate', displayName: "ModifiedDate" }]


    }

    function editRow(companyContactId, row) {
        vm.model.notificationCode = row.entity.code;
        vm.model.notificationText = row.entity.notificationText;
        vm.model.feeAmount = row.entity.feeAmount;
        vm.model.isActive = row.entity.isActive;
    }



    function getNotificationsList() {
        notificationService.getNotificationsList().then(function (res) {
            vm.gridNotifications.data = res.data;
            vm.gridNotifications.columnDefs.forEach(function (colDef) {
                var numChars = (new String(colDef.name)).length;
                colDef.width = numChars * 12;
            });
        });

    }

}