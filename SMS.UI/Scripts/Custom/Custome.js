/// <reference path="../jquery-1.8.0.intellisense.js" />

 $(function () {
     $("#InstituteImage").change(function () {
        $("#dvpreview").html("");
         var regex = /^([a-za-z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
         if (regex.test($(this).val().toString().tolowercase())) {
            if ($.browser.msie && parsefloat(jquery.browser.version) <= 9.0) {
                $("#dvpreview").show();
                $("#dvpreview")[0].filters.item("dximagetransform.microsoft.alphaimageloader").src = $(this).val();
            }
            else {
                if (typeof (filereader) != "undefined") {
                    $("#dvpreview").show();
                    $("#dvpreview").append("<img />");
                    var reader = new filereader();
                    reader.onload = function (e) {
                        $("#dvpreview img").attr("src", e.target.result);
                    }
                    reader.readasdataurl($(this)[0].files[0]);
                } else {
                    alert("this browser does not support filereader.");
                }
            }
        } else {
            alert("please upload a valid image file.");
        }
    });
});


function beginRequest()
{
    //$(".wrapper").css("opacity", 0.2);
    $("#SPAloading").css({ "display": "block" });
    $("#SPAloading").show();
    $("#myModal").modal('show')
}

function completeRequest()
{
    $("#SPAloading").css({ "display": "block" });
    $("#SPAloading").hide();
    $("#myModal").modal('hide')
}

function successMessage(response)
{
    SuccessMessage(response);
}

function failureMessage(response)
{
    SuccessMessage(response);
}

function SuccessMessage(heading,text) {
    $.toast({
        heading: heading,
        text: text,
        position: 'top-right',
        stack: false,
        icon: 'success',
        allowToastClose: false,
        showHideTransition: 'slide',
    });
}