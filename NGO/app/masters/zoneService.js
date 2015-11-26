'use strict'

angular.module('ngo').factory('zoneService', zoneService);

zoneService.$inject = ['$http'];

function zoneService($http) {

    var service = {
        getZoneList: getZoneList,
        getZoneCode: getZoneCode,
        crudZone: crudZone
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
    function crudZone(objNotification) {
       
        
        var req = {
            method: 'POST',
            url: 'ngodata/crudNotification',
            data: objNotification,
        }
        return $http(req);
        
    }

 
}
