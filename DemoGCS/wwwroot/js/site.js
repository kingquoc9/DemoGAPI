// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    //load OrderNo to dropdownlist 
    $.ajax({
        type: 'GET',
        url: 'https://localhost:7093/api/PO/GetAllID',
        headers: {
            'Content-Type': 'application/json;'
        },
        dataType: 'json',
        success: function (data) {

            $.each(data, function (i, value) {
                $('#odn').append($('<option>').text(value.orderNo).attr('value', value.orderNo));
            });
            var select = new vanillaSelectBox("#odn", {
                search: true,
                placeHolder: "Chọn mã hàng",
                maxWidth: 540,
                maxHeight: 400,
                minWidth: -1,
                maxOptionWidth: 480,
                itemsSeparator: "||"
                
            });
        }
    });
    //add filter function to dropdownlist  
    $('#odn').change(function () {
        $("#ot").dataTable().fnFilter($(this).val().join("||"), 1, true, false);
    });
    // load data to table
    $("#ot").DataTable({
        
        "search": {
            "regex": true
        },
        "ajax": {
            "type": "GET",
            "url": "https://localhost:7093/api/PO/GetAll",
            "dataType": "json",
            "dataSrc": "",
        },

        "columns": [
            { "data": "ordersId" },
            { "data": "orderNo" },
            { "data": "partNo" },
            { "data": "product" },
            { "data": "resourceGroup" },
            { "data": "resource" },
            {
                "data": "setupStart",
                //type: 'date',
                render: $.fn.dataTable.render.moment("YYYY-MM-DDTHH:mm:ss" & "YYYY-MM-DDTHH:mm:ss.SSSS", "DD/MM/YYYY HH:mm:ss a")
            },
            {
                "data": "startTime",
                //type: 'date',
                render: $.fn.dataTable.render.moment("YYYY-MM-DDTHH:mm:ss" & "YYYY-MM-DDTHH:mm:ss.SSSS", "DD/MM/YYYY HH:mm:ss a")
            },
            {
                "data": "endTime",
                //type: 'date',
                render: $.fn.dataTable.render.moment("YYYY-MM-DDTHH:mm:ss" & "YYYY-MM-DDTHH:mm:ss.SSSS", "DD/MM/YYYY HH:mm:ss a")
            },
            { "data": "quantity" },
            { "data": "actualQuantity" },
            {
                "data": "actualSetupStart",
                //type: 'date',
                render: $.fn.dataTable.render.moment("YYYY-MM-DDTHH:mm:ss" & "YYYY-MM-DDTHH:mm:ss.SSSS", "DD/MM/YYYY HH:mm:ss a")
            },
            {
                "data": "actualStartTime",
                //type: 'date',
                render: $.fn.dataTable.render.moment("YYYY-MM-DDTHH:mm:ss" & "YYYY-MM-DDTHH:mm:ss.SSSS", "DD/MM/YYYY HH:mm:ss a")
            },
            {
                "data": "actualEndTime",
                //type: 'date',
                render: $.fn.dataTable.render.moment("YYYY-MM-DDTHH:mm:ss" & "YYYY-MM-DDTHH:mm:ss.SSSS", "DD/MM/YYYY HH:mm:ss a")
            },
            { "data": "notes" },
            { "data": "orderStatus" }
        ]

    });
    //set time table reload
    //setInterval(function () {
    //    $('#ot').DataTable().ajax.reload(null, false); // user paging is not reset on reload
    //}, 60000);
    setInterval(function () {
        var tb = JSON.stringify($('#ot').DataTable().data().toArray());
        $.ajax({
            type: 'GET',
            url: 'https://localhost:7093/api/PO/GetAll',
            headers: {
                'Content-Type': 'application/json;'
            },
            dataType: 'json',
            success: function (data) {
                 
                var tdb = JSON.stringify(data);
                if (tb == tdb) {
                    return;
                }
                else {
                    $('#ot').DataTable().ajax.reload(null, false);
                }
            }
        });  
                 
        
    }, 20000);
    //toggle selected
    $('#ot tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            $('#ot').DataTable().$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        };
        //bind data to 2 input element in Ghi chú and Số lượng
        var sr = JSON.stringify($('#ot').DataTable().rows('.selected').data().toArray());
        var ts = JSON.parse(sr.substring(1, sr.length - 1));// cut this"[]" out to get the object
        document.getElementById("AQ").value = JSON.stringify(ts.actualQuantity);
        document.getElementById("NS").value = JSON.stringify(ts.notes).substring(1, JSON.stringify(ts.notes).length - 1);
       
    });
    //Reset filter in date
    $('#RS').click(function () {
        $("#ot").dataTable().fnFilter($(this).val(), 6, true, false);
    });
    //Date filter  
    $('#DF').click(function () {

        $("#ot").dataTable().fnFilter($(this).val(), 6, true, false);
    });
    var now = new Date();
    var month = (now.getMonth() + 1);
    var day = now.getDate();
    if (month < 10)
        month = "0" + month;
    if (day < 10)
        day = "0" + day;
    var dt = day + '/' + month + '/' + now.getFullYear();
    $('#DF').val(dt);
    $('#DF').click();
    // ND and BD button
    $('#ND').click(function () {
        var nd = new Date(moment(document.getElementById("DF").value, "DD/MM/YYYY"));
        nd.setDate(nd.getDate() + 1);
        var month = (nd.getMonth() + 1);
        var day = nd.getDate();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        var dt = day + '/' + month + '/' + now.getFullYear();

        $('#DF').val(dt);
        $('#DF').click();
    });
    $('#BD').click(function () {
        var nd = new Date(moment(document.getElementById("DF").value, "DD/MM/YYYY"));
        nd.setDate(nd.getDate() - 1);
        var month = (nd.getMonth() + 1);
        var day = nd.getDate();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        var dt = day + '/' + month + '/' + now.getFullYear();

        $('#DF').val(dt);
        $('#DF').click();
    });
    // Calenlar button
    
        
    $('#CD').click(function () {
        $('#DF').datepicker({
            format: "dd/mm/yyyy",
            startView: "days",
            minViewMode: "days"
        });
        $('#DF').datepicker('show');
        $('#DF').change(function () { 
            $('#DF').click();
        });
    });
    // Calenlar with month

    
    $('#CDM').click(function () {
        $('#DF').datepicker({
            format: "mm/yyyy",
            startView: "months",
            minViewMode: "months"
        });
        $('#DF').datepicker('show');
        $('#DF').change(function () {
            $('#DF').click();
        });
    });
});
//

