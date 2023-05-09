/// <reference types="vite/client" />
import { HubConnection } from '@microsoft/signalr'

declare module 'vue' {
  interface ComponentCustomProperties {
    $chatHub: HubConnection
  }
}
export {} // Important! See note.
