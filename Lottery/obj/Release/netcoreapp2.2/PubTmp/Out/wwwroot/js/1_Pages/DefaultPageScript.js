


console.log("PersonalPage methodes were loaded");



//send save info
function SavePage() {

    console.log("--------------SavePage-----------------------");
    var arr = new Array();
    var o = new Object();
    
    for (var key in Global_UpdateBlockInformation) {

        if (o[key] === undefined)
            o[key] = new Object();
        o[key].info = Global_UpdateBlockInformation[key];
    }


    for (var key in Global_UpdateAdditionInfo) {
        if (o[key] === undefined)
            o[key] = new Object();
        o[key].AdditionInfo = Global_UpdateAdditionInfo[key].AdditionInfo;
    }


    for (var key in o) {

        o[key].FullName = key;
        arr.push(o[key]);
    }

    //console.log(arr);

    var FORM = new FormData();
    FORM.append("PageName", PageName);
    var AcceptSending = false;

    if (arr.length > 0)
    {
        var SavePageModel = { models: arr };
        console.log(SavePageModel);

        FORM.append("BlocksSaveObject", JSON.stringify(SavePageModel)); 
        AcceptSending = true;
    }

    for (var key in Global_SavePageForm) {
        if (Global_SavePageForm[key] != undefined) {
            console.log(Global_SavePageForm[key]);
            if ((typeof Global_SavePageForm[key] == "object") && !(Global_SavePageForm[key] instanceof String) && !(Global_SavePageForm[key] instanceof File)) {
                FORM.append(key, JSON.stringify(Global_SavePageForm[key]));
               
            } else {
                FORM.append(key, Global_SavePageForm[key]);
            }
            
            AcceptSending = true;
        }
    }

    //clear sent info
    Global_UpdateBlockInformation = {};
    Global_UpdateAdditionInfo = {};
    Global_SavePageForm = {};

    
    


    if (AcceptSending) {
        
        ShowPreloader("Saving Page...");
        var timeout = setTimeout(function () { ShowPreloader("Time out"); }, 10000);
        $.ajax(
            {
                url: "/PersonalPages/ProcessSavePageData",
                type: 'POST',
                data: FORM,
                processData: false,
                contentType: false,
                success: function (data) {
                    setTimeout(function () { HidePreloader(); }, 3000);
                    clearTimeout(timeout);
                },
                error: function (data) {
                    ShowPreloader("ERROR");
                    setTimeout(function () { HidePreloader(); }, 3000);
                    clearTimeout(timeout);
                }
                
            }
        );

        
        return;
    } else {
        console.log("Canceled");
    }



}


function CreatePhotoBlock(id, info) {

    var type = 'photo';
    var name = type + '-' + id;
    $html = isYourPage() ? $("#Templates").find("#OneBlockTemplate").clone() : $("#Templates").find("#OneBlockTemplate_Guest").clone();
    $MainDiv = $html;
    $MainDiv.addClass("DynamicBlock");
    $MainDiv.addClass(type.toUpperCase());
    $MainDiv.attr('id', name);


    //$MainDiv.css({
    //    left: info.left, top: info.top, height: info.height, width: info.width,  //установка позиции и размеров
    //});
    $MainDiv.find("#Photo").attr("src", info.img);
    if (info.title != undefined) $MainDiv.find("#Title").text(info.title);
    if (info.post != undefined) $MainDiv.find("#Post").text($("#" + info.post).text());

    if (isYourPage()) {
        //alert("dwdw");
        var func = function () {
            var opt = { $OutImageBlock: this, Block: name };
            LoadImage.OpenGalary(opt);
        };
        func = bindFunc(func, $MainDiv.find("#Photo"));

        //events
   
        $MainDiv.find("#TwoSection").on("click", func);

        $MainDiv.find("#TwoSection").find("i").append("<img class='ActionImage' src='/resources/icons/cloud-upload.png' />");


        var Title_Input = new InputField($MainDiv.find("#Title"), $MainDiv.find("#TitleInput"));
        var Post_Input = new InputField($MainDiv.find("#Post"), $MainDiv.find("#PostInput"));

        //регистрация внутренних действий в блоке 
        Title_Input.OnSaveValue = function () {
            AddAdditionInfo(name, "Title", this.Value);
        };
        Post_Input.OnSaveValue = function () {
            AddAdditionInfo(name, "Post", this.Value);
        };
    }

    var Result = { title: Title_Input, post: Post_Input, $Ref: $MainDiv };


    

    $("#BlocksPlace").append($MainDiv);
    console.log(Result);
    return Result;
}

