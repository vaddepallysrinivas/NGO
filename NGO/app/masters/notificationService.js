'use strict'

angular.module('ngo').factory('notificationService', notificationService);

notificationService.$inject = ['$http'];

function notificationService($http) {

    var service = {
        getNotificationsList: getNotificationsList,
        getNotificationCode: getNotificationCode,
        crudNotification: crudNotification
    };

    return service;

    function getNotificationsList() {
        //  alert();
        return $http.get("ngodata/getNotificationsList");
    }
    function getNotificationCode() {
        //  alert();
        return $http.get("ngodata/getNotificationCode");
    }
    function crudNotification(objNotification) {
       
        
        var req = {
            method: 'POST',
            url: 'ngodata/crudNotification',
            data: objNotification,
        }
        return $http(req);
        
    }

 
}
