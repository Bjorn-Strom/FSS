var path = require("path");

module.exports = {
  entry: "./tests/Tests.fsproj",
  output: {
    path: path.join(__dirname, "./public"),
    filename: "bundle.js",
  },
  devServer: {
    contentBase: "./public",
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
