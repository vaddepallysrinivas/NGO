﻿

'use strict';
angular.module('ngo').config(appRoute);

appRoute.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];
function appRoute($stateProvider, $urlRouterProvider, $locationProvider) {

    $urlRouterProvider.when("", "/home");

    $stateProvider.state("home", {
        url: "/home",
        templateUrl: "app/home/Home.html"
    });
    $stateProvider.state("admin", {
        url: "/admin",
        title: "admin",
        templateUrl: "app/admin/admin.html"
        //controller: "sendSms",
        //controllerAs: "vm"
    });
    $stateProvider.state("admin.notification", {
        url: "/notification",
        title: "notification",
        templateUrl: "app/masters/notification.html",
        controller: "notification",
        controllerAs: "vm"
    });
    $stateProvider.state("admin.zone", {
        url: "/zone",
        title: "Zone",
        templateUrl: "app/masters/zone.html",
        controller: "zone",
        controllerAs: "vm"
    });


    $stateProvider.state("Teacher", {
        url: "/TeacherRegistration",
        title: "registation",
        templateUrl: "app/Teacher/Registration.html",
        controller: "TeacherReg"//,
        //controllerAs: "vm"
    });
}