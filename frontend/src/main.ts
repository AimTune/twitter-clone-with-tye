import { createApp } from 'vue'
import { createPinia } from 'pinia'
import signalR from './signalR'
import App from './App.vue'
import router from './router'

const app = createApp(App)
app.use(signalR, {
  baseUrl: `${process.env['CONNECTIONSTRINGS__CHAT-SERVER']}/chat`
})
app.config.globalProperties.$chatHub.on('user', (user) => {
  window.console.log(user)
})
app.config.globalProperties.$chatHub.start()
app.use(createPinia())
app.use(router)

app.mount('#app')
