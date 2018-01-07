$(document)
    .ready(function () {

        // Custom code for the store views

        setStoreSelected();

        function setStoreSelected() {
            var selectedBox = $("#store-selected");
            var selected;
            if (selectedBox) {
                selected = selectedBox.value;
                if (selected) {
                    $("#datatable-store td").each(function () {
                        var text = $(this)[0].innerText;
                        if (text && text.trim() === selected) {
                            $(this).closest("tr").addClass("info");
                        }
                    });

                    openGroceryListView(selected);
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
                    },
                    error: function (response, status, error) {
                    },
                    complete: function () {
                        $("body").removeClass("waiting");
                    }
                });

                openGroceryListView(id);

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
            $(".bootstrap-decorate").DataTable();
        },
        error: function (response, status, error) {
            //alert("error");
        },
        complete: function () {
            $("body").removeClass("waiting");
        }

    });
};
