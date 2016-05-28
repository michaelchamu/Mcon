
var leaderCount = 0;
var localCount = 0;
var contCount = 0;
var actCount = 0;
                 
function resetLoc() {
    $("#projDet").removeAttr("hidden");
    $("#loc").attr("hidden", "hidden");
    $("#projBtnNext").removeAttr("disabled");
}

function loadLoc() {
            
    var input = '';

    input = '<input class="form-control" id="thisProject_ProjectLeader" name="thisProject.ProjectLeader" type="text" value="' + $('#projLeader').val() + '" />';
    input += '<input class="form-control" id="thisProject_ProjectName" name="thisProject.ProjectName" type="text" value="' + $('#projName').val() + '" />';
    input += '<input class="form-control" id="thisProject_ProjectStatus" name="thisProject.ProjectStatus" type="text" value="' + $('#projStatus').val() + '" />';
    input += '<input class="form-control" id="thisProject_SiteVisits" name="thisProject.SiteVisits" type="text" value="' + $('#visits').val() + '" />';
    input += '<input class="form-control" id="thisProject_ActualVisits" name="thisProject.ActualVisits" type="text" value="' + $('#actualVisits').val() + '" />';
    input += '<input class="form-control" id="thisProject_StartDate" name="thisProject.StartDate" type="text" value="' + $('#startdate').val() + '" />';
    input += '<input class="form-control" id="thisProject_EndDate" name="thisProject.EndDate" type="text" value="' + $('#enddate').val() + '" />';

    document.getElementById("hiddenModel").innerHTML = input;

    $("#leaderBox").removeAttr("hidden");
    $("#LeadNum").html("<center><p> " + leaderCount + ".</p></center>");
    $("#projLead").html("<center><p> " + $("#projLeader").val() + "</p></center>");
    $("#projStat").html("<center><p> " + $("#projStatus").val() + "</p></center>");
    $("#projDet").attr("hidden", "hidden");
    $("#loc").removeAttr("hidden");
           
    document.getElementById("projBtnNext").disabled = true;
    leaderCount++;
}

function addBox() {
    //get values from all textboxes
    var projectRow;
    var index;
    var innerText = '';
    var hiddenText = '';
    
    //Add Locality to the hidden section
    hiddenText = '<input class="form-control" id="projectLocs_' + localCount + '__LocalityName" name="projectLocs[' + localCount + '].LocalityName" type="text" value="' + $('#locName').val() + '" />';

    //populate table with location values
    innerText += '<tr id="locRow' + localCount + '"><td><center>' + localCount + '</center></td>';
    innerText += '<td><center>' + $('#locName').val() + '</center></td>';
    innerText += '<td><center><button class="btn-sm btn-block btn-warning btn-flat" type="button" onclick="removeLoc(' + localCount + ')"><b>X</b></button></center></td></tr>';

    document.getElementById("listOfLocations").innerHTML += innerText;
    document.getElementById("hiddenModel").innerHTML += hiddenText;
    document.getElementById("locName").value = '';

    localCount++;
}

function resetCont() {
    $("#loc").removeAttr("hidden");
    $("#cont").attr("hidden", "hidden");
    $("#locBtnBack").removeAttr("disabled");
    $("#locBtnNext").removeAttr("disabled");
}

function loadCont() {
    $("#loc").attr("hidden", "hidden");
    $("#cont").removeAttr("hidden");
    document.getElementById("locBtnBack").disabled = true;
    document.getElementById("locBtnNext").disabled = true;
}

function addCon() {
    //get textbox values
    var index, innerText, hiddenText;

    //Add Contractor to the hidden section
    hiddenText = '<div id="cont_'+contCount+'"><input class="form-control" id="projectsConts_' + contCount + '__CompanyName" name="projectsConts[' + contCount + '].CompanyName" type="text" value="' + $('#compName').val() + '" />';
    hiddenText += '<input class="form-control" id="projectsConts_' + contCount + '__ContractorName" name="projectsConts[' + contCount + '].ContractorName" type="text" value="' + $('#contName').val() + '" />';
    hiddenText += '<input class="form-control" id="projectsConts_' + contCount + '__ContractorSurname" name="projectsConts[' + contCount + '].ContractorSurname" type="text" value="' + $('#contSurn').val() + '" />';
    hiddenText += '<input class="form-control" id="projectsConts_' + contCount + '__ContractorTel" name="projectsConts[' + contCount + '].ContractorTel" type="text" value="' + $('#contTel').val() + '" />';

    innerText = '';

    innerText += '<tr id="contRow_' + contCount + '">';
    innerText += '<td id=""><center>' + contCount + '</center></td>';
    innerText += '<td id=""><center>' + $('#compName').val() + '</center></td>';
    innerText += '<td id=""><center>' + $('#contName').val() + '</center></td>';
    innerText += '<td id=""><center>' + $('#contSurn').val() + '</center></td>';
    innerText += '<td id=""><center>' + $('#contTel').val() + '</center></td>';
    innerText += '<td id=""><center><button class="btn-sm btn-block btn-warning btn-flat" type="button" onclick="removeCont(' + contCount + ')"><b>X</b></button></center></td></tr>';

    document.getElementById("listofcontractors").innerHTML += innerText;
    document.getElementById("hiddenModel").innerHTML += hiddenText;

    $('#compName').val('');
    $('#contName').val('');
    $('#contSurn').val('');
    $('#contTel').val('');
    contCount++;
}

