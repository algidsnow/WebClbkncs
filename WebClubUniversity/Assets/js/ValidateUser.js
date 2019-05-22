function checkValid() {
        var item = document.getElementsByClassName('form-control1');
        var item1 = document.getElementsByClassName('check-input');
        var pass = document.getElementById("pass");
        var item2 = document.getElementById('check-input1')
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
    if (pass.value.length < 6 && pass.value.length !=0) {
            pass.style.border = '2px solid red';
            item2.style.display = 'block';
            valid = false;
        }
        return valid;
    }