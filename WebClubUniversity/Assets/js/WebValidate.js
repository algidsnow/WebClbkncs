function checkValid() {
    var item = document.getElementsByClassName('form-control1');
    var item1 = document.getElementsByClassName('check-input');
    var valid = true;
    for (var i = 0; i < item.length; i++) {
        if (item[i].value == "") {
            item[i].style.border = '2px solid red';
            item1[i].style.display = 'block';
            valid = false;
        }
        if (item[i].value != "") {
            item[i].style.border = '1px solid #ccc';
            item1[i].style.display = 'none';

        }
    }
    return valid;
}
