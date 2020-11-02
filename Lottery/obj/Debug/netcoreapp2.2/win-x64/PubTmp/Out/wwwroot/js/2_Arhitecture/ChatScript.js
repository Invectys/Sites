
    var timer = new Date();


function web_send_msg()
{
    // Получение значений из элементов ввода.
    var text = $("#WebChatTextID").val();
    var name = UserName;

    // Очистка формы
    $("#WebChatTextID").val("");

    // Запишем время в момент отправки сообщения
    timer = new Date();
    if (text != "") {
        // Отправка сообщения в канал чата
        connection.invoke("SendMessage", text);
    }
   


}
    connection.on("ReceiveMessage", function (user, msg)
    {
        console.log(["msg", msg]);
    // Добавление полученного сообщения к списку сообщений.
    $("#WebChatFormForm").append("<p><b>"+HtmlEncode(user)+": </b>"+HtmlEncode(msg)+"</p>");
});




function HtmlEncode(s)
{
  var el = document.createElement("div");
    el.innerText = el.textContent = s;
    s = el.innerHTML;
    return s;
}


$('#WebChatTextID').on('keydown', function (e) {
    if (e.keyCode === 13) {
        e.preventDefault();
       
    }
});
