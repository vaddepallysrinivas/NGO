'use strict';

angular.module('ngo').controller('notification', notification);
notification.$inject = ['$state', '$scope'];

function notification($state, $scope) {

    var vm = {
        model: {},
        intit: intit,
        getNotificationsList: getNotificationsList
    };

    intit();

    return vm;

    function intit() {
    }


    function getNotificationsList() {
    }

}