function CreateList(id, info) {
    var type = 'list';
    var name = type + '-' + id;
    $html = isYourPage() ? $("#Templates").find("#TwoBlockTemplate").clone() : $("#Templates").find("#TwoBlockTemplate_Guest").clone();
    $MainDiv = $html;
    $MainDiv.addClass("DynamicBlock");
    $MainDiv.addClass(type.toUpperCase());
    $MainDiv.attr('id', name);

    var PostInput = new InputField($MainDiv.find("#Post"), $MainDiv.find("#PostInput"));

    PostInput.OnSaveValue = function () {
        AddAdditionInfo(name, "Post", this.Value);
    };


    $MainDiv.css({
        left: info.left, top: info.top, height: info.height, width: info.width,  //установка позиции и размеров
    });


    if (info.post != undefined) $MainDiv.find("#Post").text($("#" + info.post).text());


    var Result = { post: PostInput, $Ref: $MainDiv };

    $("#BlocksPlace").append($MainDiv);
    console.log(Result);
    return Result;
}

function CreateHTML(id, info) {

    var type = 'html';
    var name = type + '-' + id;
    //console.log("1----");
    $html = isYourPage() ? $("#Templates").find("#TwoBlockTemplate").clone() : $("#Templates").find("#TwoBlockTemplate_Guest").clone();
    $MainDiv = $html;
    $MainDiv.addClass("DynamicBlock");
    $MainDiv.addClass(type.toUpperCase());
    $MainDiv.attr('id', name);

    //Preview

    if (info.file != undefined) {
        var $Previw = $MainDiv.find(".icon").prepend("<li><a id='PreviewButton' href='#'><i ><img class='ActionImage' src='/resources/icons/full-screen-exit.png' /></i></a></li >");
        SetBlockPreviewLink($Previw.find("#PreviewButton"), info.file);
    }
   

    if (isYourPage()) {
        //Load file create button 
        var $Cre = $MainDiv.find(".icon").prepend("<li><a id='LoadFile--0' href='#'><i ><img class='ActionImage' src='/resources/icons/cloud-upload.png' /></i></a></li >");
        $Cre.find("#LoadFile--0").on('click', function () { LoadFile.OpenGalary({ Block: name }); console.log("click "); });
        //console.log("2----");
    }
    

    //установка сохраненной информации
    $MainDiv.css({
        left: info.left, top: info.top, height: info.height, width: info.width,
    });

    $MainDiv.find("#Content").html("LOAD YOUR HTML PAge !");
    //загрузка содержимой страницы
    if (info.file != undefined) {
        console.log("Load ", info.file);
        //$MainDiv.find("#Content").load(info.file);
        $MainDiv.find("#Content").html("<iframe src='" + info.file + "' />");
        $MainDiv.find("#Content").find("iframe").css({ 'height': '100%', 'width': '100%' });
    }

    $("#BlocksPlace").append($MainDiv);

    var Result = { post: PostInput, $Ref: $MainDiv };
    console.log(Result);
    return Result;
}

function CreateFrameBlock(id, info) {
    var type = 'frame';
    var name = type + '-' + id;

    $html = isYourPage() ? $("#Templates").find("#TwoBlockTemplate").clone() : $("#Templates").find("#TwoBlockTemplate_Guest").clone();
    $MainDiv = $html;
    $MainDiv.addClass("DynamicBlock");
    $MainDiv.addClass(type.toUpperCase());
    $MainDiv.attr('id', name);

    //адаптация iframe под хоста видео
    function adaptive(url) {
        var isYoutube = RegExp('\\b' + 'www.youtube.com' + '\\b').test(url);
        if (isYoutube) {
            url = insert(url, "embed/", url.indexOf("www.youtube.com") + 15);
            var start = url.indexOf("watch?v=") + 8;
            url = "https://www.youtube.com/embed/" + url.substring(start);
            console.log("YouTube = ", url);
            return url;
        }
    }

    //добавления блока iframe 
    $MainDiv.find("#Content").html("<iframe   frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>");
    $MainDiv.find("#Content").find("iframe").css({ 'height': '100%', 'width': '100%' });



    //загрузка видео
    if (info.video != undefined) {
        console.log("Load video ", info.video);
        $MainDiv.find("#Content").find("iframe").attr("src", info.video);
    }


    if (isYourPage()) {
        //Load file create button 
        var $Cre = $MainDiv.find(".icon").prepend("<li><a id='LoadFile--0' href='#'><i ><img class='ActionImage' src='/resources/icons/cloud-upload.png' /></i></a></li >");
        $Cre.find("#LoadFile--0").on('click', function () { LoadVideo.OnVideoUrlChange = VideoChange; LoadVideo.OpenModal({ Block: name }); });
    }
    
    //установка видео по url
    function VideoChange(url, block) {
        //url = adaptive(url);
        $MainDiv.find("#Content").find("iframe").attr("src", url);
        AddAdditionInfo(block, "frame", url);
    }
    //кнопка открытия модального окна
   

    //установка сохраненной информации
    $MainDiv.css({
        left: info.left, top: info.top, height: info.height, width: info.width,
    });




    $("#BlocksPlace").append($MainDiv);

    var Result = { $Ref: $MainDiv };
    console.log(Result);
    return Result;

}

