$(document)
    .ready(function () {

        // Custom code for the store views

        setStoreSelected();

        function setStoreSelected() {
            var selectedBox = $("#store-selected");
            var selected;
            if (selectedBox) {
                selected = selectedBox[0].value;
                if (selected) {
                    $("#datatable-store").find("tr").each(function () {
                        var id = $(this).data("bind");
                        if (id && id.toString() === selected) {
                            $(this).addClass("info");
                        }
                    });

                    openGroceryListView();
                }
            }
        }

        $("#datatable-store")
            .on("click", "tbody tr", function (e) {
                //alert("click");
                $("body").addClass("waiting");
                var cell = $(e.target).get(0);
                if (cell.nodeName === "A" || cell.nodeName === "BUTTON") {
                    return;
                }
                var id = $(this).data("bind");
                var datatableStore = $("#datatable-store").dataTable().api();
                //alert(id);
                datatableStore.rows(".info").nodes().to$().removeClass("info");
                $(this).addClass("info");
                $(this).select();
                var url = appVariables.actionUrl("SetSelected", "Store") + "/" + id;

                $.ajax({
                    "url": url,
                    "type": "GET",
                    success: function (data) {
                        openGroceryListView();
                    },
                    error: function (response, status, error) {
                    },
                    complete: function () {
                        $("body").removeClass("waiting");
                    }
                });

                e.preventDefault();

            });

    });

function openGroceryListView() {
    $("body").addClass("waiting");
    var url = appVariables.actionUrl("Index", "GroceryList");

    $.ajax({
        "url": url,
        "type": "GET",
        success: function (data) {
            //alert("success");
            //displayStatus(data);
            $("#div-child").html(data);
            $(".bootstrap-decorate").DataTable({
                retrieve: true,
                stateSave: true,
                initComplete: function (settings) {
                    var table = settings.oInstance;
                    // Don't decorate twice
                    table.removeClass("bootstrap-decorate");
                    // Don't show the table until it's been decorated
                    $(".table-container-hidden").removeClass("table-container-hidden");
                }
            });
        },
        error: function (response, status, error) {
            //alert("error");
        },
        complete: function () {
            $("body").removeClass("waiting");
        }

    });
};
