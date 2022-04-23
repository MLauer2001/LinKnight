// ALL CODE FOR PROFILE PAGE

$(function () {

    // HEAD CLICK
    var clickhead = 1;
    var headId;

    $("#headBtnLeft").click(function () {
        headId = clickhead;
        if (clickhead > 1) {
            //alert(clickhead);
            clickhead--;
            headId--;
            $('#imgChangeHead').attr('src', '/Resources/Avatars/Head/Base/Hat' + headId + 'a.png')

        } else {
            //alert("Click Counter is less than or equal to 0")
            clickhead = 4;
            headId = 4;
            $('#imgChangeHead').attr('src', '/Resources/Avatars/Head/Base/Hat' + headId + 'a.png')

        }
    });

    $("#headBtnRight").click(function () {
        headId = clickhead;
        if (clickhead < 4) {
            clickhead++;
            headId++;
            $('#imgChangeHead').attr('src', '/Resources/Avatars/Head/Base/Hat' + headId + 'a.png')

        } else {
            clickhead = 1;
            headId = 1;
            $('#imgChangeHead').attr('src', '/Resources/Avatars/Head/Base/Hat' + headId + 'a.png')

        }
    });

    //BODY CLICK
    var clickbody = 1;
    var bodyId;

    $("#bodyBtnLeft").click(function () {
        bodyId = clickbody;
        if (clickbody > 1) {
            clickbody--;
            bodyId--;
            $('#imgChangeBody').attr('src', '/Resources/Avatars/Body/Base/Body' + bodyId + 'a.png')

        } else {
            clickbody = 4;
            bodyId = 4;
            $('#imgChangeBody').attr('src', '/Resources/Avatars/Body/Base/Body' + bodyId + 'a.png')
        }
    });

    $("#bodyBtnRight").click(function () {
        bodyId = clickbody;
        if (clickbody < 4) {
            clickbody++;
            bodyId++;
            $('#imgChangeBody').attr('src', '/Resources/Avatars/Body/Base/Body' + bodyId + 'a.png')

        } else {
            clickbody = 1;
            bodyId = 1;
            $('#imgChangeBody').attr('src', '/Resources/Avatars/Body/Base/Body' + bodyId + 'a.png')

        }
    });

    // RESET AVATAR

    $("#resetAvatar").click(function (){
        // alert("button clicked"); --test completed
        clickhead = 1,
        headId = 1,
        clickbody = 1,
        bodyId = 1;
        $('#imgChangeHead').attr('src', '/Resources/Avatars/Head/Base/Hat' + headId + 'a.png')
        $('#imgChangeBody').attr('src', '/Resources/Avatars/Body/Base/Body' + bodyId + 'a.png')

        Hide();
    });

    // CONFIRM/DISPLAY AVATAR

    $("#confirmAvatar").click(function () {
        //confirm for undefined
        if (headId == undefined || bodyId == undefined) {
            // This would only be the case if the person confirmed their avatar immediately as a head and body number have not yet been defined.
            headId = 1;
            bodyId = 1;
        }


        $("#finished-avatar1").attr('src', '/Resources/Avatars/Head/Base/Hat' + headId + 'a.png')
        $("#finished-avatar2").attr('src', '/Resources/Avatars/Body/Base/Body' + bodyId + 'a.png')
        Show();

        
        //alert("Head = " + headId + " Body = " + bodyId);

    });

    // SHOW DIV

    function Show() {
        $("#avatar-show").show();
        //alert("Div is showing");
    }

    // HIDE DIV

    function Hide() {
        $("#avatar-show").hide();
        //alert("Div is hiding");
    }
})