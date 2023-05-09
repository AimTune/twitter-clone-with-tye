<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  data() {
    return {
      pongs: new Array<string>(),
      interval: 0
    }
  },
  mounted() {
    this.interval = window.setInterval(() => {
      this.$chatHub.invoke('Ping')
    }, 1000)

    this.$chatHub.on('pong', (pong) => {
      this.pongs.push(pong)
      const pongDiv = this.$refs['pongsDiv'] as HTMLElement
      pongDiv.scrollTop = pongDiv.scrollHeight
    })
  },
  unmounted() {
    window.clearInterval(this.interval)

    this.$chatHub.off('pong')
  }
})
</script>

<template>
  <main>
    <div ref="pongsDiv">
      <ul>
        <li v-for="pong in pongs" :key="pong">{{ pong }}</li>
      </ul>
    </div>
  </main>
</template>

<style scoped>
div {
  max-height: 300px;
  max-width: 400px;
  overflow-y: scroll;
}
</style>
