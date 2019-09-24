$(function () {
    //Widgets count
    $('.count-to').countTo();

    //Sales count to
    $('.sales-count-to').countTo({
        formatter: function (value, options) {
            return '$' + value.toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, ' ').replace('.', ',');
        }
    });

    //initRealTimeChart();
    //initDonutChart();
    initSparkline();
    $(document).ready(function () {
        $('.cow-list-table').DataTable({
            language: {
                "sDecimal": ",",
                "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
                "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
                "sInfoEmpty": "Kayıt yok",
                "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
                "sInfoPostFix": "",
                "sInfoThousands": ".",
                "sLengthMenu": "Sayfada _MENU_ kayıt göster",
                "sLoadingRecords": "Yükleniyor...",
                "sProcessing": "İşleniyor...",
                "sSearch": "Ara:",
                "sZeroRecords": "Eşleşen kayıt bulunamadı",
                "oPaginate": {
                    "sFirst": "İlk",
                    "sLast": "Son",
                    "sNext": "Sonraki",
                    "sPrevious": "Önceki"
                },
                "oAria": {
                    "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                    "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
                },
                "select": {
                    "rows": {
                        "_": "%d kayıt seçildi",
                        "0": "",
                        "1": "1 kayıt seçildi"
                    }
                }
            },
            sDom: "<'row datatables-header form-inline'<'col-sm-12 col-md-6'i><'col-sm-12 col-md-6'f>r><'table-responsive't><'row datatables-footer'<'col-sm-12 col-md-6 col-md-offset-6 'p>>",
            sort: false,
            info: true,
            "iDisplayLength": 10,
            "pagingType": "simple_numbers"
        });
        $('#cow-list-table_paginate').css('text-align', 'center');

    });
});

var realtime = 'on';
//function initRealTimeChart() {
//    //Real time ==========================================================================================
//    var plot = $.plot('#real_time_chart', [getRandomData()], {
//        series: {
//            shadowSize: 0,
//            color: 'rgb(0, 188, 212)'
//        },
//        grid: {
//            borderColor: '#f3f3f3',
//            borderWidth: 1,
//            tickColor: '#f3f3f3'
//        },
//        lines: {
//            fill: true
//        },
//        yaxis: {
//            min: 0,
//            max: 100
//        },
//        xaxis: {
//            min: 0,
//            max: 100
//        }
//    });

//    function updateRealTime() {
//        plot.setData([getRandomData()]);
//        plot.draw();

//        var timeout;
//        if (realtime === 'on') {
//            timeout = setTimeout(updateRealTime, 320);
//        } else {
//            clearTimeout(timeout);
//        }
//    }

//    updateRealTime();

//    $('#realtime').on('change', function () {
//        realtime = this.checked ? 'on' : 'off';
//        updateRealTime();
//    });
//    //====================================================================================================
//}

function initSparkline() {
    $(".sparkline").each(function () {
        var $this = $(this);
        $this.sparkline('html', $this.data());
    });
}

//function initDonutChart() {
//    Morris.Donut({
//        element: 'donut_chart',
//        data: [{
//            label: 'Chrome',
//            value: 37
//        }, {
//            label: 'Firefox',
//            value: 30
//        }, {
//            label: 'Safari',
//            value: 18
//        }, {
//            label: 'Opera',
//            value: 12
//        },
//        {
//            label: 'Other',
//            value: 3
//        }],
//        colors: ['rgb(233, 30, 99)', 'rgb(0, 188, 212)', 'rgb(255, 152, 0)', 'rgb(0, 150, 136)', 'rgb(96, 125, 139)'],
//        formatter: function (y) {
//            return y + '%'
//        }
//    });
//}

var data = [], totalPoints = 110;
function getRandomData() {
    if (data.length > 0) data = data.slice(1);

    while (data.length < totalPoints) {
        var prev = data.length > 0 ? data[data.length - 1] : 50, y = prev + Math.random() * 10 - 5;
        if (y < 0) { y = 0; } else if (y > 100) { y = 100; }

        data.push(y);
    }

    var res = [];
    for (var i = 0; i < data.length; ++i) {
        res.push([i, data[i]]);
    }

    return res;
}

