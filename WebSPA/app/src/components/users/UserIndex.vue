<template>
  <div>
    <h1 class="title">Módulo de usuarios</h1>
    <h2 class="subtitle">Desde aquí puede gestionar sus usuarios.</h2>

    <Loader v-if="isLoading" />
    <template v-else>
      <table class="table is-striped is-fullwidth">
        <thead>
          <th>Nombre</th>
          <th>Categoria</th>
          <!-- <th style="width:100px;">Admin</th>
          <th style="width:100px;">User</th> -->
        </thead>
        <tbody>
          <tr v-for="item in collection.items" :key="item.CustomerId">
            <td>{{item.customerName}}</td>
            <td>{{item.customer_Category.customer_CategoryName}}</td>
          </tr>
        </tbody>
      </table>
      <Pager :paging="p => getAll(p)" :page="collection.page" :pages="collection.pages" />
    </template>
  </div>
</template>

<script src="./UserIndex.js"></script>