const MONTHS = [
    "Enero",
    "Febrero",
    "Marzo",
    "Abril",
    "Mayo",
    "Junio",
    "Julio",
    "Agosto",
    "Septiembre",
    "Octubre",
    "Noviembre",
    "Diciembre",
];

const DAYS = [
    "Domingo",
    "Lunes",
    "Martes",
    "Miercoles",
    "Jueves",
    "Viernes",
    "Sábado",

];
var today = new Date();
document.getElementById('date_info').innerHTML = DAYS[today.getDay()] + " " + today.getDate()
    + " de " + MONTHS[today.getMonth()] + " de " + today.getFullYear() + "  " + today.getHours()
    + ":" + today.getMinutes() + ":" + today.getSeconds();

function loadFunctionaryRegister() {
   // loadAreas()
}

function loadScheduleDates() {
    loadProcesses()
}

function loadProfessionalDashboardInfo() {
    loadProcesses();
    loadDates();
};

function loadAdministratorConsult() {
    loadProcesses();
};

/*Se consulta por los procesos registrados y se tienen que cargar en el response cono options*/
function loadProcesses() {
    response = "<option value= \" 1 \"> Proceso1  </option>";
    response += "<option value= \" 2 \"> Proceso2  </option>";
    response += "<option value= \" 3 \"> Proceso3  </option>";
    processes = document.getElementById("process");
    processes.innerHTML = response;
};

function loadAreas() {
    response = "<option value= \" 1 \"> Area1  </option>";
    response += "<option value= \" 2 \"> Area2  </option>";
    response += "<option value= \" 3 \"> Area3  </option>";
    areas = document.getElementById("area");
    areas.innerHTML = response;
};

function loadDates() {
    var a = document.createElement('a');
    var linkText = document.createTextNode("cita1");
    a.appendChild(linkText);
    a.href = "/User/ShowDateDetail";
    var element = document.getElementById("L8am");
    element.appendChild(a);

}

function goBack() {
    window.history.back();
}


function modifyProfessionalUrl(identification) {
    window.location.href = '/User/MainProfessionalUpdateAdministrator?login=' + identification;
}

function modifyInformationProfessional() {
    var cedula = document.getElementById("Cedula").value;
    var name = document.getElementById("name").value;
    var firstLastName = document.getElementById("firstLastName").value;
    var secondLastName = document.getElementById("secondLastName").value;
    var personalPhone = document.getElementById("personalPhone").value;
    var RoomPhone = document.getElementById("RoomPhone").value;
    var birthday = document.getElementById("birthday").value;
    var gender = document.getElementById("gender").value;
    var civilStatus = document.getElementById("civilStatus").value;
    var placeNumber = document.getElementById("placeNumber").value;
    var stateValue;

    if (document.getElementById('active').checked) {
        stateValue = 0;
    } else {
        stateValue = 1;
    }
    
    var EmergencyContact = document.getElementById("EmergencyContact").value;    
    var contactNumber = document.getElementById("EmergencyContactNumber").value;
    var scholarship = document.getElementById("scholarship").value;
    var specialty = document.getElementById("specialty").value;
    var schoolCode = document.getElementById("schoolCode").value;
    var province = document.getElementById("province").value;
    var canton = document.getElementById("canton").value;
    var district = document.getElementById("district").value;
    var address = document.getElementById("address").value;
    
    var process = [];
    $.each($("#process option:selected"), function () {
        process.push($(this).val());
    });

    var parameters =
    {
        "cedula": cedula,
        "name": name,
        "firstLastName": firstLastName,
        "secondLastName": secondLastName,
        "personalPhone": personalPhone,
        "RoomPhone": RoomPhone,
        "birthday": birthday,
        "gender": gender,
        "civilStatus": civilStatus,
        "placeNumber": placeNumber,
        "Status": stateValue,
        "process": process,
        "EmergencyContact": EmergencyContact,
        "contactNumber": contactNumber,
        "scholarship": scholarship,
        "specialty": specialty,
        "schoolCode": schoolCode,
        "province": province,
        "canton": canton,
        "district": district,
        "address": address


    };
    $.ajax(
        {
            data: parameters,
            url: '/User/MainProfessionalUpdateAdministrator',
            type: 'post',
            beforeSend: function () {
                $("#resultado").html("Procesando, espere por favor ...");
            },
            success: function (response) {
                $("#resultado").html("Modificado con éxito");

            }
        }
    );
}


