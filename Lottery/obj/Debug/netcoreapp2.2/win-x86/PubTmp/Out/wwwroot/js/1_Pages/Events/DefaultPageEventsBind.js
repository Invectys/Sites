console.log("PersonalPage events were binded");


$(document).on('click', function (event) {

    if (isYourPage()) {
        SlideBar.CheckClick(event);
        //alert("check");
    }
   
});

$(document).ready(function () {

    $EditBlockFrame = $("#EditBlockFrame");
    HideEditBlockFrame();
    //
    if (isYourPage()) {
       
        $(".point").on("mousedown", On);
        $(".point").on("touchstart", On);

        //$(document).on("mouseup", Off);
        //$(document).on("touchend", Off);
        document.onmouseup = Off;
        document.ontouchend = Off;

        //$(document).mousemove(DotMove);
        //$(document).on("touchmove", DotMove);
        document.onmousemove = DotMove;
        document.ontouchmove = DotMove;
    }

    AdaptivePageRef.AdaptiveMethode_2();
});

document.onkeydown = function (event) {
    var prevent = (event.key == 'ArrowDown') || (event.key == 'ArrowUp');
    if (prevent) event.preventDefault();
}

document.onmousedown = function (event) {
    CheckMouseDownPrevent(event); 
}

