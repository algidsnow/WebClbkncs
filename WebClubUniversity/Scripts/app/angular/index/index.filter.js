﻿(function () {
    angular.module('app')
        .filter('filterImagerUser', filterImagerUser);

    function filterImagerUser() {
        function inputUrlImg(urlImg) {
            if (!urlImg) {
                return  '~/Content/images/user.jpg'
            } else {
                let hasImg = urlImg.search('jpg' || 'jpeg' || 'png');
                if (hasImg > -1) {
                    let hasPathContent = urlImg.search('Content');
                    if (hasPathContent) {
                        urlImg = urlImg.replace('/Assets/images/', '');
                        return urlImg;
                    }
                    return urlImg
                }
                return '~/Content/images/user.jpg'
            }
        }
        return inputUrlImg;
    }
}());