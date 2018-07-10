import { writeFileSync } from 'fs';
import { glob } from 'glob';

class CoreBuildRouter {

    constructor() { }

    generateJSONRoutes() {
        console.log('Generating ng-routes.js');
        let routes = [];
        glob('src/app/features/**/*.routing.ts', function (err, files) {
            console.log('Files found: ' + files.length);
            console.log(files);
            files.forEach(fileName => {
                const file = require('../' + fileName);
                routes = routes.concat(file.publicRoutes);
            });
            const js = 'var ngRegisteredRoutes = ' + JSON.stringify(routes) + ';';
            writeFileSync('src/assets/js/ng-routes.js', js);
        });
    }
}
new CoreBuildRouter().generateJSONRoutes();
