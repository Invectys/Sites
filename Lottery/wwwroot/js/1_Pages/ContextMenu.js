
var ContextMenu_ActiveClass = "context-menu--active";
var ContextMenuID = "context-menu";



//document.addEventListener("contextmenu", function (e) {
//    if (clickInsideElement(e, "DynamicBlock")) {
//        e.preventDefault();
//        toggleMenuOn();
//        positionMenu(e);
//    }
//    else {
//        toggleMenuOff();
//    }

//});

//document.addEventListener("click", function (e) {
//    var button = e.which || e.button;
//    if (button === 1) {
//        toggleMenuOff();
//    }
//});

//window.onkeyup = function (e) {
//    if (e.keyCode === 27) {
//        toggleMenuOff();
//    }
//}

class ContextMenu {
    ContextMenu() {
        this.$menu = $("#" + ContextMenuID);
        this.menuState = 0;
    }

    toggle() {
        if (this.menuState == 0) {
            this.menuState = 1;
            this.$menu.addClass(ContextMenu_ActiveClass)
        }
    }

    hide() {
        if (this.menuState == 1) {
            this.menuState = 0;
            this.$menu.removeClass(ContextMenu_ActiveClass);
        }
    }
}



//function clickInsideElement(e, className) {
//    var el = e.srcElement || e.target;

//    if (el.classList.contains(className)) {
//        return el;
//    } else {
//        while (el = el.parentNode) {
//            if (el.classList && el.classList.contains(className)) {
//                return el;
//            }
//        }
//    }

//    return false;
//}



//var menuPosition;
//var menuPositionX;
//var menuPositionY;

//function positionMenu(e) {
//    menuPosition = getPosition(e);
//    menuPositionX = menuPosition.x + "px";
//    menuPositionY = menuPosition.y + "px";

//    $menu.css({ left: menuPositionX, top: menuPositionY });

//}