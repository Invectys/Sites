console.log("Modal Image were loaded");

class ModalLoadImageControl {

    constructor(ModalId) {
        this.ImageInfo = { left: '0px', top: '0px' }; //информация о редактировнии картинки при загрузке
        this.$CustomFile = $();
        this.type = "FromGalary";
        
        this.SelectedImageName = undefined;
        this.ModalImageId = ModalId;
        this.ImageGalaryId = ModalId + "-ImageGalary";
        this.ImageGalary = {};
        this.$OutImageBlock = $();
        this.OutImageInput = null;
        this.BlockImageName = "";
        this.bSelectFrameValid = false;
        this.SelectFrameHeight = "300";
        this.SelectFrameWidth = "300";
        

    }

    setType(type) {
        this.type = type;
    }
    Configurate(options) {
        var object = options;
        

        if (object != undefined) {
            this.BlockImageName = options.Block;
            if (object.$OutImageBlock != undefined) this.$OutImageBlock = object.$OutImageBlock;
            if (object.OutImageInput != undefined) this.OutImageInput = object.OutImageInput;

            if (object.SelectFrameHeight != undefined) this.SelectFrameHeight = object.SelectFrameHeight;
            if (object.SelectFrameWidth != undefined) this.SelectFrameWidth = object.SelectFrameWidth;

            if (object.bSelectFrameValid != undefined) this.bSelectFrameValid = object.bSelectFrameValid;
            if (object.bLoadImageInModal != undefined) this.bLoadImageInModal = object.bLoadImageInModal;
        }


        this.$CustomFile = $("#" + this.ModalImageId).find("#CustomFile"); 

        var ChangeFile = function (e) {
            var inp = this[0];
            var file = inp.files[0];
            if (file != undefined) {
                var str = file.name;
                console.log("выбран файл = ", str);

                var forBlockImageName = e.data.ref.BlockImageName;
                console.log("Image for block ", forBlockImageName);

                e.data.ref.Update(inp);
            }
            
        }

        

       
        

        ChangeFile = bindFunc(ChangeFile, this.$CustomFile);
        this.$CustomFile.on("change", {ref:this},ChangeFile);

        if (this.bSelectFrameValid) {
            $("#" + this.ModalImageId).find("#SelectFrame").draggable({
                containment: "parent",
                stop: function () {
                    this.updateFileInfo(this);
                    this.MoveStartImage();

                }
            });
        }
    }

    OpenModal() {
        console.log("-------------------------Open Load Modal box-------------------");
        console.log("Action:", this.BlockImageName);

        this.setType("New");

        //console.log("settings = ", object);

        var $ModalBox = $("#" + this.ModalImageId);

        this.$SelectFrame = $ModalBox.find("#SelectFrame");
        if (this.bSelectFrameValid)
        {

            this.$SelectFrame.css(
            {
                'height': SelectFrameHeight,
                'width': SelectFrameWidth,
            });
            

        console.log("Set height width ", SelectFrameHeight);
        }
        else {
            this.$SelectFrame.css({ 'display': 'none' });
        }

        $ModalBox.find("#CustomFile").css({ 'display': 'block' });
        
        $("#" + this.ImageGalaryId).modal("hide");
        $ModalBox.modal('show');
    }

    OpenGalary(object = null) {
        
        this.UpdateGalary("FromGalary");

        this.Configurate(object);

        $("#" + this.ModalImageId).modal('hide');
        $("#" + this.ImageGalaryId).modal("show");
        console.log(this.ImageGalaryId);

    }



