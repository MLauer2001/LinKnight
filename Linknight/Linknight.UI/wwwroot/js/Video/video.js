$(function () {

    var changelink = "";

    //Select Button

    $("#select").click(function () {
        //alert("Is showing");
        ClearUrl();
        ShowBox();
        HideSelect();
        
    });

    //Put in Url

    $("#confirmUrl").click(function () {
        changelink = $("#urlTextbox").val();
        var url = changelink.split("v=")[1].substring(0, 11);
        $('#video').attr('src', 'https://www.youtube.com/embed/' + url);

        //alert(changelink);
        HideBox();
        ShowSelect();
    });

    //Clear Url

    function ClearUrl() {
        $("#urlTextbox").val("");
    }

    //Show DIV

    function ShowBox() {
        $("#textbox").show();
        //alert("Div is showing");
    }

    //Show OTHER div

    function ShowSelect() {
        $("#select").show();
    }
    //Hide DIV

    function HideBox() {
        $("#textbox").hide();
        //alert("Div is showing");
    }

    //Hide OTHER div
    function HideSelect() {
        $("#select").hide();
    }
})