//Get currentdate time
var currentdate = new Date();
var datetime = currentdate.getFullYear(0) + "-"
    + ("0" + (currentdate.getMonth(0) + 1)).slice(-2) + "-"
    + ("0" + currentdate.getDate(0)).slice(-2) + "T"
    + ("0" + currentdate.getHours(0)).slice(-2) + ":"
    + ("0" + currentdate.getMinutes(0)).slice(-2) + ":"
    + ("0" + currentdate.getSeconds(0)).slice(-2) + "."
    + ("0" + currentdate.getMilliseconds()).slice(-2);

// start button
$('#Start').click(function () {
    var t = $('#ot').DataTable();
    var sr = JSON.stringify(t.rows('.selected').data().toArray());
    var ts = JSON.parse(sr.substring(1, sr.length - 1));// cut this"[]" out to get the object
    var did = JSON.stringify(ts.datasetId);
    var oid = JSON.stringify(ts.ordersId);
    var data = [{
        "op": "replace",
        "path": "ActualStartTime",
        "value": datetime
    },
    {
        "op": "replace",
        "path": "OrderStatus",
        "value": "5"
        }];
    
    $.ajax({
        type: 'PATCH',
        url: 'https://localhost:7093/api/PO/' + did + '/' + oid,
        headers: {
            'Content-Type': 'application/json;'
        },
        dataType: 'json',
        data: JSON.stringify(data),
        success: function (data) {
            alert("Start running")
            $('#ot').DataTable().ajax.reload();
        }
    });

});
// Pasue button
$('#Pause').click(function () {
    var t = $('#ot').DataTable();
    var sr = JSON.stringify(t.rows('.selected').data().toArray());
    var ts = JSON.parse(sr.substring(1, sr.length - 1));// cut this"[]" out to get the object
    var did = JSON.stringify(ts.datasetId);
    var oid = JSON.stringify(ts.ordersId);
    var data = [
    {
        "op": "replace",
        "path": "orderStatus",
        "value": "6"
    }];
    console.log(data)
    $.ajax({
        type: 'PATCH',
        url: 'https://localhost:7093/api/PO/' + did + '/' + oid,
        headers: {
            'Content-Type': 'application/json;'
        },
        dataType: 'json',
        data: JSON.stringify(data),
        success: function (data) {
            alert("Pausing")
            $('#ot').DataTable().ajax.reload();
        }
    });
});
// Start setup button
$('#StartS').click(function () {
    var t = $('#ot').DataTable();
    var sr = JSON.stringify(t.rows('.selected').data().toArray());
    var ts = JSON.parse(sr.substring(1, sr.length - 1));// cut this"[]" out to get the object
    var did = JSON.stringify(ts.datasetId);
    var oid = JSON.stringify(ts.ordersId);
    var data = [{
        "op": "replace",
        "path": "actualSetupStart",
        "value": datetime
    },
    {
        "op": "replace",
        "path": "orderStatus",
        "value": "4"
    }];
    console.log(data)
    $.ajax({
        type: 'PATCH',
        url: 'https://localhost:7093/api/PO/' + did + '/' + oid,
        headers: {
            'Content-Type': 'application/json;'
        },
        dataType: 'json',
        data: JSON.stringify(data),
        success: function (data) {
            alert("Starting Setup")
            $('#ot').DataTable().ajax.reload();
        }
    });

});
// Complete button
$('#Complete').click(function () {
    var t = $('#ot').DataTable();
    var sr = JSON.stringify(t.rows('.selected').data().toArray());
    var ts = JSON.parse(sr.substring(1, sr.length - 1));// cut this"[]" out to get the object
    var did = JSON.stringify(ts.datasetId);
    var oid = JSON.stringify(ts.ordersId);
    var data = [{
        "op": "replace",
        "path": "actualEndTime",
        "value": datetime
    },
    {
        "op": "replace",
        "path": "orderStatus",
        "value": "8"
    }];
    console.log(data)
    $.ajax({
        type: 'PATCH',
        url: 'https://localhost:7093/api/PO/' + did + '/' + oid,
        headers: {
            'Content-Type': 'application/json;'
        },
        dataType: 'json',
        data: JSON.stringify(data),
        success: function (data) {
            alert("Process Complete")
            $('#ot').DataTable().ajax.reload();
        }
    });
});
// Cancel button
$('#Cancel').click(function () {
    var t = $('#ot').DataTable();
    var sr = JSON.stringify(t.rows('.selected').data().toArray());
    var ts = JSON.parse(sr.substring(1, sr.length - 1));// cut this"[]" out to get the object
    var did = JSON.stringify(ts.datasetId);
    var oid = JSON.stringify(ts.ordersId);
    var data = [
    {
        "op": "replace",
        "path": "orderStatus",
        "value": "7"
    }];
    console.log(data)
    $.ajax({
        type: 'PATCH',
        url: 'https://localhost:7093/api/PO/' + did + '/' + oid,
        headers: {
            'Content-Type': 'application/json;'
        },
        dataType: 'json',
        data: JSON.stringify(data),
        success: function (data) {
            alert("Stopping")
            $('#ot').DataTable().ajax.reload();
        }
    });
});
// Input Số lượng and Ghi chú button
$('#IAN').click(function () {
 
    var sr = JSON.stringify($('#ot').DataTable().rows('.selected').data().toArray());
    var ts = JSON.parse(sr.substring(1, sr.length - 1));// cut this"[]" out to get the object
    var did = JSON.stringify(ts.datasetId);
    var oid = JSON.stringify(ts.ordersId);
    var data = [{
        "op": "replace",
        "path": "TableAttribute1",
        "value": document.getElementById("AQ").value
    },
    {
        "op": "replace",
        "path": "Notes",
        "value": document.getElementById("NS").value
    }];
    console.log(data)
    $.ajax({
        type: 'PATCH',
        url: 'https://localhost:7093/api/PO/' + did + '/' + oid,
        headers: {
            'Content-Type': 'application/json;'
        },
        dataType: 'json',
        data: JSON.stringify(data),
        success: function (data) {
            alert("Confirm Change");
            $('#ot').DataTable().ajax.reload();
        }
    });
    
});

