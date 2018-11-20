$(document).ready(function () {
    $("#modalCancel").on("click",
        function () {
            $("#idToDelete").removeAttr("value");
            $(".modal-body").text("");        
        });

    $("a").on("click",
        function () {
            $("#idToDelete").attr("value", $(this).attr("data-id"));
            $(".modal-body").text($(this).attr("data-title"));
        });
});