var table = document.getElementById('table');
table.addEventListener("click", function (e) {
    // e.target was the clicked element
    if (e.target && e.target.matches(".js-add-to-panier")) {
        updatepanier(e.target.dataset.codeMorceau);
    }
});

function updatepanier(codeItem) {

    console.log(codeItem);

    $.ajax({
        type: 'POST',
        url: 'http://localhost:1428/panier/Addtopanier',
        data: '152',
        success: function (data, response) {
            console.log(data)
            alert('Data Saved: ' + data + response);
        }
    });

}

