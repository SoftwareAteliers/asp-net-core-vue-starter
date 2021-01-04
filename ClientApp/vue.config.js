module.exports = {
  configureWebpack: {
    devtool: 'source-map'
  },
  transpileDependencies: ['vuetify'],
  devServer: {
    progress: false
  }
}
