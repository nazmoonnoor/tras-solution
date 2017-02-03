/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
var accommodationId = 0;
$(document).ready(function() {

    $('.datepicker').datepicker({
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        calendarWeeks: true,
        autoclose: true
    });
toastr.options = {
                        "closeButton": true,
                        "debug": false,
                        "progressBar": true,
                        "positionClass": "toast-top-right",
                        "onclick": null,
                        "showDuration": "400",
                        "hideDuration": "1000",
                        "timeOut": "7000",
                        "extendedTimeOut": "1000",
                        "showEasing": "swing",
                        "hideEasing": "linear",
                        "showMethod": "fadeIn",
                        "hideMethod": "fadeOut"
                    }
    var config = {
        '.chosen-select': {},
        '.chosen-select-deselect': {allow_single_deselect: true},
        '.chosen-select-no-single': {disable_search_threshold: 10},
        '.chosen-select-no-results': {no_results_text: 'Oops, nothing found!'},
        '.chosen-select-width': {width: "95%"}
    }
    for (var selector in config) {
        $(selector).chosen(config[selector]);
    }

    $('#flash-overlay-modal').modal();

    $('.sidebar-collapse').slimScroll({
        height: '100%',
        railOpacity: 0.9,
    });          
    
    $('.i-checks').iCheck({
        checkboxClass: 'icheckbox_square-green',
        radioClass: 'iradio_square-green',
    });    
    
    
//    $('#locationSelect').change(function() {
//        var token = $('input[name="_token"]').val();
//
//        $.ajax({
//            url: '/admin/accommodations/availablelist',
//            type: "POST",
//            data: { location_id: $(this).val(), _token: token},
//            
//            success:  function (data) {
//                if(console){
//                    console.log("Available accommodations on location: "+ data)
//                }                
//                
//                var prevAccommodationId = $("#accommodationSelect").val();
//                var options = '<option value="">Select One</option>';
//                
//                $.each(data.accommodations, function(key, val){
//                    options +='<option value="'+key+'">'+val+'</option>';
//                });
//                
//                $("#accommodationSelect").html(options);
//                
//                if(prevAccommodationId >0){
//                    $("#accommodationSelect").val(prevAccommodationId)
//                }     
//                $("#accommodationSelect").trigger("chosen:updated");
//                console.log(options)
//            }
//        });                    
//    });

$('input[name="check_in_date"],select[name="accommodation_type_id"], input[name="check_out_date"],select[name="location_id"]').change(function() {
        var token = $('input[name="_token"]').val();
        var locationId          = $('select[name="location_id"]').val();
        var accommodationTypeId = $('select[name="accommodation_type_id"]').val();
        var checkInDate         = $('input[name="check_in_date"]').val();
        var checkOutDate        = $('input[name="check_out_date"]').val();
//        var accommodationId     = 0;
//        debugger;
        if(accommodationId == 0){
            $('input[name="accommodation_id"]').each(function(){
                if($(this).is(':checked')){
                    accommodationId = $(this).val();
                }            
            }); //is(':checked');
        }        
        
        if(locationId >0 && accommodationTypeId >0 && checkInDate !='' && checkOutDate !=''){
        $.ajax({
            url: '/admin/accommodations/forreservation',
            type: "POST",
            data: { location_id: locationId, 
                    check_in_date:$('input[name="check_in_date"]').val(), 
                    check_out_date:$('input[name="check_out_date"]').val(), 
                    accommodation_type_id:$('select[name="accommodation_type_id"]').val(), 
                    accommodation_id: accommodationId, 
                    _token: token},
            
            success:  function (data) {
                if(console){
                    console.log("Available hosts on location: "+ data)
                }                
                $("#accommodationList").html(data);
//                var prevHostId = $("#hostSelect").val();
//                var options = '<option value="">Select One</option>';
//                
//                $.each(data.hosts, function(key, val){
//                    options +='<option value="'+key+'">'+val+'</option>';
//                });
//                
//                $("#hostSelect").html(options);
//                
//                if(prevHostId >0){
//                    $("#hostSelect").val(prevHostId)
//                }     
//                $("#hostSelect").trigger("chosen:updated");
//                console.log(options)
            }
        });         
    }
    });
    
    $('#hostSelect').change(function() {
        var token = $('input[name="_token"]').val();

        $.ajax({
            url: '/admin/accommodations/availablelist',
            type: "POST",
            data: { user_id: $(this).val(), _token: token},
            
            success:  function (data) {
                if(console){
                    console.log("Available accommodations on location: "+ data)
                }                
                
                var prevAccommodationId = $("#accommodationSelect").val();
                var options = '<option value="">Select One</option>';
                
                $.each(data.accommodations, function(key, val){
                    options +='<option value="'+key+'">'+val+'</option>';
                });
                
                $("#accommodationSelect").html(options);
                
                if(prevAccommodationId >0){
                    $("#accommodationSelect").val(prevAccommodationId)
                }     
                $("#accommodationSelect").trigger("chosen:updated");
                console.log(options)
            }
        });                    
    });
        
    $('input[name="check_out_date"], select[name="location_id"], select[name="accommodation_type_id"], input[name="check_in_date"], input[name="arrival_date"], input[name="is_pickup_required"], input[name="is_dropoff_required"], input[name="is_meals_required"], select[name="meals_id"]').change(function() {
        var token               = $('input[name="_token"]').val();
        var locationId          = $('select[name="location_id"]').val();
        var accommodationTypeId = $('select[name="accommodation_type_id"]').val();
        var checkInDate         = $('input[name="check_in_date"]').val();
        var checkOutDate        = $('input[name="check_out_date"]').val();
        var isPickupRequired    = $('input[name="is_pickup_required"]:checked').val();
        var isDropOffRequired   = $('input[name="is_dropoff_required"]:checked').val();
        var isMealsRequired     = $('input[name="is_meals_required"]:checked').val();
        var mealsId             = $('select[name="meals_id"]').val();
        var arrivalDate         = $('input[name="arrival_date"]').val();
        var reservationId       = $('input[name="reservation_no"]').val();
        if(locationId >0 && accommodationTypeId >0 && checkInDate !='' && checkOutDate !=''){
            $('input[name="total_price"]').removeClass('animated fadeIn');                        
            $.ajax({
                url: '/admin/reservations/calculateprice',
                type: "POST",
                data: { location_id: locationId, 
                        accommodation_type_id: accommodationTypeId, 
                        check_in_date: checkInDate, 
                        check_out_date: checkOutDate, 
                        is_pickup_required: isPickupRequired,
                        is_dropoff_required: isDropOffRequired,
                        is_meals_required:isMealsRequired,
                        meals_id: mealsId,
                        arrival_date: arrivalDate,
                        reservation_id: reservationId,
                        _token: token },

                success:  function (data) {
                    if(console){
                        console.log("Reservation price: "+ data)
                    } 
                    $("#priceList").html(data);
                    /*
                    if(data.total_price > 0 ){ //&& $('input[name="total_price"]').val() ==''
                        $('input[name="total_price"]').val(data.total_price);
                                               
                        $('input[name="total_price"]').addClass('animated fadeIn');                        
                        $('input[name="total_price"]').focus()
                    } 
                    */
                }
            });
        }                            
    });
    
});//doc ready
function checkDates(accommodationObj){
    if($('input[name="check_in_date"]').val() =="" || $('input[name="check_out_date"]').val() ==""){
        alert("Please select Check In & Check Out date");
        return false;
    }
}

