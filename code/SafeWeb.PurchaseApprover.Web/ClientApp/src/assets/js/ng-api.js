'use strict';

var ngAPI = function () {
    const _urlPath = 'v1/';

    return {
        checkRouter: checkRouter,
        isReload: true,
        ngUrlPath: _urlPath
    };

    function checkRouter(options) {
        if (ngRegisteredRoutes) {
            for (var i = 0; i < ngRegisteredRoutes.length; i++) {
                var url = options.url.replace(_urlPath, "");
                var indexOf = ngRegisteredRoutes[i].route.indexOf(':params');
                if (indexOf >= 0) {//tratamento de parametros aceita qualquer coisa dentro deles
                    var regex = ngRegisteredRoutes[i].route.split('/').join('\\/').split(':params').join('([^\\/]*)');
                    var re = new RegExp(regex, 'i');
                    var match = options.url.match(re);
                    if (match !== null) {
                        options.isNgMenu = true;
                        options.title = ngRegisteredRoutes[i].title;
                        options.url = url;
                        break;
                    }
                } else if (url === ngRegisteredRoutes[i].route) {
                    options.isNgMenu = true; // atualizacao
                    options.title = ngRegisteredRoutes[i].title;
                    options.url = ngRegisteredRoutes[i].route;
                    break;
                }
            }
        }
        return options;
    };
}();
