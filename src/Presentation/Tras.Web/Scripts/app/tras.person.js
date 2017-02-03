$(document).ready(function () {
    if ($("#profile-form").length > 0) {
        window.triggerForm($("#profile-form"));
    }
    if ($("#family-form").length > 0) {
        window.triggerForm($("#family-form"));
    }
    if ($("#package-form").length > 0) {
        window.triggerForm($("#package-form"));
    }

    showProfileImage();

    uploadImage();

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

    //posting family-form
    $("#family-form").submit(function (e) {
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
                var msg = response.result === "success" ? gSettings.dataSavedMsg : gSettings.dataNotSavedMsg;
                var alerttype = response.result === "success" ? "success" : "danger";
                Message.show(msg, alerttype);
            }
        });
    });

    //postion person-package-form
    $("package-form").submit(function(e) {
        e.preventDefault();
        var $form = $(this);
        if (!$form.valid()) return;
        $.ajax({
            type: $form.prop('method'),
            url: $form.prop('action'),
            data: $form.serialise(),
            dataType: "json",
            traditional: true,
            success:function(response) {
                var msg = response.result === "success" ? gSettings.dataSavedMsg : gSettings.dataNotSavedMsg;
                var alerttype = response.result === "success" ? "success" : "danger";
                Message.show(msg, alerttype);
            }
        });
    });

    //delete army person
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

function showProfileImage() {
    var $profileForm = $("#profile-form").find("#PersonId");
    if ($profileForm.val() && parseInt($profileForm.val()) > 0) {
        $("#profile-image > div").removeClass("hide");

        if ($("#profile-image > div > img").attr("src") === "") {
            $("#profile-image > div > img").attr("src", "../Content/images/blank_profile_male.jpg");
        }
    } else {
        $("#profile-image > div > img").attr("src", "../Content/images/blank_profile_male.jpg");
    }
}

var jqXHRData;
function uploadImage() {
    "use strict";

    $("#fu-my-simple-upload").fileupload({
        url: "/File/UploadFile",
        dataType: "json",
        add: function (e, data) {
            jqXHRData = data;
        },
        done: function (event, data) {
            if (data.result.isUploaded) {

                $("#hf-uploaded-image-path").val(data.result.filePath);

                $("#uploaded-image").attr("src", data.result.filePath + "?t=" + new Date().getTime());

                $("#crop-image-area").fadeIn("slow");
            } 
        },
        fail: function (event, data) {
            if (data.files[0].error) {
                alert(data.files[0].error);
            }
        }
    });

    $("#hl-start-upload").on('click', function () {
        if (jqXHRData) {
            jqXHRData.submit();
        }
        return false;
    });
}