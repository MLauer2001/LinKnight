// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {

    var changelink = "";
    $("#select").click(function () {
        alert("Is showing");
        ShowBox();
    });
    $("#confirmurl").click(function () {
        changelink = $("#urltextbox").val();
        var url = changelink.split("v=")[1].substring(0, 11);
        $('#video').attr('src', 'https://www.youtube.com/embed/' + url);

        //alert(changelink);
        HideBox();
    });

    



    function ShowBox() {
        $("#textbox").show();
        //alert("Div is showing");
    }
    function HideBox() {
        $("#textbox").hide();
        //alert("Div is showing");
    }
    

})