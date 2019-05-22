(function() {
    angular.module('app')
        .service('IndexService', IndexService);
    IndexService.$inject = ['$http'];

    function IndexService($http) {
        this.listPosts = function() {
            return $http.get('/Index/ListNews').then((response) => {
                return response;
            }).catch((err) => { return err; });
        };

        this.detail = function (data) {
            return $http.get('/Index/Detail', { params: data }).then((response) => {
                return response;
            }).catch((err) => { return err; });
        };
        this.ListMember = function () {
            return $http.get('/Members/ListMember').then((response) => {
                return response;
            }).catch((err) => { return err; });
        };

       

    }
}());