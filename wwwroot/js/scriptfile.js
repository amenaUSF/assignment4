var selectedrow = null;
/**dummy car data  */

var top5cars = [
    { 'model_year': '2020', 'make': 'Acura', 'model': 'RDX', 'overall': '5', 'overall_front': '4', 'overall_side': '5', 'rollover': '4', 'rollover_possibility': '0', },
    { 'model_year': '2020', 'make': 'Jeep', 'model': 'GRANDCHEROKEE', 'overall': '5', 'overall_front': '5', 'overall_side': '5', 'rollover': '4', 'rollover_possibility': '0.103' },
    { 'model_year': '2020', 'make': 'Acura', 'model': 'RDX', 'overall': '5', 'overall_front': '5', 'overall_side': '4', 'rollover': '4', 'rollover_possibility': '0.16' },
    { 'model_year': '2020', 'make': 'Jeep', 'model': 'RDX', 'overall': '5', 'overall_front': '4', 'overall_side': '4', 'rollover': '3', 'rollover_possibility': '0.155' },
    { 'model_year': '2020', 'make': 'Jeep', 'model': 'LIBERTY', 'overall': '4', 'overall_front': '4', 'overall_side': '4', 'rollover': '4', 'rollover_possibility': '0.128' }
]


/*Create part of CRUD*/

/** function to add comments to the table */
function addrow() {
    var data = readrow();
    if (selectedrow == null)
        createrow(data);
    else
        updaterow(data);
    resetform();
}
/**function to read comments from the form  */
function readrow() {
    var data = {};
    data["Name"] = document.getElementById("name").value;
    data["Email"] = document.getElementById("email").value;
    data["Comment"] = document.getElementById("UserComments").value;
    return data;
}
/**function to reset the form  */
function resetform() {
    document.getElementById("name").value = "";
    document.getElementById("email").value = "";
    document.getElementById("UserComments").value = "";
    selectedrow = null;
}
/** function to create a new row in the table
 */
function createrow(data) {
    var table = document.getElementById("commenttable").getElementsByTagName('tbody')[0];
    var newrow = table.insertRow(table.length);
    cell1 = newrow.insertCell(0);
    cell1.innerHTML = data.Name;
    cell2 = newrow.insertCell(1);
    cell2.innerHTML = data.Email;
    cell3 = newrow.insertCell(2);
    cell3.innerHTML = data.Comment;
    cell4 = newrow.insertCell(3);
    cell4.innerHTML = `<a onclick="onEditClick(this)"style="cursor: pointer;"> <i class="fas fa-edit" style="color:cornflowerblue; background:white; font-size:1vw;"></i></a>  <a onclick="deleterow(this)" style="cursor: pointer;"> <i class="fas fa-trash" style="color:red; background:white; font-size:1vw;"></i></a>`
}

/*for Update part of CRUD*/
function onEditClick(td) {
    selectedrow = td.parentElement.parentElement;
    document.getElementById("name").value = selectedrow.cells[0].innerHTML;
    document.getElementById("email").value = selectedrow.cells[1].innerHTML;
    document.getElementById("UserComments").value = selectedrow.cells[2].innerHTML;

    popupfunction();
}

function updaterow(data) {
    selectedrow.cells[0].innerHTML = data.Name;
    selectedrow.cells[1].innerHTML = data.Email;
    selectedrow.cells[2].innerHTML = data.Comment;
}
/*Delete part of CRUD*/
function deleterow(td) {
    row = td.parentElement.parentElement;
    row.remove();
    resetform();
}

/*for the top 5 cars of the year page*/
function displaytop5() {
    var table = document.getElementById('top5carsdisplay')
    table.innerHTML = '';
    for (var i = 0; i < top5cars.length; i++) {
        var row = `<tr>
            <td>${top5cars[i].model_year}</td>
            <td>${top5cars[i].make}</td>
            <td>${top5cars[i].model}</td>
            <td>${top5cars[i].overall}</td>
            <td>${top5cars[i].overall_front}</td>
            <td>${top5cars[i].overall_side}</td>
            <td>${top5cars[i].rollover}</td>
            <td>${top5cars[i].rollover_possibility}</td>
        </tr>`
        table.innerHTML += row;
    }
}