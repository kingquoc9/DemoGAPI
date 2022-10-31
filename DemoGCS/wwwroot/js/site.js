// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// load data to table
$(document).ready(function () {
  


    $("#wot").DataTable({
        "ajax": {
            "type":"GET",
            "url": "https://localhost:7093/api/orders",
            "dataType": "json",
            "dataSrc":"",
        },

        "columns": [

            { "data": "ordersId" },
            { "data": "ordersName" },
            { "data": "machinesId" },
            { "data": "product" },
            { "data": "resourceGroupName" },
            { "data": "resourceName" },
            { "data": "setupStart" },
            { "data": "startTime" },
            { "data": "endTime" },
            { "data": "quantity" },
            { "data": "actualQuantity" },
            { "data": "note" },
            { "data": "actusalSetupStart" },
            { "data": "status" }
        ]
    
    });
    //toggle selected
    $('#wot tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            $('#wot').DataTable().$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });
    //
});

var currentdate = new Date();
var datetime =  currentdate.getFullYear() + "-"
    + (currentdate.getMonth() + 1) + "-"
    + currentdate.getDate() + "T"
    + currentdate.getHours() + ":"
    + currentdate.getMinutes() + ":"
    + currentdate.getSeconds();

// start button
$('#Start').click(function () {
    var t = $('#wot').DataTable();
    var sr = JSON.stringify(t.rows('.selected').data().toArray());
    var ts = sr.substring(1, sr.length - 1);// cut this"[]" out to get the object
    var tts = JSON.parse(ts);
    var dt = {
        "ordersId": tts.ordersId,
        "ordersName": tts.ordersName,
        "machinesId": tts.machinesId,
        "product": tts.product,
        "resourceGroupName": tts.resourceGroupName,
        "resourceName": tts.resourceName,
        "setupStart": tts.setupStart,
        "startTime": tts.startTime,
        "endTime": tts.endTime,
        "quantity": tts.quantity,
        "actualQuantity": tts.actualQuantity,
        "note": tts.note,
        "actusalSetupStart": datetime,
        "status": "Starting setup"
    };
    var dts = JSON.stringify(dt);
    console.log(dts);
    $.ajax({
        type: 'PUT',
        url: 'https://localhost:7093/api/orders',
        headers: {
            'Content-Type': 'application/json'
        },
        dataType: 'json',
        data: dts,
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
    var t = $('#wot').DataTable();
    var sr = JSON.stringify(t.rows('.selected').data().toArray());
/*    var sr = JSON.stringify(t.rows('.selected').data().toArray());*/
    var ts = sr.substring(1, sr.length - 1);// cut this"[]" out to get the object
    console.log(ts);
    $.ajax({
        type: 'PUT',
        url: 'https://localhost:7093/api/orders',
        headers: {
            'Content-Type': 'application/json'
        },
        dataType:'json',
        data: ts,
            success: function (data) {
                
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