    //в модальном окне id для preview = #PreviewImage
    // объект $OutImage отвечает за установку preview во внешнем элементе вне модального окна
    SetPreview(input) {
        //console.log(input.files);

        if (this.type != "New") {
            console.log("string--------");
            if (this.$OutImageBlock)
            {
                console.log("Preview from ImageGalary", this.$OutImageBlock);
                var url = this.type == "FromGalary" ? '/PersonalResources/Pictures/' + User + '/' + input : '/Community/Resources/Images/' + input;

                console.log(this);

                //запись во внешний блок если есть 
                if (this.BlockImageName == "Background") {
                    this.$OutImageBlock.css({ 'background': 'url(' + url + ')' })

                }else {
                    this.$OutImageBlock.attr('src', url);
                }

            }
        }
        else {
            console.log("Preview new file", input.files);



            if (input && input.files[0]) {
                var reader = new FileReader();

                var func = function (e) {
                    $('#' + this.ModalImageId).find('#PreviewImage').attr('src', e.target.result);//запись в preview в модальном окне если есть 

                    console.log(this.ModalImageId);
                    console.log($('#' + this.ModalImageId));

                    if (this.$OutImageBlock) {
                        //запись во внешний блок если есть 
                        if (this.BlockImageName == "Background") {
                            this.$OutImageBlock.css({ 'background': 'url(' + e.target.result + ')', })

                        } else {
                            this.$OutImageBlock.attr('src', e.target.result);
                        }
                    }
                }
                func = bindFunc(func, this);
                reader.onload = func;
                //article-img
                reader.readAsDataURL(input.files[0]);

            }
        }


    } //установка выбранной фото в блоки предпросмотра и финальный блок


    Update(param) {

        console.log("Update Image ", param);
        this.SetPreview(param);

        switch (this.BlockImageName) {
            case "CreateArticle":


                break;

            case "Background":
                console.log("set background")
                this.SetBackgroundinSendForm(param);
                break;


            default://для блоков персональной страницы
                this.SetPersonalBlock(param);
                break;
        }
    }

    //установка доп настроек фото 
    updateFileInfo(block) {

        this.ImageInfo = { left: block.style.left, top: block.style.top };

        switch (this.BlockImageName) {
            case "CreateArticle":


                break;

            default:
                if (!isEmpty(this.BlockImageName)) {
                    Global_SavePageForm[this.BlockImageName + "+settings"] = JSON.stringify(this.ImageInfo);
                }
                break;
        }
    }
    SetBackgroundinSendForm(param)
    {
        
        if (this.type == "New") param = param.files[0];

        Global_SavePageForm["background+image"] = this.type;
        Global_SavePageForm["background"] = param;
    }

    SetPersonalBlock(file) {

        if (this.type == "New") file = file.files[0];
        var str = this.BlockImageName + "+image";//тип image определяет фото 
        
        Global_SavePageForm[str] = this.type;
        Global_SavePageForm[this.BlockImageName] = file;

     
    }

    MoveStartImage() {
        if (this.$OutImageBlock) {
            this.$OutImageBlock.css({
                "margin-left": "-" + this.ImageInfo.left, "margin-top": "-" + this.ImageInfo.top
            });
        }


    }

    UpdateGalaryHtml(user) {
        var $ref = $("#Image--0_0");
        $ref.html("");
        var This = this;

        this.ImageGalary.forEach(function (item, i, arr) {
            var $block = $('<li><a href="#"><img src="http://placekitten.com/g/620/330" alt="" /></a></li>');
            var path = This.type == "FromCommunity" ? '/Community/Resources/Images/' + item : '/PersonalResources/Pictures/' + user + '/' + item;
            //console.log(path);

            $block.find("img").attr('src', path);


            var func = function (event) {
                console.log("Called SelectImage:", event.data.Item);
                this.SelectFromGalary(event.data.Item);
                ChooseElement(event.data.block);
            }
            func = bindFunc(func, This);
            
            $block.on('click', { Item: item, block: $block.find('img') }, func);
           // console.log("---Bind for item:", item);

            $ref.append($block);
        });
    }

    UpdateGalary(type) {

        this.setType(type);

        var user = User;
        var Update = function(data) {
            var o = JSON.parse(data);
            this.ImageGalary = o;
            this.UpdateGalaryHtml(user);
        }

        Update = bindFunc(Update, this);

        var _url = type == "FromCommunity" ? "/General/GetCommunityImageGalary" : "/General/GetImageGalary";
        console.log(_url);
        $.ajax({
            url: _url,
            type: 'POST',
            success: Update
        });
        
        
    }



    SelectFromGalary(FileName) {
        console.log("Choosed from ImageGalary = ", FileName);
        this.SelectedImageName = new String(FileName);

        this.Update(this.SelectedImageName);
    }



    
}