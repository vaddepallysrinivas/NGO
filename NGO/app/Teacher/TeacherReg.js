'use strict';

angular.module('ngo').controller('TeacherReg', TeacherReg);
TeacherReg.$inject = ['$state', '$scope', 'TeacherRegSercice'];


function TeacherReg($state, $scope, TeacherRegSercice) {

    $scope.init = function () {
        $scope.hideErrors = false;
        TeacherRegSercice.getDistricts().then(function (res) {
            $scope.schoolDistrictList = res.data;
        });
    }

    $scope.init();

    $scope.loadZoneMandals = function (districtCode) {
        TeacherRegSercice.getZones(districtCode).then(function (res) {
            $scope.ScholZoneList = res.data;
        });
        TeacherRegSercice.getMandals(districtCode).then(function (res) {
            $scope.schoolMandalList = res.data;
        });
    }



    $scope.countryList = [
     { CountryId: 1, Name: 'India' },
     { CountryId: 2, Name: 'USA' }
    ];

    $scope.genderList = [
   { genderId: 1, Name: 'Male' },
   { genderId: 2, Name: 'Female' }
    ];

    $scope.cityList = [];

    $scope.$watch('user.country', function (newVal, oldVal) {

        if (newVal == 1)
            $scope.cityList = [
                                { CountryId: 1, CityId: 1, Name: 'Noida' },
                                { CountryId: 1, CityId: 2, Name: 'Delhi' }];
        else if (newVal == 2)
            $scope.cityList = [
                               { CountryId: 2, CityId: 3, Name: 'Texas' },
                               { CountryId: 2, CityId: 4, Name: 'NewYork' }];
        else
            $scope.cityList = [];
    });

    // function to submit the form after all validation has occurred			
    $scope.submitForm = function () {


        // Set the 'hideErrors' flag to true
        $scope.hideErrors = true;

        if ($scope.RegForm.$valid) {

            var params = {
                firstName: $scope.user.firstName,
                middleName: $scope.user.middleName,
                lastName: $scope.user.lastName,
                email: $scope.user.email,
                selectedGenderId: $scope.user.selectedGenderId,
                contactno: $scope.user.contactno,
                schoolName: $scope.user.schoolName,
                schoolAdd: $scope.user.schoolAdd,
                schoolDistrictId: $scope.user.schoolDistrictId,
                ScholZoneId: $scope.user.ScholZoneId,
                schoolMandalid: $scope.user.schoolMandalid,
                schoolVillage: $scope.user.schoolVillage
            };


            TeacherRegSercice.saveTeacherDetails(params).then(function (res) {

                $scope.hideErrors = false;

                $scope.user.firstName = '';
                $scope.user.middleName = '';
                $scope.user.lastName = '';
                $scope.user.email = '';
                $scope.user.selectedGenderId = '';
                $scope.user.contactno = '';
                $scope.user.schoolName = '';
                $scope.user.schoolAdd = '';
                $scope.user.schoolDistrictId = '';
                $scope.user.ScholZoneId = '';
                $scope.user.schoolMandalid = '';
                $scope.user.schoolVillage = '';

                $scope.message = res.data;
            });
        }
    };
}
