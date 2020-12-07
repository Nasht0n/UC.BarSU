$("body").on("click", "#btnAdd", function () {
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
    if (confirm("Вы уверены, что хотите удалить сотрудника '"+ name +"' из состава комиссии проекта?")) {
        var table = $("#tblEmployees")[0];
        table.deleteRow(row[0].rowIndex);
    }
};

$("body").on("click", "#btnIASSave", function () {

    var model = {
        Id: $("#Id").val(),
        Scope: $("#Scope").val(),
        Department: $("#Department").val(),
        Result: $("#Result").val(),
        Author: $("#Author").val(),
        ProjectName: $("#ProjectName").val(),
        PracticalTasks: $("#PracticalTasks").val(),
        EconomicEfficiency: $("#EconomicEfficiency").val(),
        ProtocolDate: $("#ProtocolDate").val(),
        ProtocolNumber: $("#ProtocolNumber").val(),
        RegisterDate: $("#RegisterDate").val()
    };

    var employees = [];
    console.log(model);

    $("#tblEmployees TBODY TR").each(function () {
        var row = $(this);
        var employee = {
            Fullname: row.find("TD").eq(0).html(),
            Post: row.find("TD").eq(1).html()
        };
        employees.push(employee);
    });
    model.Commission = employees;

    var json = JSON.stringify(model);
    $.ajax({
        type: "POST",
        url: "/IAS/SaveAct",
        data: json,
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        traditional: true,
        success: function (data) {
            if (model.Id == 0) document.location.href = "/IAS/Index";
            else document.location.href = "/IAS/Details/" + model.Id;
        }
    });
});