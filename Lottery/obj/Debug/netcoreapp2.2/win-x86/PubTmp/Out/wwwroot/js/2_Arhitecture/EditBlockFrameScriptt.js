console.log("EditBlockFrame methodes were loaded");
$EditBlockFrame = $();
$BlockForTransform = $();
var pressed = false;
var num;
var mouse;

function ClearEditBlockFrame() {
    $BlockForTransform = $();
}

function HideEditBlockFrame() {
    $EditBlockFrame.css({ 'display': 'none' });
}

function ShowEditBlockFrame() {
    $EditBlockFrame.css({ 'display': 'block' });  
}

function RightSideEditBlockSizingCheck() {
    var $MainContent = $("#Main-Content");
    var Content_Width = $MainContent.width();

    var SummuaryEditBlockWidth = parseInt($EditBlockFrame.css('left')) + $EditBlockFrame.width();
    if (SummuaryEditBlockWidth > Content_Width) {
        //console.log("Вышел за диапазон");
        $EditBlockFrame.css({
            'width': Content_Width - parseInt($EditBlockFrame.css('left')) + "px",
        });
    } else {
       // console.log("в диапазоне");
    }
}

function TopAndBottomSideEditBlockSizingCheck(Delta) {
    var $MainContent = $("#Main-Content");
    var HeaderHeight = parseInt( $('header').height() );

    var Content_Height = $MainContent.height() + HeaderHeight; 

    //console.log($EditBlockFrame.css('top'));

    //console.log('header height=', HeaderHeight, ' top=', parseInt($EditBlockFrame.css('top')) )

    //верхняя граница
    if (parseInt($EditBlockFrame.css('top')) < HeaderHeight ) {
        //console.log("вышел за верхний диапазон");
        $EditBlockFrame.css({
            'top': HeaderHeight + "px",
            'height': parseInt($EditBlockFrame.css('height')) - Delta.y + "px",
        });

    }

    //нижняя граница
    var SummuaryEditBlockHeight = parseInt($EditBlockFrame.css('top')) + $EditBlockFrame.height();
    if (SummuaryEditBlockHeight > Content_Height) {
        //console.log("Вышел за нижний диапазон");
        $EditBlockFrame.css({
            'height': Content_Height - parseInt($EditBlockFrame.css('top')) + "px",
            
        });
    } 
    
}

function OnTransformBlockUpdate() {

    //перемещение блока за рамой 
    if ($BlockForTransform) {

        //трансформация выбранного блока 
        //console.log("Transforming block");
        $BlockForTransform.css({
            'left': $EditBlockFrame.css("left") ,
            'top': $EditBlockFrame.css("top") ,
            'height': $EditBlockFrame.css("height"),
            'width': $EditBlockFrame.css("width"),
        });

        //сохранение информации о редактировании блока
        var info;
        if (Global_UpdateBlockInformation[$BlockForTransform.attr("id")] == undefined) {
            info = {};
        }
        else {
            info = Global_UpdateBlockInformation[$BlockForTransform.attr("id")];
        }

        //установка в объект для пересылки
        info.height = parseInt($BlockForTransform.css("height"));
        info.width = parseInt($BlockForTransform.css("width"));
        info.left = parseInt($BlockForTransform.css("left"));
        info.top = parseInt($BlockForTransform.css("top"));

        Global_UpdateBlockInformation[$BlockForTransform.attr("id")] = info;
    }
}


function WearBlockinFrame($block) {
    //перемещение рамы на блок 
    $BlockForTransform = $block;
    

    $EditBlockFrame.css({
        'left': $block.css("left"),
        'top': $block.css("top"),
        'height': $block.css("height"),
        'width': $block.css("width"),
    });
}






//Transforming
//Transform
function On(e) {
    pressed = true;

    num = this.id.split("-")[1];

    mouse = getPosition(e);

    //$BlockForTransform.draggable('disable');
}

function Off(e) {
    pressed = false;
    //$BlockForTransform.draggable('enable');
}


function DotMove(e) {
    //console.log("called mousemove");
    if (pressed) {

        newMouse = getPosition(e);
        //console.log(e);
        Delta = { x: mouse.x - newMouse.x, y: mouse.y - newMouse.y };


        var left_str = $EditBlockFrame.css("left");
        var top_str = $EditBlockFrame.css("top");

        var height_str = $EditBlockFrame.css("height");
        var width_str = $EditBlockFrame.css("width");

        var left = parseInt(left_str, 10);
        var top = parseInt(top_str, 10);

        var height = parseInt(height_str, 10);
        var width = parseInt(width_str, 10);

        switch (num) {
            case '8':
                $EditBlockFrame.css({
                    'height': (height - Delta.y) + "px",
                });
                break;
            case '7':
                $EditBlockFrame.css({
                    'left': (newMouse.x) + "px",
                    'height': (height - Delta.y) + "px",
                    'width': (width + Delta.x) + "px"

                });
                break;
            case '6':
                $EditBlockFrame.css({
                    'left': (newMouse.x) + "px",
                    'width': (width + Delta.x) + "px"
                });
                break;
            case '5':
                $EditBlockFrame.css({
                    'left': (newMouse.x) + "px",
                    'top': (newMouse.y) + "px",
                    'height': (height + Delta.y) + "px",
                    'width': (width + Delta.x) + "px"
                });
                break;
            case '4':
                $EditBlockFrame.css({
                    'top': (newMouse.y) + "px",
                    'height': (height + Delta.y) + "px",

                });
                break;
            case '3':
                $EditBlockFrame.css({
                    'top': (newMouse.y) + "px",
                    'height': (height + Delta.y) + "px",
                    'width': (width - Delta.x) + "px"

                });

                break;
            case '2':
                $EditBlockFrame.css({
                    'width': (width - Delta.x) + "px"
                });
                break;
            case '1':
                $EditBlockFrame.css({
                    'width': (width - Delta.x) + "px",
                    'height': (height - Delta.y) + "px",
                });


                break;

        }

        //check sides
        RightSideEditBlockSizingCheck();
        TopAndBottomSideEditBlockSizingCheck(Delta);

        OnTransformBlockUpdate();
        mouse = newMouse;

    }
}