import { createApp } from 'vue'
import { createPinia } from 'pinia'
import signalR from './signalR'
import KeyCloak from 'keycloak-js'
import App from './App.vue'
import router from './router'

const app = createApp(App)
app.use(signalR, {
  baseUrl: `${process.env['CONNECTIONSTRINGS__CHAT-SERVER']}/chat`
})
app.config.globalProperties.$chatHub.on('user', (user) => {
  window.console.log(user)
})

const initOptions = {
  realm: 'master',
  url: process.env['CONNECTIONSTRINGS__AUTH-SERVER'],
  clientId: 'frontend'
}
const keycloak = new KeyCloak(initOptions)

app.config.globalProperties.$keycloak = keycloak

app.use(createPinia())
app.use(router)

keycloak
  .init({
    onLoad: 'login-required'
  })
  .then(() => {
    app.mount('#app')
    app.config.globalProperties.$chatHub.start()
  })

keycloak.onTokenExpired = () => {
  console.log('token expired', keycloak.token)
  app.config.globalProperties.$chatHub.stop()

  keycloak
    .updateToken(30 * 60)
    .then(() => {
      console.log('successfully get a new token', keycloak.token)
      app.config.globalProperties.$chatHub.start()
    })
    .catch(() => {
      keycloak.login()
    })
}