function AddAdditionInfo(BlockImageName, AddName, Property) {

    var info = Global_UpdateAdditionInfo[BlockImageName];
    if (info == undefined) {
        info = {};
        Global_UpdateAdditionInfo[BlockImageName] = info;
    }

    var list = info.AdditionInfo;
    if (list == undefined) {
        list = {};
        info.AdditionInfo = list;
    }

    list[AddName] = Property;

    console.log(Global_UpdateAdditionInfo[BlockImageName]);
}

function AddForm(str, info,trusted = true) {
    var ChoosedId;
    if (info.id == undefined ) {
        ChoosedId = GenerateBlockIndex(str);
    }
    else {
        ChoosedId = info.id;
    }

    if (trusted) {
        var top = window.pageYOffset + innerHeight / 2 - info.height;
        var left = window.pageXOffset + innerWidth / 2 - info.width;
        info.left = left;
        info.top = top;
    }
    


    //console.log(left);

    var Result = null;
    switch (str) {
        case "photo":
            Result = CreatePhotoBlock(ChoosedId, info);
            break;
        case "list":
            Result = CreateList(ChoosedId, info);
            break;
        case "note":

            break;
        case "frame":
            Result = CreateFrameBlock(ChoosedId, info);
            break;
        case "html":
            Result = CreateHTML(ChoosedId, info);
            break;
    }
    console.log("Created block", str, ChoosedId);
    StartBlockConfigure(info, Result);

    
    //console.log(info);

}

function StartBlockConfigure(info,Result) {
    if (Result != null) {
        if (isYourPage()) {
            DraggBindOn(Result.$Ref);//отвечает за перемещение блока
        } else
        
        console.log(Result.$Ref.attr('id'));
        TransformPool[Result.$Ref.attr('id')] = {};
        RotateBlockBackground(info.rotate, Result.$Ref);
        SetColorBackground(info.bgcolor, Result.$Ref);
        SetBlockSkew(info.skew, Result.$Ref);
        SetBlockTranslate(info.translate, Result.$Ref);
        SetBlockEffect(info.effect, Result.$Ref);
        SetPositionAndSize(info, Result);
        SetBlockScale(info.scale, Result.$Ref);
        UpdateTransform(Result.$Ref);
        SetBlockLayer(info.layer, Result.$Ref);

    }
}


function DeleteBlock(BlockImageName) {
    var $that = $("#" + BlockImageName);

    if ($BlockForTransform.is($that)) {
        ClearEditBlockFrame();
        HideEditBlockFrame();
    }

    if (SlideBar.$block.is($that)) {
        SlideBar.ChangeType("SpawnBlockMenu", "spawn");
    }

    $that.remove();

    //удаление информации о блоке
    delete Global_UpdateBlockInformation[BlockImageName];
    delete Global_SavePageForm[BlockImageName + "+image"];
    delete Global_SavePageForm[BlockImageName + "+settings"];

    //добавление удаления в форму отправки
    Global_SavePageForm[BlockImageName + "+delete"] = "is";


    //console.log("Добавлено в форму");


}
function DraggBindOn(block_) {

    $block = block_;

//используется для сохранения новой позиции блока без открытия рамы маштабирования
    $block.draggable({
        containment: "#Main-Content",
        drag: function () {
            //добавляем информацию о изменении
            var info_;

            if (Global_UpdateBlockInformation[this.id] == undefined) {
                info_ = {};
            }
            else {
                info_ = Global_UpdateBlockInformation[this.id];
            }

            info_.left = parseInt($(this).css("left"));
            info_.top = parseInt($(this).css("top"));
            Global_UpdateBlockInformation[this.id] = info_;

            //передвижение рамы маштабирования
            if ($BlockForTransform.is($(this))) {
                $EditBlockFrame.css({
                    'left': info_.left,
                    'top': info_.top
                });
                info_ = {};
            }

        }
    });

}

