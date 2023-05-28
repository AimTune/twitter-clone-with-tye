/// <reference types="vite/client" />
import { HubConnection } from '@microsoft/signalr'
import KeyCloak from 'keycloak-js'

declare module 'vue' {
  interface ComponentCustomProperties {
    $chatHub: HubConnection
    $keycloak: KeyCloak
  }
}
export {} // Important! See note.
