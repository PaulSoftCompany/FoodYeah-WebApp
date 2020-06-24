<template>
  <div class="hero-head">
    <nav class="navbar">
      <div class="container">
        <div class="navbar-brand">
          <a class="navbar-item">
            <img src="../assets/logo.png" alt="logo" />
          </a>
          <span class="navbar-burger burger" data-target="navbarMenuHeroC">
            <span></span>
            <span></span>
            <span></span>
          </span>
        </div>
        <div id="navbarMenuHeroC" class="navbar-menu">
          <div class="navbar-end">
             <router-link :class="{'is-active': $route.name === 'default'}" class="navbar-item" to="/">Inicio</router-link>
            <router-link :class="{'is-active': $route.path.startsWith('/orders')}" class="navbar-item" to="/orders">Órdenes</router-link>
            <router-link :class="{'is-active': $route.path.startsWith('/products')}" class="navbar-item" to="/products">Productos</router-link>
            <router-link :class="{'is-active': $route.path.startsWith('/users')}" v-if="user.roles.includes('Admin')" class="navbar-item" to="/users">Usuarios</router-link>
            <router-link :class="{'is-active': $route.path.startsWith('/productcategories')}" v-if="user.roles.includes('Admin')" class="navbar-item" to="/productcategories">Products Categories</router-link>
            <span class="navbar-item">
              <a  @click="logout"  class="button is-danger is-inverted">
                <span class="icon">
                  <i class="fas fa-sign-out-alt"></i>
                </span>
                <span>Desconectarse</span>
              </a>
            </span>
          </div>
        </div>
      </div>
    </nav>
  </div>
</template>

<script>
export default {
  name: "Header",
  data() {
    return {
      user: this.$store.state.user
    }
  },
  methods: {
    logout() {
      localStorage.removeItem("access_token");
      this.$parent.isLoggedIn = false;
    }
  }
  
};
</script>