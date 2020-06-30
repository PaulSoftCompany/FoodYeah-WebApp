<template>
  <div>
    <h1 class="title">FoodYeah</h1>
    <h2 class="subtitle">Una pagina web dedicada a la creación ordenes de comida en tu comedor favorito!</h2>

    <p>Bienvenido <b>{{user.lastName}}, {{user.name}}</b>.</p>
  </div>
</template>

<script>
export default {
  name: "Default",
  data() {
    return {
      user: this.$store.state.user
    }
  }
};
</script>
