// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $(".nav-menu2").hide();

    $(".nav-reveal").click(function () {
        $(".nav-menu2").slideToggle(); // testing -> Test completed, text will now show toggling when menu button clicked.
        //further testing to be completed to have menu item appear below original nav bar -> WIP
        // alert("OMG IT WORKS!!!"); -- it does in fact work
    })

})