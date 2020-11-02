console.log("Adaptive script were loaded");
class AdaptivePage {

    constructor(options = undefined) {

        this.Methode = 1;

        //methode 1
        this.Left_k = 1;
        this.Top_k = 1;
        this.Height_k = 1;
        this.Width_k = 1;

        //methode 2
        //this.BindAdaptiveOnResize();
    }


    BindAdaptiveOnResize()
    {
        var Resize = function f() {
            //console.log("resize");
            this.AdaptiveMethode_2();
        };
        Resize = bindFunc(Resize, this);

        $(window).resize(Resize);


    }

    AdaptiveMethode_1() {
        
    }


    AdaptiveMethode_2() {
        //return;
        //alert("Adaptive 2");
        console.log("Adaptive methode : 2");

        var MaxBlockLenghtWidth = 0, MaxBlockLenghtHeight = 0;
        
        var $DynamicBlocks = $(".DynamicBlock");
        
        $.each($DynamicBlocks, function (ind, value) {
            
            var $val = $(value);
            var left = parseInt($val.css('left'));
            var top = parseInt($val.css('top'));
            var height = $val.height();
            var width = $val.width();

            //find max distance to transform html width and height
            var width_len = width + left;
            var height_len = height + top;

            if (width_len > MaxBlockLenghtWidth) MaxBlockLenghtWidth = width_len;
            if (height_len > MaxBlockLenghtHeight) MaxBlockLenghtHeight = height_len;

            

        });
        //console.log(innerWidth);
        if (innerHeight < MaxBlockLenghtHeight) if (MaxBlockLenghtHeight != 0) {
            //$('html').height((MaxBlockLenghtHeight + 50) + 'px');
            $('.MainContainer').css({ 'min-height': (MaxBlockLenghtHeight - 20) + 'px' });
            console.log("Height changed");
        }
        if (innerWidth < MaxBlockLenghtWidth) if (MaxBlockLenghtWidth != 0) {
            $('html').width((MaxBlockLenghtWidth + 30) + 'px');
            console.log("Width changed");
        }
        
        
    }

   
    


}
var AdaptivePageRef = new AdaptivePage();


