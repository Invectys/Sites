console.log("Modal Video loaded");
class ModalChooseVideoControl {

    constructor(ModalId) {

        this.ModalId = ModalId;
        this.bLoadFileInModal = true;
       
        
    }

    Configurate(options) {
        if (options != undefined) {
           
            
            this.BlockName = options.Block;
        }
       
        var $inp = $("#" + this.ModalId).find("#CustomPath");
        var f = function Change(e) {
            this.Value = e.data.inp.val();
            if (this.OnVideoUrlChange != undefined) {
                this.OnVideoUrlChange(this.Value, this.BlockName);
            }
        }
        f = bindFunc(f, this);
        $inp.on("change", { inp: $inp},f);
    }

    clear() {
        this.OnVideoUrlChange = undefined;
        this.BlockName = null;
    }
    OpenModal(options) {
        this.Configurate(options);



        $("#" + this.ModalId).modal('show');
    }

    


    
}

