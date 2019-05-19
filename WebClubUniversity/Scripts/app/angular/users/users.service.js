(function() {
    angular.module('app')
        .service('UsersService', UsersService);
    UsersService.$inject = ['$http'];

    function UsersService($http) {
        this.ListMember = function () {
            return $http.get('/Members/ListMember').then((response) => {
                return response;
            }).catch((err) => { return err; });
        };

    }
}());