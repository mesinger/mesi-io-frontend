const path = require("path");
const CopyPlugin = require("copy-webpack-plugin");

module.exports = {
  plugins: [
    new CopyPlugin({
      patterns: [
        { from: "./src/assets", to: "../wwwroot/assets"},
      ]
    })
  ],
  entry: {
    main: ["./src/scripts/main.ts", "./src/styles/main.scss"],
  },
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: "ts-loader",
        exclude: /node_modules/,
      },
      {
        test: /\.s[ac]ss$/i,
        use: [
          {
            loader: 'file-loader',
            options: {
              name: '[name].css',
              outputPath: 'styles'
            }
          },
          {
            loader: 'extract-loader'
          },
          {
            loader: 'css-loader'
          },
          {
            loader: 'postcss-loader'
          },
          {
            loader: 'sass-loader'
          },
        ]
      },
      
    ],
  },
  resolve: {
    extensions: [".tsx", ".ts", ".js"],
  },
  output: {
    filename: "scripts/site.js",
    path: path.resolve(__dirname, "../wwwroot"),
  },
};
