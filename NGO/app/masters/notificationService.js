'use strict'

angular.module('ngo').factory('notificationService', notificationService);

notificationService.$inject = ['$http'];

function notificationService($http) {

    var service = {
        getNotificationsList: getNotificationsList
    };

    return service;

    function getNotificationsList() {
        //  alert();
        return $http.get("bcd/ae/note");
    }


    function search(companyName, searchBy) {

        var params = {
            companyName: companyName,
            searchBy: searchBy
        };

        var req = {
            method: 'POST',
            url: 'bcd/ae/company/',
            data: params,
        }
        return $http(req);
    }

 
}
