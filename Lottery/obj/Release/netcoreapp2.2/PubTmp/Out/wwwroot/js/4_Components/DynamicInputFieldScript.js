//               <input id="TextArea_Title" asp-for="Title" type="text" class="form-control" style="display:none" />


/*              <textarea cols="50" rows="10" id="TextArea_Information" asp-for="Information"
                  style="resize:none;display:none;overflow:hidden" class="form-control"
                  placeholder="min information" >
                </textarea>                                                    */
//<input id="input-001" type="text" class="form-control" style="display:none" />

console.log("Dynamic input field  methodes were loaded");
var touchtime = 0;
class InputField {

    constructor($ResultField_,
        $TextArea_ResultField_,
        ResultFieldSettings = undefined,
        TextArea_ResultFieldSettings = undefined,
        options = undefined
    ) {
        //установка полей 
        this.$ResultField = $ResultField_;
        this.$TextArea_ResultField = $TextArea_ResultField_;
        this.ResultFieldSettings = ResultFieldSettings;
        this.TextArea_ResultFieldSettings = TextArea_ResultFieldSettings;
        this.Value = "";
        this.bEdit = false;

        //set class options
        if (options) {
            if (options.bSupportHTML != undefined)
                this.bSupportHTML = options.bSupportHTML;
            else this.bSupportHTML = false;
        }
       

        //console.log("support", this.bSupportHTML);
        var save = function (event) {
            var o = this;
            //сохраняем при рандомном клике на чем-нибудь
            
            if (/*(event.which == 1) && */o.bEdit) {

                var $choosed = $(event.target);

                

                //сохранение 
                if (!$choosed.is(o.$TextArea_ResultField) && !$choosed.is(o.$ResultField))
                    o.Save();
            }
        }
        var edit = function (event) {

            let o = this;

            
            o.Edit();
        }

        save = bindFunc(save, this);
        edit = bindFunc(edit, this);

        //установка события 
        $(document).bind("mousedown", save);
        $(document).bind("touchstart", save);
        this.$ResultField.on("dblclick", edit);
        this.$ResultField.on("click", function (e) {
            
            
            if (touchtime == 0) {
                // set first click
                touchtime = new Date().getTime();
            } else {
                // compare first click to this click and see if they occurred within double click threshold
                if (((new Date().getTime()) - touchtime) < 800) {
                    // double click occurred
                    edit(e);
                    //alert("double clicked");
                    touchtime = 0;
                } else {
                    // not a double click so set as a new first click
                    
                    touchtime = new Date().getTime();
                    
                }
            }
        });


        if (this.TextArea_ResultFieldSettings != undefined) {

            //Block Enter
            if ('blockEnter' in this.TextArea_ResultFieldSettings)
                if (this.TextArea_ResultFieldSettings.blockEnter)
                    Block_key(this.$TextArea_ResultField, 13); 
        }
       
        
        
    }
    
    Save() {
        

        var $field = this.$ResultField;
        var $input = this.$TextArea_ResultField;

        //console.log("Save Dynamic input field");

        var str = $input.val();
        if (isEmpty(str)) str = "click";
        if (this.bSupportHTML ) {
            $field.html(str);
        } else {
            $field.text(str);
        }
       
        this.Value = str;


        DisplayBlock($field);
        DisplayNone($input);

        this.bEdit = false;

        //delegate
        if (this.OnSaveValue != undefined) {
            this.OnSaveValue();
        }
    }

   
    Edit() {
        var $field = this.$ResultField;
        var $input = this.$TextArea_ResultField;

        //console.log("Edit Dynamic input field");

        DisplayNone($field);
        DisplayBlock($input);

        var str = "";
        if (this.bSupportHTML) {
            str = $field.html();
        }
        else {
            str = $field.text();
        }
       
        $input.val(str);

        this.bEdit = true;

    }
}



