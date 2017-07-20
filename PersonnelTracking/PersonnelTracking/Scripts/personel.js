$(document).ready(function () {
    var maxDate, minDate, personnel_id, newMaxDate, newMinDate;
    $("#tblPersonnel tbody tr").remove();
        $.ajax({
            type: "POST",
            url: "Usage.aspx/GetPersonnels",
            data: "{'data': 'data'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                data.d.forEach(function (item) {
                    var rows = '<tr class="personneltd" data-id= "' + item.id + '">'
                        + '<td>' + item.id + '</td>'
                        + '<td>' + item.firstname + '</td>'
                        + '<td>' + item.lastname + '</td>'
                        + '<td>' + item.phonenumber + '</td>'
                        + '<td>' + item.address + '</td>'
                        + '<td>' + item.totalpermit + '</td>'
                        + '<td class="personnelUsed">' + item.usedpermit + '</td>'
                    + "</tr>";
                    $('#tblPersonnel tbody').append(rows);
                });
            },
            failure: function (response) {
                var r = jQuery.parseJSON(response.responseText);
                alert("Message: " + r.Message);
                alert("StackTrace: " + r.StackTrace);
                alert("ExceptionType: " + r.ExceptionType);
            }
        });
        function permitInfo(personel_id) {
            $.ajax({
                type: "POST",
                url: "Usage.aspx/GetPersonnel",
                data: "{'data': '" + personel_id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $(".infoPersonnel").css("display", "block");
                    data.d.forEach(function (element) {
                        if (element.usedpermit != -1) {
                            var rows = '<tr class="personneltd" data-id= "' + element.id + '">'
                            + '<td>' + element.id + '</td>'
                            + '<td>' + element.firstname + '</td>'
                            + '<td>' + element.lastname + '</td>'
                            + '<td>' + element.startingdate + '</td>'
                            + '<td>' + element.duedate + '</td>'
                        + "</tr>";
                            $('.infoPersonnel tbody').append(rows);
                            $('#permitAdd').attr("data-id", element.id);
                        } else {
                            var rows = '<tr class="personneltd" data-id= "' + element.id + '">'
                            + '<td>' + element.id + '</td>'
                            + '<td>' + element.firstname + '</td>'
                            + '<td>' + element.lastname + '</td>'
                            + '<td>' + '-' + '</td>'
                            + '<td>' + '-' + '</td>'
                        + "</tr>";
                            $('.infoPersonnel tbody').append(rows);
                            $('#permitAdd').attr("data-id", element.id);
                        }

                    });
                },
                failure: function (response) {
                    var r = jQuery.parseJSON(response.responseText);
                    alert("Message: " + r.Message);
                    alert("StackTrace: " + r.StackTrace);
                    alert("ExceptionType: " + r.ExceptionType);
                }
            });
        }
        $("body").on("click", ".personneltd", function () {
            $(".infoPersonnel tbody tr").remove();
            personnel_id = $(this).attr("data-id");
            permitInfo(personnel_id);
            
        });
        $("body").on("click", "#permitAdd", function () {
            $('#myModal').modal('show');
            $("#startdate").datepicker('setDate', null);
            $("#enddate").datepicker('setDate', null);
        });
        $.datepicker.regional['lg'] = {
            dateFormat: "dd-mm-yy",//tarih formatı yy=yıl mm=ay dd=gün

            autoSize: true,//inputu otomatik boyutlandırır

            changeMonth: true,//ayı elle seçmeyi aktif eder

            changeYear: true,//yılı elee seçime izin verir

            dayNames: ["pazar", "pazartesi", "salı", "çarşamba", "perşembe", "cuma", "cumartesi"],

            dayNamesMin: ["pa", "pzt", "sa", "çar", "per", "cum", "cmt"],//kısaltmalar

            defaultDate: +5,

            maxDate: "+2y+1m +2w",

            minDate: "-1y-1m -2w",

            monthNamesShort: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],

            nextText: "ileri",

            prevText: "geri",

            showAnim: "fold",
        };
        $.datepicker.setDefaults($.datepicker.regional['lg']);
        $(".datepicker").datepicker({
            todayBtn: 1,
            autoclose: true,

        });
        
        
        $("body").on("click", "#permitSave", function () {
            minDate = $("#startdate").datepicker({ dateFormat: 'dd-mm-yy' }).val();
            maxDate = $("#enddate").datepicker({ dateFormat: 'dd-mm-yy' }).val();
            if (minDate) {
                newMinDate = minDate.replace(/\-/g, '.');
            }
            if (maxDate) {
                newMaxDate = maxDate.replace(/\-/g, '.');
            }
            $.ajax({
                type: "POST",
                url: "Usage.aspx/SavePermit",
                data: "{'id': '" + personnel_id + "', 'startdate': '" + newMinDate + "','duedate': '" + newMaxDate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d != (-1))
                    {
                        $('#myModal').modal('hide');
                        $('#infoMsg').css("display", "block");
                        $('#dangerMsg').css("display", "none");
                        $(".infoPersonnel tbody tr").remove();
                        
                        $('.personneltd[data-id='+personnel_id+']').children(".personnelUsed").text(data.d);
                        
                        //var child = $(".personneltd").attr("data-id").children();
                        //child.find(".personnelUsed").html("HAKAN");
                        permitInfo(personnel_id);
                    } else {
                        $("#startdate").datepicker('setDate', null);
                        $("#enddate").datepicker('setDate', null);
                        $('#dangerMsg').css("display", "block");
                        $('#infoMsg').css("display", "none");

                    }
                    
                },
                failure: function (response) {
                    var r = jQuery.parseJSON(response.responseText);
                    alert("Message: " + r.Message);
                    alert("StackTrace: " + r.StackTrace);
                    alert("ExceptionType: " + r.ExceptionType);
                }
            });
            //permitInfo(personnel_id);
        });
});