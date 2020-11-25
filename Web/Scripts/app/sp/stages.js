$("#inputFile").on("change", function () {
    var files = $(this)[0].files;

    if (files.length > 0) {
        var parent = document.getElementById("files");

        var totalChild = document.createElement("div");
        totalChild.className = "text-center";

        totalChild.innerHTML = 'Загружаемые файлы:<br/>';
        parent.appendChild(totalChild);

        var fileChild = document.createElement("div");

        fileChild.className = "p-3 small";
        for (var i = 0; i < files.length; i++) {
            fileChild.innerHTML += files[i].name + '<br/>';
        }
        parent.appendChild(fileChild);
    }
});

$("#btnAddStage").on("click", function () {
    var ddStage = document.getElementById("StageType");
    console.log(ddStage.options[ddStage.selectedIndex].value);
    var stage = {
        ProjectId: $("#Id").val(),
        StageTypeId: ddStage.options[ddStage.selectedIndex].value
    };

    var files = $("#inputFile")[0].files;

    var reports = [];

    for (var i = 0; i < files.length; i++) {
        var report = {
            Filename: files[i].name,
            Path: files[i].val
        };
        console.log(report);
        reports.push(report);
    }

    var model = {
        stage
    };

    var json = JSON.stringify(model);
    $.ajax({
        type: "POST",
        url: "/SP/AddStage",
        data: json,
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        traditional: true,
        success: function (data) {
            alert("success");
            window.location.href = "/SP/Details/" + model.Id;
        }
    });
});