<script lang="ts">
import { RouterLink, RouterView } from 'vue-router'

export default {
  components: { RouterLink, RouterView },
  data(vm) {
    return {
      user: null
    }
  },
  mounted() {
    this.$chatHub.on('user', (user) => {
      console.log(user)
      this.user = user
    })
  },
  unmounted() {
    this.$chatHub.off('user')
  }
}
</script>

<template>
  <header>
    <div class="wrapper menu">
      <nav>
        <RouterLink to="/" class="menu-item">Home</RouterLink>
        <RouterLink to="/about" class="menu-item">About</RouterLink>
      </nav>
    </div>
  </header>
  <div>ID: {{ (user as any)?.id }} Username: {{ (user as any)?.username }}</div>
  <RouterView />
</template>

<style scoped>
.menu-item {
  margin-right: 10px;
}
.menu {
  margin-bottom: 40px;
}
</style>
