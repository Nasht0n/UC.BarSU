$("body").on("click", "#btnAdd", function () {
    var txtDegree = $("#txtDegree");
    var txtStatus = $("#txtStatus");
    var txtFullname = $("#txtFullname");
    var txtPost = $("#txtPost");

    if (txtDegree.val() != "" || txtStatus.val() != "" || txtFullname.val() != "" || txtPost.val() != "") {
        var ddManager = document.getElementById("ddManager");

        var tBody = $("#tblEmployees > TBODY")[0];
        var row = tBody.insertRow(-1);
        var cell = $(row.insertCell(-1));
        cell.html(txtDegree.val());
        cell = $(row.insertCell(-1));
        cell.html(txtStatus.val());
        cell = $(row.insertCell(-1));
        cell.html(txtFullname.val());
        cell = $(row.insertCell(-1));
        cell.html(txtPost.val());
        cell = $(row.insertCell(-1));
        cell.html(ddManager.options[ddManager.selectedIndex].text);
        cell = $(row.insertCell(-1));
        var btnRemove = $("<input />");
        btnRemove.attr("type", "button");
        btnRemove.attr("onclick", "Remove(this);");
        btnRemove.addClass("btn btn-danger");
        btnRemove.val("Удалить");
        cell.append(btnRemove);
        txtDegree.val("");
        txtStatus.val("");
        txtFullname.val("");
        txtPost.val("");
        ddManager.value = 2;

    } else {
        alert("Ошибка добавления исполнителя в состав проекта. Проверьте правильность заполнения полей");
    }
});

function Remove(button) {
    var row = $(button).closest("TR");
    var name = $("TD", row).eq(2).html();
    if (confirm("Вы хотите удалить: " + name + " из состава исполнителей проекта?")) {
        var table = $("#tblEmployees")[0];
        table.deleteRow(row[0].rowIndex);
    }
};

$("body").on("click", "#btnSave", function () {
    console.log($("#Department").val());
    var model = {
        Id: $("#Id").val(),
        StateId: $("#StateId").val(),
        UserId: $("#UserId").val(),
        SelectedFaculty: $("#Faculty").val(),
        SelectedDepartment: $("#Department").val(),
        OrderNumber: $("#OrderNumber").val(),
        OrderDate: $("#OrderDate").val(),
        RegistrationNumber: $("#RegistrationNumber").val(),
        RegistrationDate: $("#RegistrationDate").val(),
        Name: $("#Name").val(),
        Program: $("#Program").val(),
        StartDate: $("#StartDate").val(),
        EndDate: $("#EndDate").val(),
        Price: $("#Price").val()
    };
    var employees = [];
    console.log(model);

    $("#tblEmployees TBODY TR").each(function () {
        var row = $(this);
        var employee = {
            Degree: row.find("TD").eq(0).html(),
            Status: row.find("TD").eq(1).html(),
            Fullname: row.find("TD").eq(2).html(),
            Post: row.find("TD").eq(3).html(),
            IsManager: row.find("TD").eq(4).html().includes("Да")
        };
        employees.push(employee);
    });
    model.Casts = employees;

    var json = JSON.stringify(model);
    $.ajax({
        type: "POST",
        url: "/SP/AddScienceProject",
        data: json,
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        traditional: true,
        success: function (data) {
            document.location.href = "/SP/Index";
        }
    });
});