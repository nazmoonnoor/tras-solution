$(document).ready(function () {
    var steps = new DispersionSteps();

    steps.init();

    steps.renderPersonInfo();

    steps.bindMonthRange();
});

$(window).on("load", function () {
    $(".bootstrap-datepicker").datetimepicker({
        format: "MM-YYYY",
        viewMode: "months"
    }).on("dp.change", dateChanged);

    $.validator.methods.date = function (value, element) {
        value = "01-" + value;
        var bits = value.match(/([0-9]+)/gi);
        if (!bits)
            return this.optional(element) || false;
        var str = bits[1] + '/' + bits[0] + '/' + bits[2];
        return this.optional(element) || !/Invalid|NaN/.test(new Date(str));
    };

    $("#Month").removeAttr("data-val-number");
    //$("#Month").attr("data-val-date", "Invalid date");
});

var dateChanged = function (e) {
    var form = $("#FromMonth").val();
    var to = $("#ToMonth").val();
    var fm = form ? form.split("-") : "";
    var tm = to ? to.split("-") : "";
    var fromMonth = fm.length === 2 ? new Date(fm[0] + "-1-" + fm[1]) : undefined;
    var toMonth = tm.length === 2 ? new Date(tm[0] + "-1-" + tm[1]) : undefined;

    if (!fromMonth || !toMonth) {
        return;
    }

    var dateCompare = dates.compare(toMonth, fromMonth);
    if (dateCompare === -1) {
        Message.show("Invalid month selections!", "danger");
        var oldDate = moment(e.date).format('MM-YYYY');
        //TODO: reset old date
        //var targetCtrl = e.target.id.replace("dv+", "");
        //$("#" + targetCtrl).val(oldDate);
        //$(this).find("input").datetimepicker("setDate", e.oldDate.toDate());
        //$(this).find("input").datetimepicker({
        //    defaultDate: e.oldDate.toDate()
        //});
    }
    if (e.target.id === "dv+FromMonth") {
        
    }
};

var $personalNo = $("#PersonalNo");
var $personDetail = $('#person-detail');
var $packageDetail = $('#package-detail');

var DispersionSteps = function () {
    this.personId = "";
    this.fromMonth = "",
    this.toMonth = "";
    this.$form = $("#dispersion-form");
    this.$dvInvoice = $("#dvInvoice");
    this.$btnPrintInvoice = $("#btnPrintInvoice");
}

DispersionSteps.prototype.init = function () {
    var $self = this;
    var $form = $self.$form;
    $form.children("div").steps({
        headerTag: "h3",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        onStepChanging: function (event, currentIndex, newIndex) {
            if (currentIndex > newIndex) {
                return true;
            }
            $form.validate().settings.ignore = ":disabled,:hidden";

            return $form.valid();
        },
        onStepChanged: function (event, currentIndex, priorIndex) {
            if (currentIndex === 1) {
                $self.personId = $("#PersonId").val();
                $self.rednerPackageInfoStep();
            }
        },
        onFinishing: function (event, currentIndex) {
            $form.validate().settings.ignore = ":disabled,:hidden";
            return $form.valid();
        },
        onFinished: function (event, currentIndex) {
            $self.finalizeDispersion();
        }
    });
};

DispersionSteps.prototype.renderPersonInfo = function () {
    var $self = this;
    $("#PersonalNo").on("keyup", function () {
        var searchKey = $(this).val();
        if (searchKey.length >= 5) {
            $.ajax({
                url: "/Dispersion/PersonDetail",
                type: "POST",
                data: { personalNo: searchKey },
                dataType: "html",
                success: function (response) {
                    $('#person-detail').html(response);
                }
            });
        } else {
            $('#person-detail').empty();
        }
    });
};

DispersionSteps.prototype.rednerPackageInfoStep = function () {
    var $self = this;
    if ($self.personId) {
        var param = {
            PersonId: $self.personId,
            FromMonth: $("#FromMonth").val(),
            ToMonth: $("#ToMonth").val()
        };
        $.ajax({
            url: "/Dispersion/PackageDetail",
            type: "POST",
            data: JSON.stringify({dispersion: param}),
            dataType: "html",
            contentType: 'application/json, charset=utf-8',
            success: function (response) {
                $('#package-detail').html(response);
            }
        });
    }
};

DispersionSteps.prototype.finalizeDispersion = function () {
    var $self = this;
    if ($self.personId) {
        $.ajax({
            url: "/Dispersion/FinalizeDispersion",
            type: "POST",
            data: { personId: this.personId },
            dataType: "json",
            success: function (response) {
                if (response.result === "success") {
                    $self.$form.hide();
                    $self.$dvInvoice.removeClass("hide");
                    $self.bindPrintInvoice();
                }
                $('#package-detail').html(response);
            }
        });
    }
};

DispersionSteps.prototype.bindPrintInvoice = function () {
    var $self = this;
    $self.$btnPrintInvoice.on("click", function () {
        alert("Print Invoice");
    });
};

DispersionSteps.prototype.bindMonthRange = function () {
    var $self = this;
    $("[name=MonthRangeKey]").on("click", function () {
        var monthRange = $("[name=MonthRangeKey]:checked").val();
        if (monthRange && monthRange === "1") {
            $("#dvToMonth").addClass("hide");
        } else {
            $("#dvToMonth").removeClass("hide");
        }
    });
};