﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



//search theo ngay setup
$(document).ready(function () {
    // load data to table
    
    /*$.fn.dataTable.moment('DD/MM/YYYY HH:mm:ss tt');*/
    $("#ot").DataTable({
        paging: false,
        search: false,
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
                render: $.fn.dataTable.render.moment("YYYY-MM-DDTHH:mm:ss" & "YYYY-MM-DDTHH:mm:ss.SSSS" ,"DD/MM/YYYY HH:mm:ss a") },
            {
                "data": "startTime",
                //type: 'date',
                render: $.fn.dataTable.render.moment("YYYY-MM-DDTHH:mm:ss" & "YYYY-MM-DDTHH:mm:ss.SSSS", "DD/MM/YYYY HH:mm:ss a") 
            },   
            {
                "data": "endTime",
                //type: 'date',
                render: $.fn.dataTable.render.moment("YYYY-MM-DDTHH:mm:ss" & "YYYY-MM-DDTHH:mm:ss.SSSS", "DD/MM/YYYY HH:mm:ss a")},
            { "data": "quantity" },
            { "data": "actualQuantity" },
            {
                "data": "actualSetupStart",
                //type: 'date',
                render: $.fn.dataTable.render.moment("YYYY-MM-DDTHH:mm:ss" & "YYYY-MM-DDTHH:mm:ss.SSSS", "DD/MM/YYYY HH:mm:ss a") },
            {
                "data": "actualStartTime",
                //type: 'date',
                render: $.fn.dataTable.render.moment("YYYY-MM-DDTHH:mm:ss" & "YYYY-MM-DDTHH:mm:ss.SSSS", "DD/MM/YYYY HH:mm:ss a") },
            {
                "data": "actualEndTime",
                //type: 'date',
                render: $.fn.dataTable.render.moment("YYYY-MM-DDTHH:mm:ss" & "YYYY-MM-DDTHH:mm:ss.SSSS", "DD/MM/YYYY HH:mm:ss a") },
            { "data": "notes" },
            { "data": "orderStatus" }
        ]
      
    });

    //toggle selected
    $('#ot tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            $('#ot').DataTable().$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });
    //
});

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
            alert("Start running")
            console.log(data);
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
            alert("Start running")
            console.log(data);
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
            alert("Start running")
            console.log(data);
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
            alert("Start running")
            console.log(data);
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
            alert("Start running")
            console.log(data);
        }
    });
});
// Input Số lượng and Ghi chú
onload = function () {
    if (!document.getElementsByTagName || !document.createTextNode) return;
    var rows = document.getElementById('ot').getElementsByTagName('tbody')[0].getElementsByTagName('tr');
    for (i = 0; i < rows.length; i++) {
        rows[i].onclick = function () {
            document.getElementById("AQ").value = this.cells[10].innerHTML;
            document.getElementById("NS").value = this.cells[14].innerHTML;
        }
    }
}