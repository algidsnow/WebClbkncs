(function() {
    angular.module('app')
        .service('NewsService', NewsService);
    NewsService.$inject = ['$http'];

    function NewsService($http) {
        this.list = function() {
            return $http.get('/Index/ListNews').then((response) => {
                return response;
            }).catch((err) => { return err; });
        };

        this.detail = function (data) {
            return $http.get('/Index/Detail', {params: data}).then((response) => {
                return response;
            }).catch((err) => { return err; });
        };

    }
}());