$('.switch', 'body').bootstrapSwitch({
    onText: 'Evet',
    offText: 'Hayır',
    labelWidth: 30,
    handleWidth: 40
});
$("[data-toggle='asyncswitch']", 'body').bootstrapSwitch({
    size: 'small',
    labelWidth: 25,
    handleWidth: 30
});
$("[data-toggle='asyncswitch']", 'body').on('switchChange.bootstrapSwitch', function (e) {
    var relatedSwitch = $(this);
    $.ajax({
        url: $(this).data("url"),
        type: "POST",
        success: function (result) {
            location.reload();
        },
        error: function (result) {
            relatedSwitch.bootstrapSwitch('toggleState', !relatedSwitch.bootstrapSwitch('state'));
        }
    });
});
$('[data-toggle="confirmation"]', 'body').confirmation({
    singleton: true,
    popout: true,
    placement: 'left',
    title: 'Emin Misiniz?',
    btnOkClass: 'btn btn-success btn-xs',
    btnOkLabel: 'Evet',
    btnCancelClass: 'btn btn-default btn-xs',
    btnCancelLabel: 'Hayır'
});

$('[data-toggle="confirmation"]', 'body').confirmation({
    singleton: true,
    popout: true,
    placement: 'left',
    title: 'Emin Misiniz?',
    btnOkClass: 'btn btn-success btn-xs',
    btnOkLabel: 'Evet',
    btnCancelClass: 'btn btn-default btn-xs',
    btnCancelLabel: 'Hayır'

}
).on('confirm.bs.confirmation', function () {
    var url = $(this).data("url");
    var row = $(this).closest("tr");
    if (url) {
        var reload = $(this).data("reload");
        var removeRow = $(this).data("remove-row");
        $.ajax({
            url: url,
            type: "POST",
            success: function (result) {
                if (reload) {
                    location.reload();
                } else {
                    if (removeRow) {
                        executeFunctionByName(removeRow, row);
                    } else {
                        row.remove();
                    }
                }
                $('.tooltip ').remove();
            },
            error: function (result) {
                document.location = errorPage;
            }
        });
    }
}).on('cancel.bs.confirmation', function () {
    $('.tooltip ').remove();
});
function showDialog() {
    var size = $(this).data("asyncmodal-size");
    var reload = $(this).data("asyncmodal-reload");
    var successMethod = $(this).data("asyncmodal-callback");

    if (size != null) {
        $('#asyncmodal-dialog').addClass("modal-" + size);
    }
    $('#asyncmodal-content').html(busyIndicator);
    $('#asyncmodal-container').modal('show');
    $('#asyncmodal-container').on('hidden.bs.modal', function (event) {
        if (event.target.id == 'asyncmodal-container') {
            $('#asyncmodal-content').empty();
        }
    })
    $('#asyncmodal-content').load(this.href, function (response, status, xhr) {
        if (status == "error") {
            document.location = errorPage;
        }

        bindForm(this, reload, successMethod);
    });

    return false;
}

function bindForm(dialog, reload, successMethod) {
    init('#asyncmodal-content');
    $.validator.unobtrusive.parse('form');
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: new FormData(this), //$(this).serialize(),
            processData: false,
            contentType: false,
            beforeSend: function () {
                $('#asyncmodal-content').html(busyIndicator);
            },
            success: function (result) {
                if (result.success) {
                    $('#asyncmodal-container').modal('hide');
                    if (reload == true) {
                        location.reload(); //refresh
                    }
                    else {
                        if (successMethod) {
                            executeFunctionByName(successMethod, window, result);
                        }
                    }
                } else {
                    $('#asyncmodal-content').html(result);
                    bindForm(dialog, reload, successMethod);
                }
            }
        })
            .fail(function () {
                document.location = errorPage;
            });
        return false;
    });
}