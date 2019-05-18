(function() {
    angular.module('app')
        .controller('AboutController', AboutController);


    AboutController.$inject = ['$scope'];

    function AboutController($scope) {
        $scope.data = function () {
            $scope.about =
                {
                    title: 'Về CLB',
                    content: `CLB là tổ chức xã hội tự nguyện của các nhà báo chuyên nghiệp, các nhà hoạt động trong lĩnh vực truyền thông số; các chuyên gia, nhà nghiên cứu chính sách truyền thông; các doanh nhân hoạt động trong lĩnh vực truyền thông số cùng nhau “Kết nối và lan tỏa sức mạnh tri thức”.

Nơi kết nối các nhà hoạch định chính sách, các nhà nghiên cứu, các doanh nhân với giới truyền thông, tăng cường hiểu biết lẫn nhau, hợp tác vì sự phát triển của đất nước; Tạo diễn đàn trao đổi về nghiệp vụ, đạo đức truyền thông nhằm nâng cao nhận thức và trình độ cho các thành viên; Phát triển mạng lưới truyền thông số, tạo dựng môi trường hoạt động thuận lợi cho đội ngũ những người làm công tác truyền thông số.`
                }

        };
        $scope.data();
    }
}())