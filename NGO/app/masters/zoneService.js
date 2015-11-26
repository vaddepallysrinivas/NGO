'use strict'

angular.module('ngo').factory('zoneService', notificationService);

zoneService.$inject = ['$http'];

function zoneService($http) {

    var service = {
        getZoneList: getZoneList,
        getNotificationCode: getNotificationCode,
        crudNotification: crudNotification
    };

    return service;

    function getZoneList() {
        //  alert();
        return $http.get("ngodata/getZoneList");
    }
    function getZoneCode() {
        //  alert();
        return $http.get("ngodata/getZoneCode");
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
