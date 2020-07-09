var path = require("path");

module.exports = {
  entry: "./tests/Tests.fsproj",
  output: {
    path: path.join(__dirname, "./public-tests"),
    filename: "bundle.js",
  },
  devServer: {
    contentBase: "./public-tests",
    port: 8080,
  },
  module: {
    rules: [
      {
        test: /\.fs(x|proj)?$/,
        use: "fable-loader",
      },
    ],
  },
};
