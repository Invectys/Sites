console.log("Modal load file were loaded");
class ModalLoadFileControl {

    constructor(ModalId) {

        this.ModalId = ModalId;
        this.FileGalaryId = this.ModalId + "-FileGalary";
        this.FileGalary = {};
        this.bLoadFileInModal = true;
        this.type = "";
        
    }
    setType(type) {
        this.type = type;
    }
    Configurate(options) {
        if (options != undefined) {
           
            this.SelectedFileName = options.SelectedFileName;
            this.BlockName = options.Block;
        }
       
       
        this.$FileInput = $("#" + this.ModalId).find("#CustomFile");

        var ChangeFile = function () {

            var inp = this.$FileInput[0];
            
            var file = inp.files[0];
            var str = file.name;
            console.log("выбран файл = ", str);


            this.Update(inp);
        };

        ChangeFile = bindFunc(ChangeFile, this);

        this.$FileInput.change(ChangeFile);
    }



    OpenModal() {
        console.log("-------------------------Open Load Modal box-------------------");
        console.log("Action:", this.BlockName);

        this.setType("New");

    
        var $ModalBox = $("#" + this.ModalId);
        var $ModalGalary = $("#" + this.FileGalaryId);
        


        if (this.bLoadFileInModal) {
            $ModalBox.find("#CustomFile").css({ 'display': 'block' }); 
        }
        else {
            $ModalBox.find("#CustomFile").css({ 'display': 'none' });
        }

        $ModalGalary.modal("hide");
        $ModalBox.modal('show');
    }

    OpenGalary(object = null) {

        

        var $ModalBox = $("#" + this.ModalId);
        var $ModalGalary = $("#" + this.FileGalaryId);

        this.UpdateGalary("FromGalary");

        this.Configurate(object);

        $ModalBox.modal('hide');
        $ModalGalary.modal("show");


    }

    Update(param)
    {
        console.log("Update File");
        

        switch (this.BlockImageName) {
            case "CreateArticle":


                break;

            case "Background":
                console.log("set background");
               
                break;


            default://для блоков персональной страницы
                this.SetPersonalBlock(param);
                break;
        }
       
    }


    UpdateGalaryHtml(user,Community) {
        var $ref = $("#Image--1_0");
        $ref.html("");
        var This = this;

        this.FileGalary.forEach(function (item, i, arr) {
            $block = $('<li><a href="#"><text src="http://placekitten.com/g/620/330" alt="" /></a></li>');
            $block.find("text").text(item);


            var func = function (event) {

                this.SelectFromGalary(event.data.Item);
                ChooseElement(event.data.block);
            }
            func = bindFunc(func, This);

            $block.on('click', { Item: item, block: $block[0] }, func);

            $ref.append($block);
        });
    }

    UpdateGalary(type) {
        this.setType(type);
        var user = User;
        var Update = function (data) {
            var o = JSON.parse(data);
            this.FileGalary = o;
            this.UpdateGalaryHtml(user);
        }

        Update = bindFunc(Update, this);

        var url_ = type == "FromCommunity" ? "/General/GetCommunityFileGalary": "/General/GetFileGalary";

        $.ajax({
            url: url_,
            type: 'POST',
            success: Update
        });
    }



    SelectFromGalary(FileName) {
        console.log("Choosed from ImageGalary = ", FileName);
        this.SelectedImageName = new String(FileName);

        this.Update(this.SelectedImageName);
    }


    SetPersonalBlock(param) {

        if (this.type == "New") param = param.files[0];
        var str = this.BlockName + "+file";

        Global_SavePageForm[str] = this.type;
        Global_SavePageForm[this.BlockName] = param;


        //Уведомление что нужно перезагрузить страницу
        if (this.BlockName.split('-')[0] == "html") {
            $('#' + this.BlockName).find("#Content").text("Save and Reload!");
        }
        

    }
}

