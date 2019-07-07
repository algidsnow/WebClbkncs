(function () {
    angular.module('app')
        .controller('NewsController', NewsController);


    NewsController.$inject = ['$scope', '$compile', 'NewsService'];

    function NewsController($scope, $compile, NewsService) {
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

        $scope.list = () => {
            NewsService.list().then((response) => {
                if (response && response.status === 200) {
                    $scope.listNews = response.data;
                } else {
                    $scope.listNews = [];
                }
            }).catch((err) => console.log(err));
        };
        $scope.list();

        $scope.viewInfo = (NewsId) => {
            NewsService.detail({ id: NewsId }).then((response) => {
                console.log(response)
                if (response && response.status === 200) {
                    $scope.info = response.data;
                    let content = $compile($scope.info.Content)($scope);
                    $('#detail-content').append(content);
                    
                } else {
                    $scope.info = {};
                }
            })
        }
        
    }
}())