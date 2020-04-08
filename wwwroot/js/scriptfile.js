var selectedrow = null;
/**dummy car data  */
var cardata = [
    { 'model_year': '2013', 'make': 'Acura', 'model': 'RDX', 'overall': '4', 'overall_front': '4', 'front_driver': '4', 'front_passenger': '4', 'overall_side': '5', 'side_driver': '4', 'side_passenger': '4', 'rollover': '3', 'rollover_possibility': '0', 'side_pole': '5', 'complaints_count': '62', 'recalls_count': '3' },
    { 'model_year': '2014', 'make': 'Jeep', 'model': 'GRANDCHEROKEE', 'overall': '5', 'overall_front': '5', 'front_driver': '5', 'front_passenger': '5', 'overall_side': '5', 'side_driver': '4', 'side_passenger': '4', 'rollover': '4', 'rollover_possibility': '0.2', 'side_pole': '5', 'complaints_count': '1428', 'recalls_count': '15' },
    { 'model_year': '2018', 'make': 'Acura', 'model': 'RDX', 'overall': '5', 'overall_front': '5', 'front_driver': '5', 'front_passenger': '5', 'overall_side': '2', 'side_driver': '2', 'side_passenger': '2', 'rollover': '4', 'rollover_possibility': '0.16', 'side_pole': '4', 'complaints_count': '14', 'recalls_count': '1' },
    { 'model_year': '2018', 'make': 'Jeep', 'model': 'RDX', 'overall': '2', 'overall_front': '2', 'front_driver': '2', 'front_passenger': '2', 'overall_side': '2', 'side_driver': '2', 'side_passenger': '2', 'rollover': '3', 'rollover_possibility': '0.155', 'side_pole': '4', 'complaints_count': '14', 'recalls_count': '1' },
    { 'model_year': '1990', 'make': 'Jeep', 'model': 'LIBERTY', 'overall': '3', 'overall_front': '3', 'front_driver': '3', 'front_passenger': '3', 'overall_side': '2', 'side_driver': '1', 'side_passenger': '1', 'rollover': '3', 'rollover_possibility': '0.228', 'side_pole': '3', 'complaints_count': '171', 'recalls_count': '2' }
]

var top5cars = [
    { 'model_year': '2020', 'make': 'Acura', 'model': 'RDX', 'overall': '5', 'overall_front': '4', 'overall_side': '5', 'rollover': '4', 'rollover_possibility': '0', },
    { 'model_year': '2020', 'make': 'Jeep', 'model': 'GRANDCHEROKEE', 'overall': '5', 'overall_front': '5', 'overall_side': '5', 'rollover': '4', 'rollover_possibility': '0.103' },
    { 'model_year': '2020', 'make': 'Acura', 'model': 'RDX', 'overall': '5', 'overall_front': '5', 'overall_side': '4', 'rollover': '4', 'rollover_possibility': '0.16' },
    { 'model_year': '2020', 'make': 'Jeep', 'model': 'RDX', 'overall': '5', 'overall_front': '4', 'overall_side': '4', 'rollover': '3', 'rollover_possibility': '0.155' },
    { 'model_year': '2020', 'make': 'Jeep', 'model': 'LIBERTY', 'overall': '4', 'overall_front': '4', 'overall_side': '4', 'rollover': '4', 'rollover_possibility': '0.128' }
]

/*function to fill table to show results of the searched paramters*/
/* the Read part of CRUD */
function buildTable(data) {
    var table = document.getElementById('displaytable')
    table.innerHTML = ''
    for (var i = 0; i < data.length; i++) {
        var row = `<tr>
            <td>${data[i].model_year}</td>
            <td>${data[i].make}</td>
            <td>${data[i].model}</td>
            <td>${data[i].overall}</td>
            <td>${data[i].overall_front}</td>
            <td>${data[i].front_driver}</td>
            <td>${data[i].front_passenger}</td>
            <td>${data[i].overall_side}</td>
            <td>${data[i].side_driver}</td>
            <td>${data[i].side_passenger}</td>
            <td>${data[i].rollover}</td>
            <td>${data[i].rollover_possibility}</td>
            <td>${data[i].side_pole}</td>
            <td>${data[i].complaints_count}</td>
            <td>${data[i].recalls_count}</td>
        </tr>`
        table.innerHTML += row;
        console.log('here');
    }
}
/*search functioncalled within car function - to return searched for content in the check yours html*/
/**is called from the submit button on the checkyours.html  */
function carsearch() {
    var yr = document.getElementById("inyear")
    var make = document.getElementById("inmake")
    var model = document.getElementById("inmodel")

    if (make.value != '') {
        var make1 = make.value.toLowerCase()
    }
    else {
        var make1 = make.value
    }
    if (model.value != '') {
        var model1 = model.value.toLowerCase()
    }
    else {
        var model1 = model.value
    }

    var data = searchfunction(yr.value, make1, model1, cardata);
    buildTable(data);
}
/**actual searchfunction searching for everything that required by the user*/

function searchfunction(yr, make, model, cardata) {
    var filterdata = []
    for (var i = 0; i < cardata.length; i++) {
        var car_model = cardata[i].model.toLowerCase();
        var car_make = cardata[i].make.toLowerCase();
        console.log(car_make);
        console.log(make);
        if (yr == '' && make == '' && model == '') {
            break;
        }
        else if (yr == '' && make == '' && model != '') {
            if (model == car_model) {
                filterdata.push(cardata[i])
            }
        }
        else if (yr == '' && make != '' && model == '') {
            if (make == car_make) {
                filterdata.push(cardata[i])
            }
        }
        else if (yr != '' && make == '' && model == '') {

            if (yr == cardata[i].model_year) {
                filterdata.push(cardata[i])
            }
        }
        else if (yr == '' && make != '' && model != '') {
            if (model == car_model && make == car_make) {
                filterdata.push(cardata[i])
            }
        }
        else if (yr != '' && make == '' && model != '') {
            if (model == car_model && yr == cardata[i].model_year) {
                filterdata.push(cardata[i])
            }
        }
        else if (yr != '' && make != '' && model == '') {
            if (make == car_make && yr == cardata[i].model_year) {
                filterdata.push(cardata[i])
            }
        }
        else {
            if (yr == cardata[i].model_year && make == car_make && model == car_model) {
                filterdata.push(cardata[i])
            }
        }
    }
    console.log(filterdata)
    return filterdata;
}

/*Create part of CRUD*/
/*function to show hide the popup*/
function popupfunction() {
    document.querySelector(".popup").style.display = "flex";
}
function popofffunction() {
    document.querySelector(".popup").style.display = "none";
}

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