function setBlockInfo(id,key,value) {
    var info_;
    if (Global_UpdateBlockInformation[id] == undefined) {
        info_ = {};
    }
    else {
        info_ = Global_UpdateBlockInformation[id];
    }

    info_[key] = value;
    
    Global_UpdateBlockInformation[id] = info_;
}
function setPageInfo(key, value) {
    var info_;
    if (Global_SavePageForm["PageInfoObject"] == undefined) {
        info_ = {};
    }
    else {
        info_ = Global_SavePageForm["PageInfoObject"];
    }

    info_[key] = value;

    Global_SavePageForm["PageInfoObject"] = info_;
}

function getBlockInfo(id, key) {
    if (Global_UpdateBlockInformation[id] == undefined) {
        return "";
    } else if (Global_UpdateBlockInformation[id][key] == undefined) {
        return "";
    } else {
        return Global_UpdateBlockInformation[id][key];
    }
}

function CloseNoteEdit(note) {
    $Main = $('#' + note).children('#Main');
    var str1 = $Main.children('text').text();
    var str = $Main.children('textarea').val();

    $Main.children('text').empty();
    $Main.children('text').append(str);

    $Main.children('button').remove();
    $Main.children('textarea').remove();

    $text = $Main.children('text');
    $text.css({ 'display': 'inherit', });

    $Main.attr("opened", "false");

    if (!(str1 === str)) {

        var o = { To: note, Value: str, Property: 'text' };
        $.post("/Pages/AddProperty", o);
    }





}
function openEditor(id) {//id of this note 
    $Main = $('#' + id).children('#Main');
    $bl = $('#' + id);
    var b = ($Main.attr("opened") === "true");
    if (b) {

    }
    else {
        $text = $Main.children('text').text();
        $Main.children('text').css({ 'display': 'none', });

        $Main.append('<textarea style="height: inherit; Width: inherit;">' + $text + '</textarea>');
        $OKbutton = $('<button>', { onclick: 'CloseNoteEdit("' + $bl.attr("id") + '")', text: "OK", class: "btn" });
        $OKbutton.appendTo($Main);


        $Main.attr("opened", "true");
    }
}
function ShowEditMenuBind(block_) {
    $block = block_;

    $block.on('dblclick', function (event) {
        event.preventDefault();
        // console.log("ddsd");
        ShowEditMenuBlock($(this).attr('id'));


    });
}
function HideEditMenuBlock(id) {
    $block = $('#' + id);
    $block.find('#EditMenu-small').css({ 'display': 'none' });
    $block.find('.controler').css({ 'display': 'none' });

    $pols = $block.children('.pols');
    $pols.css({ 'display': 'none' });
}
function ShowEditMenuBlock(id) {
    $block = $('#' + id);
    $block.find('#EditMenu-small').css({ 'display': 'initial' });
    $block.find('.controler').css({ 'display': 'initial' });

    $pols = $block.children('.pols');
    $pols.css({ 'display': 'initial' });
}









//Settings block, изменение блока

function SetBlockEffect(effect, $block, trusted = false) {
    if (effect == undefined) return;
    var id = $block.attr("id");
   
    switch (effect) {

        case "none":
             if(EffectsPool[id] != undefined)
             {

             EffectsPool[id].ref.stop();
             $("#" + EffectsPool[id].ref.name).remove();
             delete EffectsPool[id];
            }
            break;

        case "confetti":
            var confetti = { ref: null };
            ConfettiConfigure(confetti, id);
            confetti.ref.start();
            confetti.ref.attach($block);
            EffectsPool[id] = confetti;
            console.log($block);
            break;
    }
    if (trusted) { setBlockInfo(id, "effect", effect); }
    
    
}


function RotateBlockBackground(Deg, $block,trusted = false) {
    if (Deg == undefined) return;
    var id = $block.attr("id");
    
    TransformPool[id].rotate = Deg;
    if (trusted) {
        setBlockInfo(id, 'rotate', Deg)
        UpdateTransform($block);
    };
    
   
}
function SetBlockSkew(skew, $block, trusted = false) {
    if (skew == undefined) return;
    var id = $block.attr("id");
    TransformPool[id].skew = skew;
    if (trusted) {
        setBlockInfo(id, "skew", skew);
        UpdateTransform($block);
    }
   
}

