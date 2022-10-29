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
// start button
$('#Start').click(function () {
    
});
// Pasue button
$('#Pause').click(function () {

});
// Start setup button
$('#StartS').click(function () {
    alert(' row(s) selected');
    var t = $('#wot').DataTable();
       
        var sR = t.rows('.selected').data().toArray();
        //var SS = {
        //    ordersId = sR.ordersId;
        //    ordersName = sR.ordersName;
        //    machinesId = sR.machinesId,
        //    product = sR.product,
        //    resourceGroupName = sR.resourceGroupName,
        //    resourceName = sR.resourceName,
        //    setupStart = sR.setupStart,
        //    endTime = sR.endTime,
        //    quantity = sR.quantity,
        //    actualQuantity = sR.actualQuantity,
        //    note = sR.note,
        //    actusalSetupStart = '$.now()',
        //    status = 'Starting'
        //}
    console.log(sR);
        $.ajax({
            type: 'PUT',
            url: 'https://localhost:7093/api/orders',
            dataType: 'json',
            data: JSON.stringify(sR) ,
            success: function (data) {
                alert(json);
                console.log(json);
            }
        });
    

});
// Complete button
$('#Complete').click(function () {

});
// Cancel button
$('#Cancel').click(function () {

});