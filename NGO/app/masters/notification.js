'use strict';

angular.module('ngo').controller('notification', notification);
notification.$inject = ['$state', '$scope', 'notificationService', 'uiGridConstants'];

function notification($state, $scope, notificationService, uiGridConstants) {

    var vm = {
        model: {},
        init: init,
        getNotificationsList: getNotificationsList,
        designGrid: designGrid,
        gridColumns: gridColumns
    };

    init();

    return vm;

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
            enableRowSelection: true,
            enableFiltering: true,
            enableSelectAll: true,
            selectionRowHeaderWidth: 35,
            rowHeight: 35,
            showGridFooter: true,
            //onRegisterApi: function (gridApi) {
            //    vm.model.gridApi = gridApi;
            //    vm.model.gridApi.selection.on.rowSelectionChanged($scope, bindRowData);
            //},
            columnDefs: vm.model.columms
        }
    }



    function gridColumns() {

        vm.model.columms = [
              { name: 'NotificationId', displayName: "NotificationId" },
              { name: 'code', displayName: "code" },
              { name: 'NotificationText', displayName: "NotificationText" },
              { name: 'StartDate', displayName: "StartDate" },
              { name: 'EndDate', displayName: "EndDate" },
              { name: 'FeeAmount', displayName: "FeeAmount" },
              { name: 'CreatedBy', displayName: "CreatedBy" },
              { name: 'CreatedDate', displayName: "CreatedDate" },
              { name: 'ModifiedBy', displayName: "ModifiedBy" },
              { name: 'ModifiedDate', displayName: "ModifiedDate" },
              { name: 'Del_ind', displayName: "Del_ind" }]

    }



    function getNotificationsList() {
        notificationService.getNotificationsList().then(function (res) {
            vm.gridNotifications.data = res;
        });

    }

}