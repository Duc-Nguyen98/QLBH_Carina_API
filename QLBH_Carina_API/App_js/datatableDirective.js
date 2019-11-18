angular.module('datatable', [])


    .controller('DatatableController', ['$scope', '$attrs', '$filter', function ($scope, $attrs, $filter) {

        var sEcho = 0;

        $scope.openDateTo = function ($event, param) {
            $event.preventDefault();
            $event.stopPropagation();
            $scope[param + '_oto'] = !$scope[param + '_oto'];
        };

        $scope.openDateFrom = function ($event, param) {
            $event.preventDefault();
            $event.stopPropagation();
            $scope[param + '_ofrom'] = !$scope[param + '_ofrom'];
        };

        $scope.getTableData = function (sSource, aoData, fnCallback, oSettings) {
            /*console.log('========= sSource =========')
             console.log(sSource);
             console.log('========== aoData ==========')
             console.log(aoData);
             console.log('========== oSettings =======')
             console.log(oSettings); */

            var i = 0;
            var settings = {
                limit: oSettings._iDisplayLength,
                start: oSettings._iDisplayStart,
                total: oSettings._iRecordsTotal
            };

            var columns = [];
            for (var j = 0; j < oSettings.aoColumns.length; j++) {
                columns.push(oSettings.aoColumns[j].mDataProp);
            }

            var query = { limit: settings.limit, offset: settings.start };

            var aSortBy = [];
            $(oSettings.aaSorting).each(function (i, o) { aSortBy.push({ name: oSettings.aoColumns[o[0]].mData, value: o[1] }); });
            for (i = 0; i < aSortBy.length; i++) {
                var sortObj = aSortBy[i];
                query['sortBy[' + sortObj.name + ']'] = sortObj.value;
            }

            var aFilterBy = [];
            for (var iCol = 0; iCol < oSettings.aoPreSearchCols.length; iCol++) {
                if (oSettings.aoPreSearchCols[iCol].sSearch) {
                    aFilterBy.push({ name: columns[iCol], value: oSettings.aoPreSearchCols[iCol].sSearch });
                }
            }

            for (i = 0; i < aFilterBy.length; i++) {
                var filterObj = aFilterBy[i];
                query['filterBy[' + filterObj.name + ']'] = filterObj.value;
            }

            var controls = $scope.model.getTableControls();

            $scope.model.table(query)
                .then(function (result) {

                    var obj = {};
                    obj.sEcho = ++sEcho;
                    obj.iTotalRecords = result.data.total;
                    obj.iTotalDisplayRecords = result.data.total;

                    var list = result.data.data;
                    if (!list) {
                        fnCallback({ aaData: [] });
                        return;
                    }

                    for (var j = 0; j < list.length; j++) {
                        var item = list[j];

                        item.createDate = setAlignCenter($filter('date')(item.createDate, "dd/MM/yyyy"));

                        item.status = setAlignCenter(item.status == 1 ? '<span class="label label-success">Enabled</span>' :
                            item.status == 2 ? '<span class="label label-danger">Disabled</span>' : '<span class="label label-default">Pending</span>');

                        item.controls = '<div class="table-controls wide' + controls.num + '">' + controls.str + '</div>';

                        list[j] = item;
                    }

                    obj.aaData = list;
                    fnCallback(obj);

                });

            function setAlignCenter(val) { return '<div class="align-center not-clickable">' + String(val) + '</div>'; }


        }

    }])


    .directive('datatable', ['$http', '$compile', '_', function ($http, $compile, _) {
        var i = 0;


        return {
            scope: {
                model: '=',
                interface: '='
            },
            controller: 'DatatableController',

            link: function ($scope, $element, $attrs) {
                if (!angular.isDefined($scope.model)) { console.warn('[ERROR] Table model missing'); return null; }


                var filterBar = $compile("<tfoot><tr class='filterBar'></tr></tfoot>")($scope);
                $element.append(filterBar);

                var filterRow = filterBar.find("tr");
                var columns = $scope.model.getTableColumns();

                var columnDefs = buildColumns(columns);
                for (i = 0; i < columnDefs.length; i++) {
                    var columnHeaderClass = angular.isDefined(columns[i].class) ? columns[i].class : '';
                    if (columnDefs[i].bVisible) {
                        filterRow.append($compile("<th class=" + columnHeaderClass + ">" + getFilterControl(columnDefs[i].mDataProp) + "</th>")($scope));
                    }
                }


                var opts = {
                    autoWidth: false,
                    sDom: '<"table-length"l>rt<"bottom"ip<"clearfix">>',
                    bLengthChange: true,
                    bProcessing: true,
                    bServerSide: true,
                    sAjaxSource: "",
                    aoColumnDefs: columnDefs,

                    // --- Process click on Row ----------------------------------------------------------
                    fnRowCallback: function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
                        var id = aData.id;

                        // --- checkbox ---
                        /*$(nRow).find('input[type="checkbox"]').on('change',function(e){
                         var tr = $(this).closest('tr');
                         if ( tr.hasClass('row_selected') )   { tr.removeClass('row_selected'); }
                         else                                 { tr.addClass('row_selected'); tr.removeClass('hover'); }
                         e.stopPropagation();
                         //scope.setSelectedRowsState(scope.getSelectedRowIds().length ? 'selected' : false);
                         });*/

                        $(nRow).find('.table-controls a').on('click', function (e) {
                            $scope.interface.controllerProcessAction($(this).data('control-type'), { id: id });
                            e.stopPropagation();
                        });

                        $(nRow).on('click', function (e) {
                            var target = $(e.target);
                            //if ( target.is( "input" ) || !target.index()) {    return; }      // --- checkbox ---
                            $scope.interface.controllerProcessAction('view', { id: id });
                            e.stopPropagation();
                        });
                    },
                    // --- Get data from server ---------------------------------------------------------
                    fnServerData: function (sSource, aoData, fnCallback, oSettings) {
                        $scope.getTableData(sSource, aoData, fnCallback, oSettings);
                    }
                    // ----------------------------------------------------------------------------------
                };

                var dataTable = $element.dataTable(opts);

                // --- External interface connection ---
                if ($scope.interface || angular.isDefined($scope.interface)) {
                    //console.warn('[WARNING] Table interface missing');return null;
                    $scope.interface.directiveProcessAction = function (e) {
                        console.log('directive.directiveProcessAction ==> ', e);
                    };
                }

                // --- Filter ----------------------------------------------------------------------------------------------

                function getFilterControl(prop) {
                    var inputElement = "";
                    switch (prop) {
                        case 'controls':
                            break;
                        case 'checkbox':
                            inputElement = '<input type="checkbox" />';
                            break;
                        case 'id':
                            break;
                        default:
                        case 'name':
                            inputElement = getFilterInputElement(prop);
                            break;
                        case 'cameras':
                        case 'storage':
                        case 'users':
                            inputElement = '%';
                            break;
                        case 'status':
                            inputElement = getFilterSelectSelectedElement(prop);
                            break;
                        case 'roleId':
                            inputElement = getFilterSelectRoleElement(prop);
                            break;
                        case 'createDate':
                        case 'registerDate':
                        case 'expiryDate':
                            inputElement = getFilterDateElement(prop);
                            break;
                    }
                    return inputElement;
                }

                function getFilterInputElement(dataProp) {
                    var html = "<input type='text' class='filter-input' placeholder='search' name=" + dataProp + "  />";
                    return html;
                }


                // --- On Filter (input) -----------------------------------------------------------------------------------
                dataTable.find("tfoot input").keyup(function () {
                    var index = -1;
                    var columnName = $(this).attr('name');  // get inupt 'name' property to detect it's index in columns
                    var index = helpers.findIndexByProperty(columnDefs, 'mDataProp', columnName);
                    dataTable.fnFilter(this.value, index);
                });

                // --- On Filter (select) ----------------------------------------------------------------------------------
                $scope.setFilterSelect = function ($event, prop, value) {
                    $scope[prop + 'filterSelect'] = value;
                    var index = helpers.findIndexByProperty(columnDefs, 'mDataProp', prop);
                    if (value) dataTable.fnFilter(value, index);
                    else dataTable.fnFilter("", index, false);
                };

                $scope.rangeSelected = function (prop, range) {
                    var index = helpers.findIndexByProperty(columnDefs, 'mDataProp', prop);
                    if (range) dataTable.fnFilter(range, index);
                    else dataTable.fnFilter("", index, false);
                };


                $scope.getFilterSelectSelected = function (prop) {
                    return $scope[prop + 'filterSelect'];
                };


                // ---------------------------------------------------------------------------------------------------------
                //     Helpers
                // ---------------------------------------------------------------------------------------------------------

                function getFilterSelectSelectedElement(dataProp) {
                    return '<span class="dropdown filter-status">' +
                        '<a class="dropdown-toggle label" ng-class="{\'label-default\':getFilterSelectSelected(\'' + dataProp + '\')==3,\'label-danger\':getFilterSelectSelected(\'' + dataProp + '\')==2,\'label-success\':getFilterSelectSelected(\'' + dataProp + '\')==1}">Select ' +
                        '<span class="glyphicon glyphicon-chevron-down"></span></a>' +
                        '<ul class="dropdown-menu">' +
                        '<li ng-click="setFilterSelect($event,\'' + dataProp + '\',1)"><a><span class="label label-success">Enable</span></a></li>' +
                        '<li ng-click="setFilterSelect($event,\'' + dataProp + '\',2)"><a><span class="label label-danger">Disable</span></a></li>' +
                        '<li ng-click="setFilterSelect($event,\'' + dataProp + '\',3)"><a><span class="label label-default">Pending</span></a></li>' +
                        '<li ng-click="setFilterSelect($event,\'' + dataProp + '\',0)"><a><b class="icon-remove"></b><span style="font-size:11px;padding-left: 3px;">Cancel</span></a></li>' +
                        '</ul>' +
                        '</span>';
                }

                function getFilterSelectRoleElement(dataProp) {
                    return '<span class="dropdown filter-status">' +
                        '<a class="dropdown-toggle label" ng-class="{\'label-default\':getFilterSelectSelected(\'' + dataProp + '\')==4,\'label-success\':getFilterSelectSelected(\'' + dataProp + '\')==2,\'label-primary\':getFilterSelectSelected(\'' + dataProp + '\')==3}">' +
                        'Select ' +
                        '<span class="glyphicon glyphicon-chevron-down"></span></a>' +
                        '<ul class="dropdown-menu">' +
                        '<li ng-click="setFilterSelect($event,\'' + dataProp + '\',2)"><a><span class="label label-success">Reseller admin</span></a></li>' +
                        '<li ng-click="setFilterSelect($event,\'' + dataProp + '\',3)"><a><span class="label label-primary">Customer service</span></a></li>' +
                        '<li ng-click="setFilterSelect($event,\'' + dataProp + '\',4)"><a><span class="label label-default">Customer support</span></a></li>' +
                        '<li ng-click="setFilterSelect($event,\'' + dataProp + '\',0)"><a><b class="icon-remove"></b><span style="font-size:11px;padding-left: 3px;">Cancel</span></a></li>' +
                        '</ul>' +
                        '</span>';
                }

                function getFilterDateElement(dataProp) {
                    $scope[dataProp + "_range"] = {};
                    $scope[dataProp + "_range"].from = null;
                    $scope[dataProp + "_range"].to = null;

                    $scope.$watch(dataProp + '_range', function (val, oldVal) {

                        var from = Date.parse(val.from);
                        var to = Date.parse(val.to);

                        if (isNaN(from) && isNaN(to)) {
                            $scope.rangeSelected(dataProp, 0);
                            return;
                        }

                        to = isNaN(to) ? Date.now() : to;
                        from = isNaN(from) ? 0 : from;

                        $scope.rangeSelected(dataProp, from + ',' + to);
                    }, true);


                    return '<div class="date-pick-wrp" ><div class="date-pick">' +

                        '<input type="text" class="form-control" datepicker-popup="{{format}}" show-weeks="false" max="maxDate" ng-model="' + dataProp + '_range.from" ' +
                        'is-open="' + dataProp + '_ofrom" datepicker-options="dateOptions" ng-required="true" close-text="Close" /> ' +
                        //'<span ng-show="'+dataProp + '_range.from" class="label label-default" >{{'+dataProp+'_range.from | date:"dd/MM/yy"}}</span>' +

                        // range FROM button
                        '<button class="btn btn-default calendar" ng-click="openDateFrom($event,\'' + dataProp + '\')">' +
                        '<span class="glyphicon glyphicon-calendar"></span>' +
                        '&nbsp<b ng-show="' + dataProp + '_range.from"  >{{' + dataProp + '_range.from | date:"dd/MM/yy"}}</b>' +
                        '</button>' +
                        //'<button class="btn btn-default calendar" ng-click="openDateFrom($event,\''+dataProp+'\')"><span class="glyphicon glyphicon-calendar"></span></button><span>&nbsp</span>' +


                        //'<span ng-show="'+dataProp + '_range.to" class="label label-default" >{{'+dataProp+'_range.to | date:"dd/MM/yy"}}</span>' +
                        '<input type="text" class="form-control" datepicker-popup="{{format}}" show-weeks="false" max="maxDate" ng-model="' + dataProp + '_range.to" ' +
                        'is-open="' + dataProp + '_oto" datepicker-options="dateOptions" ng-required="true" close-text="Close" /> ' +

                        // range TO button
                        '<button class="btn btn-default calendar" ng-click="openDateTo($event,\'' + dataProp + '\')">' +
                        '<b ng-show="' + dataProp + '_range.to" >{{' + dataProp + '_range.to | date:"dd/MM/yy"}}</b>&nbsp' +
                        '<span class="glyphicon glyphicon-calendar"></span>' +
                        '</button>' +
                        //'<button class="btn btn-default calendar" ng-click="openDateTo($event,\''+dataProp+'\')"><span class="glyphicon glyphicon-calendar"></span></button>' +

                        '</div></div>';

                }

                // ---------------------------------------------------------------------------------------------------------

                var helpers = {
                    findIndexByProperty: function (list, prop, val) {
                        for (var i = 0; i < list.length; i++) {
                            if (list[i][prop] == val) return i;
                        }
                        return null;
                    }
                };

                function buildColumns(columnNames) {
                    var columnDefs = [];
                    for (var i = 0; i < columnNames.length; i++) {
                        var obj = columnNames[i];
                        var a = obj.name == 'controls' ? "1%" : "20%"
                        var defsObj = {
                            "width": a,
                            "bSortable": obj.sortable,
                            "bVisible": obj.visible != false ? true : false,
                            "mDataProp": obj.name,
                            "aTargets": [i],
                            "sTitle": "<div>" + obj.humanName + "</div>"
                        };
                        columnDefs.push(defsObj);
                    }
                    return columnDefs;
                }
            }
        };


    }]);