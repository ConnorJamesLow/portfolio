const path = require('path');

module.exports = function (env, options) {
    console.log(options.mode, 'bundle building.')
    return {
        entry: './wwwsrc/index.ts',
        module: {
            rules: [
                {
                    test: /\.tsx?$/,
                    use: {
                        loader: 'ts-loader',
                        options: {
                            // configFile: 'tsconfig.webpack.json'
                        }
                    },
                    exclude: /node_modules/,
                },
            ]
        },
        resolve: {
            extensions: ['.ts', '.tsx', '.js'],
        },
        output: {
            filename: `index.js`,
            path: path.resolve(__dirname, `wwwroot/dist/js`),
            library: {
                name: 'lib',
                type: 'window',
                export: 'default',
            },
        },
        optimization: {
            usedExports: true,
        },
    };
}