console.log("Preloader methodes were loaded");
function ShowPreloader(info) {
    if (info != undefined) {
        $("#PreloaderInformation").text(info);
    }

    DisplayBlock($(".loading-area")); 

    
}

function HidePreloader() {
    $("#PreloaderInformation").text("");
    DisplayNone($(".loading-area"));
    //console.log("Hide preloader");
    
   // alert("op");
}