function SetBlockTranslate(translate, $block,trusted = false) {
    if (translate == undefined) return;
    var id = $block.attr("id"); 
    TransformPool[id].translate = translate;
    if (trusted) {
        setBlockInfo(id, "translate", translate);
        UpdateTransform($block);
    }
    
}
function SetBlockScale(scale, $block, trusted = false) {
    if (scale == undefined) return;
    var id = $block.attr("id");
    TransformPool[id].scale = scale;
    if (trusted) {
        setBlockInfo(id, "scale", scale);
        UpdateTransform($block);
    }
    
}
function SetColorBackground(color, $block, trusted = false) {
    if (color == undefined) return;

    var id = $block.attr("id");
    TransformPool[id].bgcolor = color;
    if (trusted) {
        
        setBlockInfo($block.attr("id"), 'bgcolor', color);
    }
    $block.find('.box').css({ 'background': color }); 
    
}
function SetBlockLayer(layer, $block, trusted = false) {
    if (layer == undefined) return;

    var id = $block.attr("id");
    TransformPool[id].layer = layer;
    if (trusted) {
        
        setBlockInfo(id, "layer", layer);
    }
    $block.css({ 'z-index': layer }); 
}

function UpdateTransform($block) {

    var id = $block.attr("id");
    var Transform = TransformPool[id];

    var str = "rotate(" + Transform.rotate + "deg) "
        + "translate(" + Transform.translate.x + "%," + Transform.translate.y + "%) "
        + "skew(" + Transform.skew.x + "deg," + Transform.skew.y + "deg) " +
        "scale(" + Transform.scale + ") ";

    $block.find('.Transform').css({ 'transform': str });
    //console.log(str);
}



function SetPositionAndSize(info,Result)
{
  Result.$Ref.css({
     left: info.left + "px", top: info.top + "px", height: info.height+ "px", width: info.width+ "px",  //установка позиции и размеров
  });

}


function CheckMouseDownPrevent(event) {
    //console.log(event.target.tagName);
    var prevent = !((event.target.tagName == "INPUT") || (event.target.tagName == "TEXTAREA") || (event.target.tagName == "SELECT"));
    if (prevent) {
        event.preventDefault();
        //alert("Prevented");
        return true;
    } else {
        return false;
    }
}



function SetBlockPreviewLink($block, path) {
    //alert(path);
    $block.attr("href", "/Home/Preview?path=" + path);
}

function tesststts() {
    if (device.mobile()) {
        window.BlockDrag = undefined;
        Result.$Ref.draggable('disable');

        Result.$Ref.on("click", function (e) {

            if (window.BlockDrag != undefined) {
                $(window.BlockDrag).draggable('disable');
            }

            if (touchtime == 0) {
                // set first click
                touchtime = new Date().getTime();
            }
            else {
                // compare first click to this click and see if they occurred within double click threshold
                if (((new Date().getTime()) - touchtime) < 800) {
                    // double click occurred

                    $(this).draggable('enable');
                    window.BlockDrag = this;
                    //alert("double clicked");
                    touchtime = 0;
                }
                else {
                    // not a double click so set as a new first click

                    touchtime = new Date().getTime();

                }

            }
        });

    }
}




function SizePage(action,height = null) {
    var DeltaValue = 100;

    //var hheight = $('html').height();
    var mheight = parseInt($('.MainContainer').height());

    var height;
    switch (action) {
        case "increase":
            height = mheight + DeltaValue;

            $('.MainContainer').css({ 'height': height + 'px' });
            setPageInfo("PageHeight", height)  
            break;
        case "decrease":
            var min_height = parseInt($('.MainContainer').css('min-height'));
            
            if (min_height < mheight) {
                height = mheight - DeltaValue;

                $('.MainContainer').css({ 'height': height + 'px' });
                setPageInfo("PageHeight", height)  
            }
            
            break;
    }
    
   

    window.scrollTo(0, document.body.scrollHeight);
}
function SetSizePage(height) {
    
    $('.MainContainer').css({ 'height': height + 'px' });
}


function LikePage(To) {
    if (!PageLiked) {
        $.post("/General/LikeAsync", {To: To });
        
        var likes = parseInt($("#LikeFiled").html());
        likes++;
        $("#LikeFiled").html(likes);
        PageLiked = true;
    } else {
        $.post("/General/RemoveLikeAsync", { To: To });
        var likes = parseInt($("#LikeFiled").html());
        likes--;
        $("#LikeFiled").html(likes);
        PageLiked = false;
    }
   
}