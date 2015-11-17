'use strict'

angular.module('ngo').factory('TeacherRegSercice', TeacherRegSercice);

TeacherRegSercice.$inject = ['$http'];

function TeacherRegSercice($http) {

    var service = {
        getDistricts: getDistricts,
        getZones: getZones,
        getMandals: getMandals
    };

    return service;

    function getDistricts() {
        //  alert();
        return $http.get("ngodata/getDistricts");
    }

    function getZones(districtID) {

        var params = {
            ID: districtID
        };

        var req = {
            method: 'POST',
            url: 'ngodata/loadZones',
            data: params,
        }
        return $http(req);
    }

    function getMandals(districtID) {

        var params = {
            ID: districtID
        };

        var req = {
            method: 'POST',
            url: 'ngodata/loadMandals',
            data: params,
        }
        return $http(req);
    }

}
