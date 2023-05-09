<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
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
