// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $(".nav-menu2").hide();

    $(".nav-reveal").click(function () {
        $(".nav-menu2").slideToggle(); // testing -> Test completed, text will now show toggling when menu button clicked.
        //further testing to be completed to have menu item appear below original nav bar -> WIP
        // alert("OMG IT WORKS!!!"); -- it does in fact work
    });

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
            
        } else
        {
            //alert("Click Counter is less than or equal to 0")
            clickhead = 4;
            headId = 4;
            $('#imgChangeHead').attr('src', '/Resources/Avatars/Head/Base/Hat'+ headId +'a.png')

        }
    });

    $("#headBtnRight").click(function () {
        headId = clickhead;
        if (clickhead < 4) {
            clickhead++;
            headId++;
            $('#imgChangeHead').attr('src', '/Resources/Avatars/Head/Base/Hat'+ headId +'a.png')

        } else {
            clickhead = 1;
            headId = 1;
            $('#imgChangeHead').attr('src', '/Resources/Avatars/Head/Base/Hat'+ headId +'a.png')
            
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
            $('#imgChangeBody').attr('src', '/Resources/Avatars/Body/Base/Body'+ bodyId +'a.png')
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
})