function registerProfessional() {    
    var cedula = document.getElementById("Cedula").value;
    var name = document.getElementById("name").value;
    var firstLastName = document.getElementById("firstLastName").value;
    var secondLastName = document.getElementById("secondLastName").value;
    var personalPhone = document.getElementById("personalPhone").value;
    var RoomPhone = document.getElementById("RoomPhone").value;
    var birthday = document.getElementById("birthday").value;
    var gender = document.getElementById("gender").value;
    var civilStatus = document.getElementById("civilStatus").value;
    var placeNumber = document.getElementById("placeNumber").value;
    
    var stateValue;

    if (document.getElementById('active').checked) {
        stateValue = 0;
    } else {
        stateValue = 1;
    }

  
    var process = [];
    $.each($("#process option:selected"), function () {
        process.push($(this).val());
    });
    var EmergencyContact = document.getElementById("EmergencyContact").value;
    var contactNumber = document.getElementById("EmergencyContactNumber").value;
    var scholarship = document.getElementById("scholarship").value;
    var specialty = document.getElementById("specialty").value;
    var schoolCode = document.getElementById("schoolCode").value;
    var province = document.getElementById("province").value;
    var canton = document.getElementById("canton").value;
    var district = document.getElementById("district").value;
    var address = document.getElementById("address").value;

    var parameters =
    {
        "cedula": cedula,
        "name": name,
        "firstLastName": firstLastName,
        "secondLastName": secondLastName,
        "personalPhone": personalPhone,
        "RoomPhone": RoomPhone,
        "birthday": birthday,
        "gender": gender,
        "civilStatus": civilStatus,
        "placeNumber": placeNumber,
        "Status": stateValue,
        "process": process,
        "EmergencyContact": EmergencyContact, 
        "EmergencyContactNumber": contactNumber,
        "scholarship": scholarship,
        "specialty": specialty,
        "schoolCode": schoolCode,
        "province": province,
        "canton": canton,
        "district": district,
        "address": address


    };
    $.ajax(
        {
            data: parameters,
            url: '/User/MainProfessionalRegisterAdministrator',
            type: 'post',
            beforeSend: function () {
                $("#resultado").html("Procesando, espere por favor ...");                
            },
            success: function (response) {
                $("#resultado").html("Registrado con éxito");
                
            }
        }
    );

}

function saveAppointment() {
    var FunctionaryId = document.getElementById("FunctionaryId").value;
    var Date = document.getElementById("Date").value;
    var Hour = document.getElementById("Hour").value;
    var ProfessionalId = document.getElementById("ProfessionalId").value;
    var Patient = document.getElementById("Patient").value;
    var State = document.getElementById("State").value;
    var SubprocessId = document.getElementById("SubprocessId").value;
   // var Assistance = document.getElementById("Assistance").value;
  //  var SubActivityId = document.getElementById("SubActivityId").value;

    var parameters =
    {
        "FunctionaryId" : FunctionaryId,
        "Date": Date,
        "Hour": Hour,
        "ProfessionalId": ProfessionalId,
        "Patient": Patient,
        "State": State,
        "SubprocessId": SubprocessId,
        "Assistance": 1,
        "SubActivityId": 1
    };
    $.ajax(
        {
            data: parameters,
            url: '/Appointment/SaveAppointment',
            type: 'post',
            success: function (response) {
                location.href = "/Appointment/DateConfirmationHome";
            }

        }
    );
}