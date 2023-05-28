import { HubConnectionBuilder } from '@microsoft/signalr'

import type { App } from 'vue'

interface SignalROptions {
  baseUrl: string
}

export default {
  install: (app: App, options: SignalROptions) => {
    app.config.globalProperties.$chatHub = new HubConnectionBuilder()
      .withUrl(options.baseUrl, {
        accessTokenFactory: () => `${app.config.globalProperties.$keycloak.token}`
      })
      .withAutomaticReconnect()
      .build()
  }
}
