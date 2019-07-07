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
                console.log(response)
                if (response && response.status === 200) {
                    $scope.listNews = response.data;
                } else {
                    $scope.listNews = [];
                }
            }).catch((err) => console.log(err));
        };
        $scope.listPosts();

        $scope.viewInfo = (NewsId) => {
            console.log(NewsId)
            //IndexService.detail({ id: NewsId }).then((response) => {
            //    console.log(response)
            //    const { status } = response || {};
            //    if (status === 200) {
            //        $scope.info = response.data;
            //        const content = $compile($scope.info.Content)($scope);
            //        console.log(content)
            //        $('#detail-content').empty().append(content);
            //    } else {
            //        $scope.info = {};
            //    }
            //});
        };

        $scope.ListMember = () => {
            IndexService.ListMember().then((response) => {
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