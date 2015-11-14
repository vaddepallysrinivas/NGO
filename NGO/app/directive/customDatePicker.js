(function () {
    'use strict';
    angular.module('ngo').directive('customDatePicker',
      function () {
          return {
              restrict: 'A',
              require: 'ngModel',
              scope: {
                  selectedDate: '=ngModel',
                  dateChanged: '&'

              },
              templateUrl:'/app/directive/customDatePicker.html',
              replace: true,
              transclude: true,
              link: function ($scope, elem, attr, ctrl) {
                  $scope.$on('$destroy', function () {
                      elem.remove();
                  });
              },
              controller: ['$scope', '$element', '$filter', '$timeout', function ($scope, $element, $filter, $timeout) {
                  $scope.open = 0;
                  $scope.open = function (event) {
                      event.preventDefault();
                      event.stopPropagation();
                      $scope.opened = true;
                  };

                  $scope.changed = function () {
                      $timeout(function () {
                          $scope.selectedDate = $filter('date')($scope.selectedDate, 'MM/dd/yyyy');
                          $scope.dateChanged();
                      });
                  }
              }]
          };
      });
}());