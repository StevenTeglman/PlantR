
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