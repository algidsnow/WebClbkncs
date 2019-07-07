(function () {
    angular.module('app')
        .filter('filterUrlImg', filterUrlImg);

    function filterUrlImg() {
        function inputUrlImg(urlImg) {

            if (!urlImg) {
                return  '/Content/images/img1.jpg'
            } else {
                let hasImg = urlImg.search('jpg' || 'jpeg' || 'png');
                if (hasImg > -1) {
                    return urlImg
                }
                return '/Content/images/img1.jpg'
            }
        }
        return inputUrlImg;
    }
}());