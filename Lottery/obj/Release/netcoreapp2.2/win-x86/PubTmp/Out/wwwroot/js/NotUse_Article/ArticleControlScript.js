function Share(block, ind,url) {

    var data = { ind: ind };



    $.ajax({
        type: "POST",
        data: data,
        url: url,


        success: function (data) {
            alert("article shared ");
           // console.log($(block).parent(".article"));
            $(block).parent(".article").remove();
        },
        error: function (data) {
            alert("Server Error");
        }
    });
}

function Delete(block, ind,url,type) {

    var data = { ind: ind, where: type };



    $.ajax({
        type: "POST",
        data: data,
        url: url,


        success: function (data) {

           // console.log($(block).parent(".article").prev(".article"));
            $(block).parent(".article").remove();
        },
        error: function (data) {
            alert("Server Error");
        }
    });
}