
function format(d) {
    return '<table id="table_child" cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
        '<tr>' +
        '<td>Nickname:</td>' +
        '<td><input type="text" id="row-nickname" name="row-nickname" value='+d.nName +'></td>' +
        '</tr>' +
        '<tr>' +
        '<td>Watering Cycle:</td>' +
        '<td><input type="text" id="row-wDuration" name="row-wDuration" value=' + d.wDuration + '></td>' +
        '</tr>' +
        '<tr>' +
        '<td>ID: </td>' +
        '<td id="plantId">'+ d.id +'</td>' +
        '<td><button id=updateButton>Update</button></td>' +
        '<td><button id=deleteButton>Delete</button></td>' +

        '</tr>' +
        '</table>';
}

function hubNotify() {
    // Reference the auto-generated proxy for the hub.
    var refresh = connection.connectionHub;
    // Create a function that the hub can call back to display messages.
    refresh.client.clientRefresh = function () {
        window.location.reload();
    };

    // Start the connection.
    connection.hub.start().done(function () {
        //$('#wateredButton').click(function () {
        //    // Call the refresh method on the hub.
        //   refresh.server.notifyRefresh();
        //});
    });
}