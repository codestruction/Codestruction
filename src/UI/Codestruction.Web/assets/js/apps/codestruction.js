'use strict';
var app = angular.module('Codestruction', []);


// ==========================================================================
//   TEMPLATES - DYNAMICALLY ADDED CONTENT TO DOM
// ========================================================================== 

angular.module('Codestruction').controller("ListingController", function ($scope, $http) {

    var vm = this;

    vm.url = angular.element("#data-url").val();

    vm.indicators = {};
    vm.indicators.isBusy = false;

    vm.results = [];

    vm.loadMore = function () {

        if (!vm.indicators.isBusy) {

            vm.indicators.isBusy = true;

            $http.get(vm.url).then(function (response) {

                vm.url = response.data.DataUrl;
                angular.forEach(response.data.Data, function (value, key) {
                    vm.results.push(value);
                });
                vm.indicators.isBusy = false;

            });
        };
    };

    vm.hasMoreResults = function () {
        return vm.url != null && vm.url != "" && !vm.indicators.isBusy;
    };
   

});
