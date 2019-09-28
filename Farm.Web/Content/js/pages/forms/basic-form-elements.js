$(function () {
    //Bootstrap datepicker plugin
    $('#bs_datepicker_container input').datepicker({
        format: 'dd/mm/yyyy',
        language: 'tr',  
        clearBtn: true,
        todayHighlight: true,
        autoclose: true,
        container: '#bs_datepicker_container'
    });

    $('#bs_datepicker_component_container').datepicker({
        format: 'dd/mm/yyyy',
        todayBtn: true,
        todayHighlight: true,
        autoclose: true,
        container: '#bs_datepicker_component_container'
    });

    $('#bs_datepicker_range_container').datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true,
        clearBtn: true,
        todayHighlight: true,
        container: '#bs_datepicker_range_container'
    });
});