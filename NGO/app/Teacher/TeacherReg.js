'use strict';

angular.module('ngo').controller('TeacherReg', TeacherReg);
TeacherReg.$inject = ['$state', '$scope'];


function TeacherReg($state, $scope) {
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

        // Set the 'submitted' flag to true
        $scope.submitted = true;

        if ($scope.RegForm.$valid) {
            alert("Form is valid!");
        }
        else {
            alert("Please correct errors!");
        }
    };
}
