console.log("Modal control were loaded");
function OpenModal(id) {
    $ModalBox = $('#' + id );


    $ModalBox.modal('show');
}

function CloseModal(id) {
    $ModalBox = $('#' + id);


    $ModalBox.modal('hide');
}