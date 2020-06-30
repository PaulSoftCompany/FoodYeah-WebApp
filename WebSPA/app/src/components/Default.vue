<template>
  <div>
    <div class="imgSize3">
      <img src="../assets/logo.png" />
    </div>
    <br>
    <div>
      <h1 class="title">FoodYeah</h1>
      <h2
        class="subtitle"
      >Un servidor web dedicada a la creación de ordenes de comida de tu comedor favorito!</h2>

      <p>
        Bienvenido
        <b>{{user.lastName}}, {{user.name}}</b>.
      </p>
    </div>
  </div>
</template>

<script>
export default {
  name: "Default",
  data() {
    return {
      user: this.$store.state.user
    };
  }
};
</script>
