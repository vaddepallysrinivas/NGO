'use strict';

angular.module('ngo').controller('notification', notification);
notification.$inject = ['$state', '$scope'];

function notification($state, $scope) {

    var vm = {
        model: {},
        intit:intit,
        getNotificationsList: getNotificationsList
    };

    init();

    return vm;

    function intit() {
    }


    function getNotificationsList() {
    }

}