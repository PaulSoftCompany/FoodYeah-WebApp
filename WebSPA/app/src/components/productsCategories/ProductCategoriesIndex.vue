<template>
  <div>
    <h1 class="title">Módulo de categorías</h1>
    <h2 class="subtitle">Desde aquí puede gestionar las categorías de productos.</h2>

    <Loader v-if="isLoading" />
    <template v-else>
      <div class="field has-text-right">
        <router-link to="/productcategories/create">Agregar nueva categoría</router-link>
      </div>
      <table class="table is-striped is-fullwidth">
        <thead>
          <th>Id</th>
          <th>Nombre</th>
          <th >Descripcion</th>
          <th style="width:150px;"></th>
        </thead>
        <tbody>
          <tr v-for="item in collection.items" :key="item.id">
            <td>{{item.product_CategoryId}}</td> 
            <td>{{item.product_CategoryName}}</td> 
            <td>{{item.product_CategoryDescription}}</td>
            <td class="has-text-centered">
              <router-link :to="`/productcategories/${item.product_CategoryId}/edit`">Editar</router-link>-
              <a @click="remove(item.product_CategoryId)">Eliminar</a>
            </td>
          </tr>
        </tbody>
      </table>
      <Pager :paging="p => getAll(p)" :page="collection.page" :pages="collection.pages" />
    </template>
  </div>
</template>

<script src="./ProductCategoriesIndex.js"></script>