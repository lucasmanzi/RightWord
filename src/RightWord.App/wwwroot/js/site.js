
$(document).ready(function () {
    $("#msg_box").fadeOut(5000);

    AccomodatioChange();
})

$('#table').bootstrapTable('resetView', { height: 200 });

//document.getElementById('accommodation').onchange = function () {
//    document.getElementById("TfLroad").disabled = (this.value === '0');
//}

function AccomodatioChange() {
    var accomodationValue = document.getElementById("accommodation").value;
    var type = document.getElementById("accommodationType");
    var duration = document.getElementById("accommodationDuration");
    var partnerName = document.getElementById("partnerName");

    switch (accomodationValue) {
        case "0":
            type.disabled = duration.disabled = partnerName.disabled = true;
            type.value = 0;
            duration.value = 0;
            partnerName.value = "";
            break;

        case "1":
            type.disabled = duration.disabled = false;
            partnerName.disabled  = true;
            partnerName.value = "";
            break;

        case "2":
            type.disabled = duration.disabled = partnerName.disabled = false;
            break;

        default:
            type.disabled = duration.disabled = partnerName.disabled  = false;
            break;
    }

    
};


///*function AjaxModal() {

//    $(document).ready(function () {
//        $(function () {
//            $.ajaxSetup({ cache: false });

//            $("a[data-modal]").on("click",
//                function (e) {
//                    $('#myModalContent').load(this.href,
//                        function () {
//                            $('#viewFileModal').modal({
//                                keyboard: true
//                            },
//                                'show');
//                            //bindForm(this);
//                        });
//                    return false;
//                });
//        });

//        function bindForm(dialog) {
//            $('form', dialog).submit(function (e) {
//                var fdata = $(this).serialize();

//                fdata.append().$('#ImageUpload')

//                $.ajax({
//                    url: this.action,
//                    type: this.method,
//                    data: fdata,
//                    success: function (result) {
//                        if (result.success) {
//                            $('#myModal').modal('hide');
//                            $('#DocumentsTarget').load(result.url); // Carrega o resultado HTML para a div demarcada
//                        } else {
//                            $('#myModalContent').html(result);
//                            bindForm(dialog);
//                        }
//                    }
//                //}).done(function (result) {
//                //    if (result.success) {
//                //        $('#myModal').modal('hide');
//                //        $('#DocumentsTarget').load(result.url); // Carrega o resultado HTML para a div demarcada
//                //    } else {
//                //        $('#myModalContent').html(result);
//                //        bindForm(dialog);
//                //    }
//                //});
//            });
//            return false;
//        });
//}
//    });
//}

//$(document).ready(function () {
//    var $table = $('#table')

//    $(function () {
//        $('#toolbar').find('select').change(function () {
//            $table.bootstrapTable('destroy').bootstrapTable({
//                exportDataType: $(this).val(),
//                exportTypes: ['json', 'xml', 'csv', 'txt', 'sql', 'excel', 'pdf'],
//                //columns: [
//                //    {
//                //        field: 'Active',
//                //        checkbox: true,
//                //        //visible: $(this).val() === 'selected'
//                //    },
//                //    {
//                //        field: 'Email',
//                //        title: 'Email'
//                //    }, {
//                //        field: 'FirstName',
//                //        title: 'FirstName'
//                //    }, {
//                //        field: 'SurName',
//                //        title: 'SurName'
//                //    }
//                //]
//            })
//        }).trigger('change')
//    })

//    AjaxModal();
//});
