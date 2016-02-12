(function () {
    var app = angular.module('orchestration', ['ngAnimate', 'ui.bootstrap']);
    app.directive("applog", [function () {
        return {
            scope: {
                applicationLog: "="
            },
            link: function (scope, element, attributes) {
                element.bind("change", function (changeEvent) {
                    var reader = new FileReader();
                    var filename = '';
                    reader.onload = function (loadEvent) {
                        scope.$apply(function () {
                            scope.applicationLog = filename;
                        });
                    }
                    applicationLog = changeEvent.target.files[0].name;
                    reader.readAsDataURL(changeEvent.target.files[0]);
                });
            }
        }
    }]);
    app.directive("fileread", [function () {
        return {
            scope: {
                fileread: "="
            },
            link: function (scope, element, attributes) {
                element.bind("change", function (changeEvent) {
                    var reader = new FileReader();
                    var filename = '';
                    reader.onload = function (loadEvent) {
                        scope.$apply(function () {
                            scope.fileread = filename; //loadEvent.target.result;
                        });
                    }
                    filename = changeEvent.target.files[0].name;
                    reader.readAsDataURL(changeEvent.target.files[0]);
                });
            }
        }
    }]);
    app.controller('orchestrationController', function ($scope, $window) {
        $scope.ddlmonthlyoptions = [{ name: 'Monthly Data' },
                                     { name: 'Daily Data' }
        ];

        $scope.mdate = '';
        var md = $("#monthlyDate").val();
        $scope.$watch(md, function (newVal, oldVal) {
            if (newVal) {
                $scope.mdate = $("#monthlyDate").val();
            }
        });

        $scope.applicationLog = '';
        $scope.ExReports = $scope.RunPlanning = $scope.Stratify = $scope.ECDataUpdates
            = $scope.ESchedules = $scope.EDData = $scope.EMData = $scope.PurgeRunResults
            = $scope.PurgeSchedules = $scope.PurgePortfolio = false;
        //$scope.etlMapping = '';

        $scope.monthly = [{ count: 0, mapping: '', filename: '' }];
        $scope.addETLMonthly = function () {
            if (!angular.isDefined($scope.monthly) && $scope.monthly.length == 0) {
                $scope.monthly = [{ count: 0, mapping: '', filename: '' }];
            }
            var tempmonthly = { count: $scope.monthly.length, mapping: '', filename: '' };
            $scope.monthly.push(tempmonthly)
        };
        $scope.removeETLMonthly = function (row) {
            var index = -1;
            var comArr = eval($scope.monthly);
            for (var i = 0; i < comArr.length; i++) {
                if (comArr[i].count === row) {
                    index = i;
                    break;
                }
            }
            $scope.monthly.splice(index, 1);
        };

        $scope.ddldailyoptions = [{ name: 'Monthly Data' }, { name: 'Daily Data' }];
        $scope.daily = [{ count: 0, mapping: '', filename: '' }];
        $scope.addETLDaily = function () {
            if (!angular.isDefined($scope.daily) && $scope.daily.length == 0) {
                $scope.daily = [{ count: 0, mapping: '', filename: '' }];
            }
            var tempdaily = { count: $scope.daily.length, mapping: '', filename: '' };
            $scope.daily.push(tempdaily)
        };
        $scope.removeETLDaily = function (row) {
            var index = -1;
            var comArr = eval($scope.daily);
            for (var i = 0; i < comArr.length; i++) {
                if (comArr[i].count === row) {
                    index = i;
                    break;
                }
            }
            $scope.daily.splice(index, 1);
        };

        $scope.enableMonthData = $scope.enableDailyData = true;
        $scope.showMonthtab = function () {
            $scope.enableMonthData = !$scope.enableMonthData;
        };
        $scope.showDailytab = function () {
            $scope.enableDailyData = !$scope.enableDailyData;
        };
        $scope.checkAll = function () {
            $scope.ExReports = $scope.RunPlanning = $scope.Stratify = $scope.ECDataUpdates
                                = $scope.ESchedules = $scope.EDData = $scope.EMData = $scope.PurgeRunResults
                                = $scope.PurgeSchedules = $scope.PurgePortfolio = true;
        };
        $scope.uncheckAll = function () {
            $scope.ExReports = $scope.RunPlanning = $scope.Stratify = $scope.ECDataUpdates
                                = $scope.ESchedules = $scope.EDData = $scope.EMData = $scope.PurgeRunResults
                                = $scope.PurgeSchedules = $scope.PurgePortfolio = false;
        };

        $scope.planningrun = [{ count: 0, stxml: '', accxml: '' }]
        $scope.addPlanningRun = function () {
            if (!angular.isDefined($scope.planningrun) && $scope.planningrun.length == 0) {
                $scope.planningrun = [{ count: 0, stxml: '', accxml: '' }];
            }
            var tempPlanningRun = { count: $scope.planningrun.length, stxml: '', accxml: '' };
            $scope.planningrun.push(tempPlanningRun)
        };
        $scope.removePlanningRun = function (row) {
            var index = -1;
            var comArr = eval($scope.planningrun);
            for (var i = 0; i < comArr.length; i++) {
                if (comArr[i].count === row) {
                    index = i;
                    break;
                }
            }
            $scope.planningrun.splice(index, 1);
        };

        $scope.ddlSelScenarios = [{}];
        $scope.ddlStrategies = [{}];

        $scope.scenariosRpt = [{ count: 0, scenario: '', strategy: '' }];
        $scope.addScenario = function () {
            if (!angular.isDefined($scope.scenariosRpt) && $scope.scenariosRpt.length == 0) {
                $scope.scenariosRpt = [{ count: 0, scenario: '', strategy: '' }];
            }
            var tempScenario = { count: $scope.scenariosRpt.length, scenario: '', strategy: '' };
            $scope.scenariosRpt.push(tempScenario)
        };
        $scope.removeScenario = function (row) {
            var index = -1;
            var comArr = eval($scope.scenariosRpt);
            for (var i = 0; i < comArr.length; i++) {
                if (comArr[i].count === row) {
                    index = i;
                    break;
                }
            }
            $scope.scenariosRpt.splice(index, 1);
        };
    });
}());