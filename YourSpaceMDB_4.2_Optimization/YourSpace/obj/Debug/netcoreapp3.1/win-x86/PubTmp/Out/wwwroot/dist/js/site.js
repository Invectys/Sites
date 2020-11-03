function SelectFile(id) {
    var root = document.getElementById(id);
    var inp = root.getElementsByTagName("INPUT")[0];
    inp.click();
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}


var secondTabClass = "app-tabs-second";
var hideShowSecondTabBtnId = "visible-state-second-pannel-btn";




function ShowSecondTab() {
    var secondTabPannelStateBtn = document.getElementById(hideShowSecondTabBtnId);
    var secondTabElem = document.getElementsByClassName(secondTabClass)[0];
    secondTabElem.classList.remove("app-tabs-second-hide");
    secondTabElem.classList.add("app-tabs-second-show");
    secondTabPannelStateBtn.classList.add("icon-chevrons-down");
    secondTabPannelStateBtn.classList.remove("icon-chevrons-up");
}
function HideSecondTab() {
    var secondTabPannelStateBtn = document.getElementById(hideShowSecondTabBtnId);
    var secondTabElem = document.getElementsByClassName(secondTabClass)[0];
    secondTabElem.classList.remove("app-tabs-second-show");
    secondTabElem.classList.add("app-tabs-second-hide");
    secondTabPannelStateBtn.classList.remove("icon-chevrons-down");
    secondTabPannelStateBtn.classList.add("icon-chevrons-up");
}

function InitAppTabsPannel() {
    var secondTabPannelStateBtn = document.getElementById(hideShowSecondTabBtnId);
    if (secondTabPannelStateBtn != undefined) {
        secondTabPannelStateBtn.onclick = function (e) {
            var isDown = secondTabPannelStateBtn.classList.contains("icon-chevrons-down");
            if (isDown) {
                HideSecondTab();
        
            } else {
                ShowSecondTab();
            }
        }
    }
}


async function InitSelectBlockTabs(className) {
    var blocks = document.getElementsByClassName(className);
    //for (var i = 0; i < blocks.length; i++) {
    //    var a = block[i];
    //    $(a).tab('show');
    //}

   
}




window.getDimensions = function () {
    return {
        width: window.innerWidth,
        height: window.innerHeight
    };
};