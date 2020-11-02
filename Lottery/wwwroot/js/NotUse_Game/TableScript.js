
function updatePositions(s) {
    $('#' + s + ' tr:not(:first)').each(function (key) {
        // Порядковый номер
        //console.log(key);

       // console.log($(this));
        $(this).find('th').text(key + 1);
    });
}



class TableControl {
    constructor(tableId) {
        this.tableId = tableId;
    } 

   

    Add(login,rate) {
        var body = $('#' + this.tableId + ' tbody');
        var tr = $('<tr>');
        tr.attr('id', 'my_id');
        var th = $('<th>');
        th.attr('scope', 'row');
        var ind = $('#' + this.tableId + ' tr').length;
        th.text(ind);
        var td = $('<td>');

        td.text(login);
        tr.append(th);
        tr.append(td);

        var td1 = $('<td>');
        
       
        var img = $('<img>');
        img.attr("src", "/resources/Cat_monet64.png");
        img.css({ 'height': '50px', 'width': '50px' });
        img.appendTo(td1);
        td1.append(rate);
        tr.append(td1);
       

        body.append(tr);
    }

    Remove(login) {
        var body = $('#' + this.tableId + ' tbody');
        var $el = $('#' + this.tableId + ' td:contains(' + login + ') ');
        $el.parent().remove();
        updatePositions(this.tableId)
    }
    Remove(index) {
        $('#' + this.tableId + ' tr').eq(index).remove();
        updatePositions(this.tableId);
    }
    RemoveAll() {
        $('#' + this.tableId + ' tbody').text("");
    }

    getCash() {
        var len = $('#' + this.tableId + ' tr').length - 1;
        console.log(len);
        var Cash = len * Rate;
        return Cash;
    }
    getLenght() {
        var len = $('#' + this.tableId + ' tr').length -1 ;
        return len;
    }
}