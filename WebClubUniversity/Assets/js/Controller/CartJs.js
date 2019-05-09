var cart = {
    init: function () {
        cart.regEvents();
        },
        regEvents: function () {
        $('#btnTiepTuc').off('click').on('click', function () {

            window.location.href = "/";

        });
    }
}
    cart.init();

