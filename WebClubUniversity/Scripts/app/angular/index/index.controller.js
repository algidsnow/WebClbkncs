(function () {
    angular.module('app')
        .controller('IndexController', IndexController);


    IndexController.$inject = ['$scope', 'IndexService'];

    function IndexController($scope, IndexService) {
        let membersSample = [
            {
                name: 'Phạm Thị Diệu Linh ',
                position: 'Chủ nhiệm CLB KNCS',
                UrlPresentMember: '/Content/images/user.jpg',
                intro: 'Trường CLB'
            },
            {
                name: 'Nguyễn Minh Hưng',
                position: 'Phó chủ nhiệm kiêm Trưởng ban Dự Án',
                UrlPresentMember: '/Content/images/user.jpg',
                intro: 'Trường CLB'
            },
            {
                name: 'Đỗ Mi Ni ',
                position: 'Phó chủ nhiệm ',
                UrlPresentMember: '/Content/images/user.jpg',
                intro: 'Trường CLB'
            },
            {
                name: 'Đặng Hồng Nhung ',
                position: 'Trưởng Ban Marketing MC',
                UrlPresentMember: '/Content/images/user.jpg',
                intro: 'Trường CLB'
            },
            {
                name: 'Nguyễn Công Minh ',
                position: 'Trưởng Ban Đối Ngoại ',
                UrlPresentMember: '/Content/images/user.jpg',
                intro: 'Trường CLB'
            },
            {
                name: 'Nguyễn Hữu An ',
                position: 'Trưởng Ban Văn Hóa',
                UrlPresentMember: '/Content/images/user.jpg',
                intro: 'Trường CLB'
            },
            {
                name: 'Võ Hoàng Lâm ',
                position: 'Trưởng Ban Sự kiện',
                UrlPresentMember: '/Content/images/user.jpg',
                intro: 'Trường CLB'
            }
        ]

        $scope.listPosts = () => {
            IndexService.listPosts().then((response) => {
                if (response && response.status === 200) {
                    $scope.listNews = response.data;
                } else {
                    $scope.listNews = [];
                }
            }).catch((err) => console.log(err));
        };
        $scope.listPosts();

        $scope.viewInfo = (NewsId) => {
            IndexService.detail({ id: NewsId }).then((response) => {
                if (response && response.status === 200) {
                    $scope.info = response.data;
                } else {
                    $scope.info = {};
                }
            })
        }

        $scope.ListMember = () => {
            IndexService.ListMember().then((response) => {
                console.log(response)
                if (response && response.status === 200) {
                    $scope.members = $scope.members = response.data && response.data.length ? response.data : membersSample;
                } else {
                    $scope.members = [];
                }
            }).catch((err) => console.log(err));
        };
        $scope.ListMember();
    }
}())