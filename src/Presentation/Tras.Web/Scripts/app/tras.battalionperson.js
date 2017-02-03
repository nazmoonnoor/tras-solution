$(document).ready(function() {
    if ($("#profile-form").length > 0) {
        window.triggerForm($("#profile-form"));
    }

    //posting profile-form
    $("#profile-form").submit(function (e) {
        e.preventDefault();
        var $form = $(this);
        if (!$form.valid()) return;

        $.ajax({
            type: $form.prop('method'),
            url: $form.prop('action'),
            data: $form.serialize(),
            dataType: "json",
            traditional: true,
            success: function (response) {
                if (response.personId) {
                    $("#family-form").find("#PersonId").val(response.personId);
                }
                var msg = response.result === "success" ? gSettings.dataSavedMsg : gSettings.dataNotSavedMsg;
                var alerttype = response.result === "success" ? "success" : "danger";
                Message.show(msg, alerttype);
            }
        });
    });

    //delete army battalion person
    $(".btn-delete").on("click", function () {
        var itemId = $(this).data("itemid");

        window.bootbox.confirm(gSettings.deleteConfirm, function (result) {
            if (!result) return;
            var param = JSON.stringify({ id: itemId });
            $.ajax({
                type: "POST",
                url: "/profiles/delete",
                data: param,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    var alerttype = "danger";
                    if (response.result === "success") {
                        alerttype = "success";
                        $("#profile-" + itemId).remove();
                    }

                    Message.show(gSettings.deleteMsg, alerttype);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        });
    });

});