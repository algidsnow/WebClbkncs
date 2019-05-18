(function () {
    angular.module('app')
        .controller('NewsController', NewsController);


    NewsController.$inject = ['$scope'];

    function NewsController($scope) {
        $scope.data = function () {
            $scope.newsAction = [
                {

                    title: 'Sinh hoat1',
                    content: `content1`,
                    imgUrl: '/Content/images/img1.jpg',
                    date: ''
                },
                {

                    title: 'Sinh hoat1',
                    content: `content2`,
                    imgUrl: '/Content/images/img3.jpg',
                    date: ''
                },
                {

                    title: 'Sinh hoat 3',
                    content: `content 3`,
                    imgUrl: '/Content/images/img3.jpg',
                    date: ''
                },
            ]

            $scope.newsGood = [
                {

                    title: 'Bai viet 1',
                    content: `Noi dung bai viet 1`,
                    imgUrl: '/Content/images/img4.jpg',
                    date: ''
                },
                {
                    title: 'Bai viet 2',
                    content: `Noi dung bai viet 2`,
                    imgUrl: '/Content/images/img5.jpg',
                    date: ''
                },

                {
                    title: 'Bai viet 3',
                    content: `Noi dung bai viet 3`,
                    imgUrl: '/Content/images/img6.jpg',
                    date: ''
                }
            ]

        };
        $scope.data();
    }
}())