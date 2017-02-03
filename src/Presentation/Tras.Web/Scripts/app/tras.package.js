$(document).ready(function() {
    var packageItem = new Package();
    packageItem.init();
});

var Package = function() {
    this.packageId = "";
}


Package.prototype.init = function () {
   
    var $self = this;
    $(".saveModal").fancybox({
        type: "ajax",
        padding: 0,
        openEffect: "fade",
        openSpeed: "normal",
        closeEffect: "fade",
        closeSpeed: "slow",
        minWidth: "600px",
        minHeight: "auto",
        afterClose: function () {
            //window.location.reload();
        },
        afterShow: function () {
            $self.bindSaveModal();
        }
    });
};

Package.prototype.closeFancybox = function () {
    $.fancybox.close();
};

Package.prototype.bindSaveModal = function () {
    var $self = this;
    var $form = $("#package-form");
    $form.removeData("validator");
    $form.removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse($form);

    if ($form.length > 0) {
        window.triggerForm($form);
    }

    $form.submit(function (e) {
        e.preventDefault();
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
                $self.closeFancybox();
                Message.show(msg, alerttype);
                $self.reloadPage();
            }
        });
    });

    $(".cancel").click(function () {
        $.fancybox.close();
    });
};

Package.prototype.bindDelete = function() {
    var $self = this;
    $("btn-row-del").on("click", function() {
        var itemId = $(this).data("itemid");

        Window.bootbox.confirm(gSettings.deleteConfirm,function(result) {
            if (!result) return;

            var param = JSON.stringify({ id: itemId });
            $.ajax({
                type: "POST",
                url: "Package/Delete",
                data: param,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success:function(response) {
                    var alerttype = "danger";
                    if (response.result === "success") {
                        alerttype = "success";
                    }

                    Message.show(gSettings.deleteMsg, alerttype);
                    $self.reloadPage();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }

            });
        });

    });
};

Package.prototype.reloadPage = function () {
    setTimeout(function () {
        window.location.reload();
    }, 2000);
};