



$Title = $("#Title");
$Information = $("#Information");

$TextArea_Title = $("#TextArea_Title");
$TextArea_Information = $("#TextArea_Information");

var TitleInput = new InputField($Title, $TextArea_Title);
var InformationInput = new InputField($Information, $TextArea_Information);


var ArticleData = { PostWeekDelay : "0" }



function ChoosePostWeek(block) 
{
    if(block.value>100)
     {
        ArticleData.PostWeekDelay = 100;
     }
     else
     {
        ArticleData.PostWeekDelay = block.value;

     }
   
}



function CreateArticle() {

    $("#JSONImageData").val(JSON.stringify(ImageInfo));
    $("#JSONArticleData").val(JSON.stringify(ArticleData));

    DisplayBlock($TextArea_Title);
    DisplayBlock($TextArea_Information);
    

    document.getElementById("Submit").click();

    DisplayNone($TextArea_Title);
    DisplayNone($TextArea_Information);
    
}


function OnSelectDelay() {
    var n = document.getElementById("DelayOption").options.selectedIndex;
    console.log(n);
    ArticleData.PostWeekDelay = n;

    document.getElementById("ResultPostWeek").innerHTML =  "" + (NowWeek + n);
   
}

OnSelectDelay();