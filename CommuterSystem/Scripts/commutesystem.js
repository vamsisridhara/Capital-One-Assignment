$(document).ready(function () {
    $("#divlines").hide();
    $("#divstations").hide();
    $("#divnexttrain").hide();

    $("#btnServiceStatus").click(function () {
        getstatusoflines();
    });

    $("#btnGetLines").click(function () {
        $("#divlines").show();
        getlines();
    });

    $("#btnGetStations").click(function () {
        $("#divstations").show();
        getStations();    
    });

    if (!$('#divstations').is(':empty')) {
        $("#ddlStations").change(function () { getNexttrains(); });
    }
    
    
    if (!$('#divlines').is(':empty')) {
        $("#ddlLines").change(function () { gettrains(); });
    }

    function getstatusoflines() {
        $.ajax({
            type: "GET",
            url: '/commute/getServiceStatus',
            cache: false,
            contentType: 'application/json; charset=utf-8',
            data: '',
            success: function (data) {
                if (data && data.length > 0) {
                    $("#showlinesdata").empty();
                    var table = $('<table style="width:50%" class="table table-bordered"><tr><th>Line</th><th>Line Status</th></tr></thead></table>');
                    for (count = 0; count < data.length; count++) {
                        var tr = $("<tr>");
                        var td = $("<td>").appendTo(tr);
                        td.html(data[count]["RouteType"]);
                        var td1 = $("<td class='" + data[count]["cssclass"] + "'>").appendTo(tr);
                        td1.html(data[count]["lineStatus"]);
                        table.append(tr);
                    }
                    $("#showlinesdata").append(table);
                }
            },
            error: function (req, status, error) {
                alert("R: " + $(req) + " S: " + status + " E: " + error);
            }
        });
    }
    function getlines() {
        $.ajax({
            type: "GET",
            url: '/commute/getlines',
            cache: false,
            contentType: 'application/json; charset=utf-8',
            data: '',
            success: function (data) {
                if (data && data.length > 0) {
                    $("#ddlLines").empty();
                    $("#ddlLines").append($("<option />").val('-1').text('Select Line'));
                    $.each(data, function (key, val) {
                        var v = val;
                        $("#ddlLines").append($("<option />").val(v).text(v));
                    });
                }
            },
            error: function (req, status, error) {
                alert("R: " + $(req) + " S: " + status + " E: " + error);
            }
        });
    }
    function gettrains() {
        if ($('#ddlLines :selected').val() !== '-1') {
            $.ajax({
                type: "GET",
                url: '/commute/gettrains/' + $('#ddlLines :selected').text().trim(),
                cache: false,
                contentType: 'application/json; charset=utf-8',
                data: '',
                success: function (data) {
                    if (data && data.length > 0) {
                        $("#divtrains").empty();
                        $.each(data, function (key, val) {
                            var table = $('<table style="width:50%" class="table table-bordered"><tr><th>Service Id</th><th>Station Name</th></tr></thead></table>');
                            for (count = 0; count < data.length; count++) {
                                var tr = $("<tr>");
                                var td = $("<td>").appendTo(tr);
                                td.html(data[count]["ServiceId"]);
                                var obj = data[count]["Stops"];
                                var td1 = $("<td>").appendTo(tr);
                                td1.html(obj["StopName"]);
                                table.append(tr);
                            }
                            $("#divtrains").append(table);
                        });
                    } else {
                        $("#divtrains").empty();
                        $("#divtrains").html("No trains");
                    }
                },
                error: function (req, status, error) {
                    alert("R: " + $(req) + " S: " + status + " E: " + error);
                }
            });
        }
    }
    function getNexttrains() {
        if ($('#ddlStations :selected').val() != '-1') {
            $.ajax({
                type: "GET",
                url: '/commute/getnexttrains/' + $('#ddlStations :selected').text().trim(),
                cache: false,
                contentType: 'application/json; charset=utf-8',
                data: '',
                success: function (data) {
                    $("#divnexttrain").show();
                    if (data) {
                        $('#lblNextTrain').html("Next Arriving Train:" + data);
                    } else {
                        $('#lblNextTrain').html("No next trains");
                    }
                },
                error: function (req, status, error) {
                    alert("R: " + $(req) + " S: " + status + " E: " + error);
                }
            });
        }
    }
    function getStations() {
        $.ajax({
            type: "GET",
            url: '/commute/getstationnames',
            cache: false,
            contentType: 'application/json; charset=utf-8',
            data: '',
            success: function (data) {
                if (data && data.length > 0) {
                    $("#ddlStations").empty();
                    $("#ddlStations").append($("<option />").val('-1').text('Select Line'));
                    for (count = 0; count < data.length; count++) {
                        $("#ddlStations").append($("<option />").val(data[count]["StationName"]).text(data[count]["StationName"]));
                    }
                }
            },
            error: function (req, status, error) {
                alert("R: " + $(req) + " S: " + status + " E: " + error);
            }
        });

    }

});

