var path = require('path');
var webpack = require('webpack');

module.exports = {
  context: __dirname,
  entry: {
    javascript: './jsx/IndexComponent.jsx'
  },
  output: {
      path: path.resolve('../js/'),
      filename: 'reactBundle.js'
    },
  module: {    
    preLoaders: [
        {
            test: /\.jsx?$/,
            exclude: /(node_modules|bower_components)/,
            loader: 'source-map'
        }
    ],
    loaders: [
      {
        test: /\.jsx?$/,
        loader: 'babel-loader',
        exclude: /node_modules/,
        query: {
          presets: ['es2015', 'stage-0', 'react']
        }
      },
      {
        test: /\.(jpg|png)$/,
        loader: 'url-loader?limit=25000',
      }
    ]
  },
};
