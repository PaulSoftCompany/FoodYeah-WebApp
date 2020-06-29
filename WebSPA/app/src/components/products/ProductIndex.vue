<template>
  <div>
    <h1 class="title">Módulo de productos</h1>
    <h2 class="subtitle">Desde aquí puede gestionar sus productos.</h2>

    <Loader v-if="isLoading" />
    <template v-else>
      <div class="field has-text-right" v-if="user.roles.includes('ADMIN')">
        <router-link to="/products/create">Agregar nuevo producto</router-link>
      </div>
      <table class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
        <thead>
          <th>Nombre</th>
          <th>Stock</th>
          <th>Categoria</th>
          <th>Precio</th>
          <th>Dia de venta</th>
          <th>Ingredientes</th>
          <th style="width:150px;"></th>
        </thead>
        <tbody>
          <tr v-for="item in collection.items" :key="item.productId">
            <td>{{item.productName}}</td>
            <td>{{item.stock}}</td>
            <td>{{item.product_Category.product_CategoryName}}</td>
            <td>S/. {{item.productPrice}}</td>
             <td> {{item.sellDay}}</td>
              <td> {{item.ingredients.join(',')}}</td>
            <td class="has-text-centered" v-if="user.roles.includes('ADMIN')">
              <router-link :to="`/products/${item.productId}/edit`">Editar</router-link>-
              <a @click="remove(item.productId)">Eliminar</a>
            </td>
          </tr>
        </tbody>
      </table>
      <Pager :paging="p => getAll(p)" :page="collection.page" :pages="collection.pages" />
    </template>
  </div>
</template>

<script src="./ProductIndex.js"></script>