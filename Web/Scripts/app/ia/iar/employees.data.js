$("body").on("click", "#btnAddEmployee", function () {
    var txtFullname = $("#txtFullname");
    var txtPost = $("#txtPost");

    if (txtFullname.val() != "" || txtPost.val() != "") {

        var tBody = $("#tblEmployees > TBODY")[0];
        var row = tBody.insertRow(-1);
        var cell = $(row.insertCell(-1));
        cell.html(txtFullname.val());
        cell = $(row.insertCell(-1));
        cell.html(txtPost.val());
        cell = $(row.insertCell(-1));
        var btnRemove = $("<input />");
        btnRemove.attr("type", "button");
        btnRemove.attr("onclick", "Remove(this);");
        btnRemove.addClass("btn btn-danger");
        btnRemove.val("Удалить");
        cell.append(btnRemove);
        txtFullname.val("");
        txtPost.val("");
    } else {
        alert("Ошибка добавления сотрудника в состав комиссии проекта. Проверьте правильность заполнения полей");
    }
});

function Remove(button) {
    var row = $(button).closest("TR");
    var name = $("TD", row).eq(0).html();
    if (confirm("Вы уверены, что хотите сотрудника '" + name + "', который использует результаты НИР?")) {
        var table = $("#tblEmployees")[0];
        table.deleteRow(row[0].rowIndex);
    }
};

$("body").on("click", "#btnAddAuthor", function () {
    var txtFullname = $("#txtFullname");
    var txtPost = $("#txtPost");
    var txtDegree = $("#txtDegree");
    var txtStatus = $("#txtStatus");

    if (txtFullname.val() != "" || txtPost.val() != "" || txtDegree.val() != "" || txtStatus.val() != "") {

        var tBody = $("#tblAuthors > TBODY")[0];
        var row = tBody.insertRow(-1);

        var cell = $(row.insertCell(-1));
        cell.html(txtFullname.val());

        cell = $(row.insertCell(-1));
        cell.html(txtPost.val());

        cell = $(row.insertCell(-1));
        cell.html(txtDegree.val());

        cell = $(row.insertCell(-1));
        cell.html(txtStatus.val());

        cell = $(row.insertCell(-1));
        var btnRemove = $("<input />");
        btnRemove.attr("type", "button");
        btnRemove.attr("onclick", "Remove(this);");
        btnRemove.addClass("btn btn-danger");
        btnRemove.val("Удалить");
        cell.append(btnRemove);
        txtFullname.val("");
        txtPost.val("");
    } else {
        alert("Ошибка добавления автора(-ов) НИР. Проверьте правильность заполнения полей");
    }
});

function Remove(button) {
    var row = $(button).closest("TR");
    var name = $("TD", row).eq(0).html();
    if (confirm("Вы уверены, что хотите удалить автора '" + name + "' из состава авторов НИР?")) {
        var table = $("#tblAuthors")[0];
        table.deleteRow(row[0].rowIndex);
    }
};

$("body").on("click", "#btnIARActSave", function () {

    var model = {
        Id: $("#Id").val(),
        ImplementingResult: $("#ImplementingResult").val(),
        Process: $("#Process").val(),
        Characteristic: $("#Characteristic").val(),
        ImplementationForm: $("#ImplementationForm").val(),
        UnitUsing: $("#UnitUsing").val(),
        FeasibilityOfIntroducing: $("#FeasibilityOfIntroducing").val(),
        HeadUnit: $("#HeadUnit").val()
    };

    var employees = [];

    $("#tblEmployees TBODY TR").each(function () {
        var row = $(this);
        var employee = {
            Fullname: row.find("TD").eq(0).html(),
            Post: row.find("TD").eq(1).html()
        };
        employees.push(employee);
    });
    model.Employees = employees;


    var authors = [];

    $("#tblAuthors TBODY TR").each(function () {
        var row = $(this);
        var author = {
            Fullname: row.find("TD").eq(0).html(),
            Post: row.find("TD").eq(1).html(),
            AcademicDegree: row.find("TD").eq(2).html(),
            AcademicStatus: row.find("TD").eq(3).html()
        };
        authors.push(author);
    });
    model.Authors = authors;

    var json = JSON.stringify(model);
    $.ajax({
        type: "POST",
        url: "/IAS/SaveAct",
        data: json,
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        traditional: true,
        success: function (data) {
            document.location.href = "/IAR/Details/" + model.Id;
        }
    });
});