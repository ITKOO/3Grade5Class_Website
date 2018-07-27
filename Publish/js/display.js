var materialDivStyle = document.getElementById('materialDiv');
var materialEditDiv = document.getElementById('materialEditDiv');
var modalBackground = document.getElementById('modal-background');

function viewmaterialDiv() {
    materialDivStyle.style.display = "block"

    modalBackground.style.display = "inline-block"
}

function viewmaterialEditDiv() {
    materialEditDiv.style.display = "block"

    modalBackground.style.display = "inline-block"
}


function cancel() {
    materialDivStyle.style.display = "none"
    materialEditDiv.style.display = "none"
    modalBackground.style.display = "none"

}