function assignReservationAccommodation()
{   
    $('input[name="accommodation_id"]').each(function(){
        if($(this).is(':checked')){
            accommodationId = $(this).val()
            $(this).parent('td').parent('tr').addClass('active');
        }
    });
    if(!accommodationId){
        toastr.warning("Please select a room");
        return false;
    }
    var token = $('input[name="_token"]').val();
    // accommodationId is global variable        
    var locationId = $('select[name="location_id"]').val();
    var reservationId = $('input[name="reservation_no"]').val();

    if(reservationId >0 && accommodationId >0){
        $.ajax({
            url: '/admin/reservations/assignaccommodation',
            type: "PUT",
            data: { id: reservationId, 
                    accommodation_id: accommodationId, 
                    location_id: locationId,
                    _token: token },

            success:  function (data) {
                if(console){
                    console.log("Reservation Assigned "+ data)
                }
                if(data.status == '1'){
                    $('select[name="status"]').val('Assigned').change()
                    $('button[name="unassign_accommodation"]').show()
                    $('button[name="assign_accommodation"]').hide()
                    toastr.success(data.msg);
                } else {
                    toastr.warning(data.msg);
                }                                
            }
        });
    }     
}

function unassignReservationAccommodation()
{
    var accObj = '';
    if(accommodationId == 0){
        $('input[name="accommodation_id"]').each(function(){
            if($(this).is(':checked')){
                accommodationId = $(this).val()
                accObj = this;
            }
        });
    }
    
    if(accommodationId >0){
        var token = $('input[name="_token"]').val();                
        var reservationId = $('input[name="reservation_no"]').val();

        if(reservationId >0 && accommodationId >0){
            $.ajax({
                url: '/admin/reservations/unassignaccommodation',
                type: "PUT",
                data: { id: reservationId,
                        accommodation_id: accommodationId, 
                        _token: token },

                success:  function (data) {
                    if(console){
                        console.log("Reservation Assigned "+ data)
                    }
                    if(data.status =='1'){
                        accommodationId = 0;
                        $('input[name="accommodation_id"]').each(function(){
                            if($(this).is(':checked')){
                                $(this).removeAttr('checked')   
                                accObj = this
                            }
                        });
                        $(accObj).parent('td').parent('tr').removeClass('active');
                        $('select[name="status"]').val('Unassigned').change()
                        $('button[name="unassign_accommodation"]').hide()
                        $('button[name="assign_accommodation"]').show()
                        toastr.success(data.msg);
                    } else {
                        toastr.warning(data.msg);
                    }                                        
                }
            });
        }  
    }
}

$('[data-res-accommodation]').click(function(){
    var $this = $(this)
        ,accommodationID = $this.data('accommodation-id')
        ,userID = $this.data('user-id');
    $.ajax({
        url: '/admin/users/'+userID+'/host/'+accommodationID
        ,method: 'GET'
        ,success: function(result, textStatus, xhr){
            $("#accommodation_details").html(result)            
        },
        error: function(xhr, textStatus, errorThrown) {
            console.log('Accommodation preview ajax request error');
            console.log(textStatus + 'received: ' + errorThrown);
        }
    });      
                
});