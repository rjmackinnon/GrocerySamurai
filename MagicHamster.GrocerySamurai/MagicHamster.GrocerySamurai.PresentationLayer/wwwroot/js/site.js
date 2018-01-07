// Write your JavaScript code.
$(document).ready(function() {

    var itemId;
    var itemName;
    var itemType;
    var isActive;
    var saveText;
    var action;
    var deleteLabel;

    $("#divContent").offset({ top: $("#divHeader").outerHeight() });

    $(window).resize(function() {
        $("#divContent").offset({ top: $("#divHeader").outerHeight() });

    });

    $(".bootstrap-decorate").DataTable({
        retrieve: true,
        stateSave: true
    });

    function setCommonVariables(control) {
        itemId = control.data("id");
        itemName = control.data("name");
        itemType = control.data("type");
        isActive = control.data("active") || "true";
        action = control.data("action");
        deleteLabel = "#delete-" + itemType.toLowerCase() + "-label";
    }

    $(".delete").on("click",
        function() {
            setCommonVariables($(this));
            saveText = $(deleteLabel)[0].innerText;
            $(deleteLabel)[0].innerText = $(deleteLabel)[0].innerText
                .replace("{itemname}", itemName)
                .replace("{action}", action);
        });

    $(".continue-delete").on("click",
        function() {
            //alert("click");
            $("body").addClass("waiting");
            //try {
                var myUrl = appVariables.actionUrl(action, itemType) + "/" + itemId;
            //} catch (err) {
                //alert(err);
            //}
            //alert(myUrl);
            $.ajax({
                type: "GET",
                url: myUrl,
                success: function() {
                    //alert("success");
                    window.location.reload();
                },
                failure: function() {
                    //alert("failure");
                },
                complete: function () {
                    //alert("complete");
                    $("body").removeClass("waiting");
                }
            });
            $(deleteLabel)[0].innerText = saveText;
        });

    $(".cancel-deactivate").on("click",
        function() {
            $(deleteLabel)[0].innerText = saveText;
        });

    // Disable AJAX caching in IE
    $.ajaxSetup({ cache: false });

    // Don't show the table until it's been decorated
    $(".table-container").removeClass("table-container-hidden");

});
