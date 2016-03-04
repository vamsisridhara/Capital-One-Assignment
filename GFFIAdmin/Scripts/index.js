$(document).ready(function () {
    var oTable = $('#myDataTable').dataTable({
        "bServerSide": true,
        "sAjaxSource": "/JQueryDataTable/AjaxHandler",
        "bProcessing": true,
        "aoColumns": [
                        {
                            "sName": "ID",
                            "visible": false,
                            "bSearchable": false,
                            "bSortable": false
                        },
			            { "sName": "COMPANY_NAME" },
			            { "sName": "ADDRESS" },
			            { "sName": "TOWN" },
                        {
                            "sName": "Dummy",
                            "bSearchable": false,
                            "bSortable": false
                        }
        ],
        "fnCreatedRow": function (nRow, aData, iDataIndex) {
            var id = aData[0];
            $('td:eq(3)', nRow).append("<button class='btn btn-small btn-primary' onclick='javascript:alert();'>Monitor</button>");
        }
    });
});
