// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// load data to table
//$(document).ready(function () {



//    $("#wot").DataTable({
//        "ajax": {
//            "type":"GET",
//            "url": "https://localhost:7093/api/orders",
//            "dataType": "json",
//            "dataSrc":"",
//        },

//        "columns": [

//            { "data": "ordersId" },
//            { "data": "ordersName" },
//            { "data": "machinesId" },
//            { "data": "product" },
//            { "data": "resourceGroupName" },
//            { "data": "resourceName" },
//            { "data": "setupStart" },
//            { "data": "startTime" },
//            { "data": "endTime" },
//            { "data": "quantity" },
//            { "data": "actualQuantity" },
//            { "data": "note" },
//            { "data": "actusalSetupStart" },
//            { "data": "status" }
//        ]

//    });
//    //toggle selected
//    $('#wot tbody').on('click', 'tr', function () {
//        if ($(this).hasClass('selected')) {
//            $(this).removeClass('selected');
//        } else {
//            $('#wot').DataTable().$('tr.selected').removeClass('selected');
//            $(this).addClass('selected');
//        }
//    });
//    //
//});

//var currentdate = new Date();
//var datetime = currentdate.getFullYear(0) + "-"
//    + ("0" + (currentdate.getMonth(0) + 1)).slice(-2) + "-"
//    + ("0" + currentdate.getDate(0)).slice(-2) + "T"
//    + ("0" + currentdate.getHours(0)).slice(-2) + ":"
//    + ("0" + currentdate.getMinutes(0)).slice(-2) + ":"
//    + ("0" + currentdate.getSeconds(0)).slice(-2) + "."
//    + ("0" + currentdate.getMilliseconds()).slice(-2);

//// start button
//$('#Start').click(function () {
//    var t = $('#wot').DataTable();
//    var sr = JSON.stringify(t.rows('.selected').data().toArray());
//    var ts = JSON.parse(sr.substring(1, sr.length - 1));// cut this"[]" out to get the object
//    var dt = JSON.stringify({
//        "ordersId": ts.ordersId,
//        "ordersName": ts.ordersName,
//        "machinesId": ts.machinesId,
//        "product": ts.product,
//        "resourceGroupName": ts.resourceGroupName,
//        "resourceName": ts.resourceName,
//        "setupStart": ts.setupStart,
//        "startTime": ts.startTime,
//        "endTime": ts.endTime,
//        "quantity": ts.quantity,
//        "actualQuantity": ts.actualQuantity,
//        "note": ts.note,
//        "actusalSetupStart": datetime,
//        "status": "Starting setup"
//    });

//    console.log(dt);
//    $.ajax({
//        type: 'PUT',
//        url: 'https://localhost:7093/api/orders',
//        headers: {
//            'Content-Type': 'application/json;'
//        },
//        dataType: 'json',
//        data: dt,
//        success: function (data) {
//            alert("Start running")
//            console.log(data);
//        }
//    });

//});
//// Pasue button
//$('#Pause').click(function () {

//});
//// Start setup button
//$('#StartS').click(function () {
//    var t = $('#wot').DataTable();
//    var sr = JSON.stringify(t.rows('.selected').data().toArray());
///*    var sr = JSON.stringify(t.rows('.selected').data().toArray());*/
//    var ts = sr.substring(1, sr.length - 1);// cut this"[]" out to get the object
//    console.log(ts);
//    $.ajax({
//        type: 'PUT',
//        url: 'https://localhost:7093/api/orders',
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        dataType:'json',
//        data: ts,
//            success: function (data) {

//                console.log(data);
//            }
//        });


//});
//// Complete button
//$('#Complete').click(function () {

//});
//// Cancel button
//$('#Cancel').click(function () {

//});

//Test code

// Get od by Id
//var t = $('#wot').DataTable();
//var idx = JSON.stringify(t.cell('.selected', 0).data());
//console.log(idx);
//var urlx = "https://localhost:7093/api/orders/" + idx;
//$.ajax({
//    type: 'GET',
//    url: urlx,
//    dataType: 'json',

//    success: function (data) {
//        alert(data);
//        console.log(data);
//    }
//});


$(document).ready(function () {
    var t = $('ot').DataTable();
    $("#ot").DataTable({
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
            { "data": "setupStart" },
            { "data": "startTime" },
            { "data": "endTime" },
            { "data": "quantity" },
            { "data": "actualQuantity" },
            { "data": "actualSetupStart" },
            { "data": "actualStartTime" },
            { "data": "actualEndTime" },
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

});
// Cancel button
$('#Cancel').click(function () {

});