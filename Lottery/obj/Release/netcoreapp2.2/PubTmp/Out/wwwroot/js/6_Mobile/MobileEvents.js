console.log("MobileEvents File were loaded");
if (device.ios() || device.android() || device.mobile()) {
    console.log("MobileEvents Active");
    function TouchStart(event) {

        if (isYourPage())
        {
            //console.log("Start Touch", event);
            var target = event.target;
            $block = $(target).parents('.DynamicBlock');
            if ($block.hasClass('DynamicBlock')) {
                disableScroll();
            }
            else {

            }
            if ($(target).hasClass("point")) {
                disableScroll();
            }
        }
    }

    function TouchEnd() {
        if (isYourPage()) {
            enableScroll();
        }
        
    }

    function TouchMove(e) {

        if (isYourPage()) {
            if (ScrollBlocked) {
                e.preventDefault();

            } else {

            }
        }
        
    }

    document.addEventListener("touchstart", TouchStart);
    document.addEventListener("touchend", TouchEnd);
    document.addEventListener("touchmove", TouchMove, { passive: false });

    $(document).on("click", function (event) {
        var target = event.target;
        $block = $(target).parents('.DynamicBlock');
        if ($block.hasClass('DynamicBlock')) {
            $block.addClass("BlockHover");
            //console.log("222");
        }
        else {
            $(".BlockHover").removeClass("BlockHover");
        }
    });
}
