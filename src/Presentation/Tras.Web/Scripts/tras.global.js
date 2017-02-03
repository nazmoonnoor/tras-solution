jQuery(function ($) {
    //$('body').css('display', 'block');
    $("body").fadeIn(300);
});

$(document).ready(function () {
    //bootstrap-select config
    //http://plugins.upbootstrap.com/bootstrap-select/
    $(".selectpicker").selectpicker();

    //datepicker config
    //http://eonasdan.github.io/bootstrap-datetimepicker
    $(".ibox-content .bootstrap-datepicker").datetimepicker({
        format: 'DD-MM-YYYY'
    });

    //bb-alert config
    Message.init($(".bb-alert"));
});

var gSettings = {
    "dataSavedMsg": "Data saved successfully!",
    "dataNotSavedMsg": "Something went wrong. Data couldn't be saved!",
    "deleteConfirm": "Are you sure want to delete?",
    "deleteMsg": "Data deleted successfully!"
}

//http://stackoverflow.com/questions/9815058/extending-jquery-ajax-success-globally
var ns = {};
ns.ajax = function (options, callback) {
    var defaults = {
        success: function (data) {
            if (check(data)) {
                callback(data);
            }
        }
    };
    $.extend(options, defaults);
    return $.ajax(options);
}

/**
 * This tiny script can show tiny messages in window
 */
var Message = (function () {
    "use strict";

    var $elem,
        hideHandler,
        that = {};

    that.init = function ($selector) {
        $elem = $selector;
    };

    that.show = function (text, alerttype) {
        clearTimeout(hideHandler);
        var alertcss = alerttype ? "alert-" + alerttype : "alert-info";
        $elem.addClass(alertcss);

        $elem.find("span").html(text);
        $elem.delay(200).fadeIn().delay(5000).fadeOut();
    };

    return that;
}());

/**
 * jquery.datatable settings
 */
$.extend($.fn.dataTable.defaults, {
    searching: true,
    ordering: true,
    responsive: true,
    paging: true
});

/**
 * jquery.validate settings
 */
$.validator.methods.date = function (value, element) {
    var bits = value.match(/([0-9]+)/gi);
    if (!bits)
        return this.optional(element) || false;
    var str = bits[1] + '/' + bits[0] + '/' + bits[2];
    return this.optional(element) || !/Invalid|NaN/.test(new Date(str));
};

$.validator.setDefaults({
    onkeyup: false,
    onfocusout: function (element) {
        var isValid = $(element).valid();
        if (!isValid) {
            $(element).closest(".form-group").removeClass("has-success").addClass("has-error");
        } else {
            $(element).closest(".form-group").removeClass("has-error").addClass("has-success");
        }
    }
});

//override jquery validate's settings.errorPlacement & settings.success
window.triggerForm = function (form) {
    "use strict";
    if (!form) {
        return;
    }
    var formData = $.data(form[0])
        , settings = formData.validator.settings
        // Store existing event handlers in local variables
        , oldErrorPlacement = settings.errorPlacement
        , oldSuccess = settings.success;

    settings.errorPlacement = function (label, element) {

        // Call old handler so it can update the HTML
        oldErrorPlacement(label, element);

        // Add Bootstrap classes to newly added elements
        label.parents('.form-group').addClass('has-error');
        label.addClass('text-danger');
    };

    settings.success = function (label) {
        // Remove error class from <div class="form-group">, but don't worry about
        // validation error messages as the plugin is going to remove it anyway
        label.parents('.form-group').removeClass('has-error');

        // Call old handler to do rest of the work
        oldSuccess(label);
    };
};

//http://stackoverflow.com/questions/497790
var dates = {
    convert: function (d) {
        // Converts the date in d to a date-object. The input can be:
        //   a date object: returned without modification
        //  an array      : Interpreted as [year,month,day]. NOTE: month is 0-11.
        //   a number     : Interpreted as number of milliseconds
        //                  since 1 Jan 1970 (a timestamp) 
        //   a string     : Any format supported by the javascript engine, like
        //                  "YYYY/MM/DD", "MM/DD/YYYY", "Jan 31 2009" etc.
        //  an object     : Interpreted as an object with year, month and date
        //                  attributes.  **NOTE** month is 0-11.
        return (
            d.constructor === Date ? d :
            d.constructor === Array ? new Date(d[0], d[1], d[2]) :
            d.constructor === Number ? new Date(d) :
            d.constructor === String ? new Date(d) :
            typeof d === "object" ? new Date(d.year, d.month, d.date) :
            NaN
        );
    },
    compare: function (a, b) {
        // Compare two dates (could be of any type supported by the convert
        // function above) and returns:
        //  -1 : if a < b
        //   0 : if a = b
        //   1 : if a > b
        // NaN : if a or b is an illegal date
        // NOTE: The code inside isFinite does an assignment (=).
        return (
            isFinite(a = this.convert(a).valueOf()) &&
            isFinite(b = this.convert(b).valueOf()) ?
            (a > b) - (a < b) :
            NaN
        );
    },
    inRange: function (d, start, end) {
        // Checks if date in d is between dates in start and end.
        // Returns a boolean or NaN:
        //    true  : if d is between start and end (inclusive)
        //    false : if d is before start or after end
        //    NaN   : if one or more of the dates is illegal.
        // NOTE: The code inside isFinite does an assignment (=).
        return (
             isFinite(d = this.convert(d).valueOf()) &&
             isFinite(start = this.convert(start).valueOf()) &&
             isFinite(end = this.convert(end).valueOf()) ?
             start <= d && d <= end :
             NaN
         );
    }
}