(function() {
    angular.module('app')
        .service('NewsService', NewsService);
    NewsService.$inject = ['$http'];

    function NewsService($http) {
        this.list = function() {
            return $http.get('/Index/Index').then((response) => {
                return response;
            }).catch((err) => { return err; });
        };

    }
}());