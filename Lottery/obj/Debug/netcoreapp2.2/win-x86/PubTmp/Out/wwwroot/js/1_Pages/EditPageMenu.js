console.log("Edit Page Menu methodes were loaded");
    //Exelent little functions to use any time when class modification is needed
    
//Add event from js the keep the marup clean
function init() {
    if (document.getElementById("menu-toggle") != undefined) {
        document.getElementById("menu-toggle").addEventListener("click", toggleMenu);
    }
       
    }
    //The actual fuction
    function toggleMenu() {
       
        var ele = document.getElementsByTagName('body')[0];
  
        if (!hasClass(ele, "open")) {
        addClass(ele, "open");
    } else {
        removeClass(ele, "open");
    }
}
//Prevent the function to run before the document is loaded
    document.addEventListener('readystatechange', function () {
        if (document.readyState === "complete") {
        init();
    }
});


