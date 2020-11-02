

console.log("SlideBar methodes were loaded");

class SlideBarClass {

    constructor() {

        if (isYourPage()) {
            document.getElementById("SavePage-btn").onclick = function () { SavePage(); };
            document.getElementById("AddPhoto-btn").onclick = function () { AddForm("photo", NewBlockStartinfo); };
            document.getElementById("AddList-btn").onclick = function () { AddForm("list", NewBlockStartinfo); };
            document.getElementById("AddHTML-btn").onclick = function () { AddForm("html", NewBlockStartinfo); };
            document.getElementById("AddFrame-btn").onclick = function () { AddForm("frame", NewBlockStartinfo); };
            document.getElementById("BackgroundLoad-btn").onclick = function () {
                var opt = {
                    $OutImageBlock: $("body"),
                    Block: "Background"
                }
                LoadImage.OpenGalary(opt);
            };


            document.getElementById("BackgroundRotate-input").oninput = function () { RotateBlockBackground(this.value, SlideBar.$block, true); };
            document.getElementById("BackgroundColorPicker-input").oninput = function () { SetColorBackground(this.value, SlideBar.$block, true); };
            document.getElementById("Effects-input").oninput = function () { SetBlockEffect(this.value, SlideBar.$block, true); };
            var scew = { x: 0, y: 0 };

            document.getElementById("ScewX-input").oninput = function () { scew.x = this.value; SetBlockSkew(clone(scew), SlideBar.$block, true); };
            document.getElementById("ScewY-input").oninput = function () { scew.y = this.value; SetBlockSkew(clone(scew), SlideBar.$block, true); };
            var translate = { x: 0, y: 0 };
            document.getElementById("TranslateX-input").oninput = function () { translate.x = this.value; SetBlockTranslate(clone(translate), SlideBar.$block, true); };
            document.getElementById("TranslateY-input").oninput = function () { translate.y = this.value; SetBlockTranslate(clone(translate), SlideBar.$block, true); };
            document.getElementById("Scale-input").oninput = function () { SetBlockScale(this.value, SlideBar.$block, true); };
            document.getElementById("Layer-input").oninput = function () { SetBlockLayer(this.value, SlideBar.$block, true); };
            this.ChangeType("SpawnBlockMenu", "spawn");
        }
    }

    ChangeType(type, $block) {
        var id = null;
        if ($block == "spawn") {
            this.$block = $();

        } else {
            this.$block = $block;
            var menu = document.getElementsByTagName('body')[0];
            if (!hasClass(menu, "open")) document.getElementById("menu-toggle").click();
            id = $block.attr('id');
        }

        if (true) {
            this.HideAll();
            this.type = type;
            switch (type) {
                case "SpawnBlockMenu":
                    DisplayUnset($(".SpawnBlockMenu"));
                    break;
                case "EditBlockMenu":

                    var effect = EffectsPool[id]
                    var $EffectInput = $('#Effects-input');
                    if (effect == undefined) {
                        document.getElementById('Effects-input').value = 'none';
                        //console.log("NoEffect");
                    } else {
                        switch (effect.ref.type) {
                            case "confetti":
                                document.getElementById('Effects-input').value = 'confetti';
                                break;
                        }

                    }
                    
                    var Transform = TransformPool[id];
                    
                    document.getElementById('ScewX-input').value = Transform.skew.x;
                    document.getElementById('ScewY-input').value = Transform.skew.y;
                    document.getElementById('BackgroundRotate-input').value = Transform.rotate;
                    document.getElementById('TranslateX-input').value = Transform.translate.x;
                    document.getElementById('TranslateY-input').value = Transform.translate.y;
                    document.getElementById('BackgroundColorPicker-input').value = Transform.bgcolor;
                    document.getElementById('Scale-input').value = Transform.scale;
                    document.getElementById('Layer-input').value = Transform.layer;
                    //console.log(Transform.skew);
                    DisplayUnset($(".EditBlockMenu"));
                    break;
            }
        }
        
    }

    HideAll() {
       // console.log("ss");
        DisplayNone($(".SpawnBlockMenu"));
        DisplayNone($(".EditBlockMenu"));
    } 

    CheckClick(event) {

        if (this.type == "EditBlockMenu") {
            $block = $(event.target);
            var reset = true;
            var $one = $block.parents(".DynamicBlock");

            if (($block.parents("#SlideBarList")[0] != undefined)) {
                reset = false;
            } else if (this.$block.is($one)) {
                reset = false;
            } else 
            if ($block.attr("id") == "menu-toggle") reset = false;

            if (reset) {
                this.ChangeType("SpawnBlockMenu", "spawn");
                //console.log("Reset");
            } else {
                //console.log("No Reset");
            }
        }
        
    }
    
}