function resetAct() {
    $("#cont").removeAttr("hidden");
    $("#act").attr("hidden", "hidden");
    $("#contBtnBack").removeAttr("disabled");
    $("#contBtnNext").removeAttr("disabled");
}

function loadAct() {
    $("#cont").attr("hidden", "hidden");
    $("#act").removeAttr("hidden");
    document.getElementById("contBtnBack").disabled = true;
    document.getElementById("contBtnNext").disabled = true;
}

function addAction()
{
    var innerText, hiddenText;

    hiddenText = '<div id="act_' + actCount + '"><input class="form-control" id="projectActions_' + actCount + '__ActionDesc" name="projectActions[' + actCount + '].ActionDesc" type="text" value="' + $('#actName').val() + '" />';
    hiddenText += '<input class="form-control" id="projectActions_' + actCount + '__Status" name="projectActions[' + actCount + '].Status" type="text" value="' + $('#actStatus').val() + '" />';

    innerText += '<tr id="actRow' + actCount + '">';
    innerText += '<td id=""><center>' + actCount + '</center></td>';
    innerText += '<td id=""><center>' + $('#actName').val() + '</center></td>';
    innerText += '<td id=""><center>' + $('#actStatus').val() + '</center></td>';
    innerText += '<td id=""><center><button class="btn-sm btn-block btn-warning btn-flat" type="button" onclick="removeAct(' + actCount + ')"><b>X</b></button></center></td></tr>';

    document.getElementById("listOfActions").innerHTML += innerText;
    document.getElementById("hiddenModel").innerHTML += hiddenText;

    $('#actName').val('');
    $('#actStatus').val('');

    actCount++;
}

function removeAct(id) {
    $('#actRow' + id).remove();
    $('#projectLocs_' + id + '__LocalityName').remove();
    //Call Recalc function only if the element being removed is not the last element in list.
    if (id != localCount) {
        locNumRecalc(id);
    }
}

function actNumRecalc(index) {
    for (var i = index + 1; i < actCount; i++) {
        //Change the index of the HTML elements
        $('#act_' + i).attr('id', 'cont_' + (i - 1));
        $('#projectActions_' + i + '__ActionDesc').attr('id', 'projectActions_' + (i - 1) + '__ActionDesc');
        $('#projectActions_' + i + '__ActionDesc').attr('name', 'projectActions_[' + (i - 1) + '].ActionDesc');

        $('#projectActions_' + i + '__Status').attr('id', 'projectActions_' + (i - 1) + '__Status');
        $('#projectActions_' + i + '__Status').attr('name', 'projectActions_[' + (i - 1) + '].Status');

    }
}

function removeLoc(id) {
    $('#locRow' + id).remove();
    $('#projectLocs_' + id + '__LocalityName').remove();
    //Call Recalc function only if the element being removed is not the last element in list.
    if (id != localCount) {
        locNumRecalc(id);
    }
}

function locNumRecalc(index){
    for(var i=index+1;i<localCount;i++)
    {
        //Change the index of the HTML elements
        $('#projectLocs_' + i + '__LocalityName').attr('id', 'projectLocs_' + (i - 1) + '__LocalityName');
        $('#projectLocs_' + i + '__LocalityName').attr('name', 'projectLocs[' + (i - 1) + '].LocalityName');

    }
}

function removeCont(id) {
    $('#contRow_' + id).remove();
    $("#cont_" + id).remove();
    //Call Recalc function only if the element being removed is not the last element in list.
    if (id != contCount) {
        contNumRecalc(id);
    }
}

function contNumRecalc(index) {
    for (var i = index + 1; i < localCount; i++) {
        //Change the index of the HTML elements
        $('#cont_' + i).attr('id', 'cont_' + (i - 1));
        $('#projectsConts_' + i + '__CompanyName').attr('id', 'projectsConts_' + (i - 1) + '__CompanyName');
        $('#projectsConts_' + i + '__CompanyName').attr('name', 'projectsConts[' + (i - 1) + '].CompanyName');

        $('#projectsConts_' + i + '__ContractorName').attr('id', 'projectsConts_' + (i - 1) + '__ContractorName');
        $('#projectsConts_' + i + '__ContractorName').attr('name', 'projectsConts[' + (i - 1) + '].ContractorName');

        $('#projectsConts_' + i + '__ContractorSurname').attr('id', 'projectsConts_' + (i - 1) + '__ContractorSurname');
        $('#projectsConts_' + i + '__ContractorSurname').attr('name', 'projectsConts[' + (i - 1) + '].ContractorSurname');

        $('#projectsConts_' + i + '__ContractorTel').attr('id', 'projectsConts_' + (i - 1) + '__ContractorTel');
        $('#projectsConts_' + i + '__ContractorTel').attr('name', 'projectsConts[' + (i - 1) + '].ContractorTel');

    }
    contCount--;
}