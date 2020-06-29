<template>
  <div>
    <h1 class="title">Pago de Orden</h1>
    <h2 class="subtitle">Selecciona tu tarjeta para pagar</h2>

    <Loader v-if="isLoading" />
    <template v-else>
      <div class="field has-text-right">
        <router-link to="/cards/create">Agregar nueva tarjeta</router-link>
      </div>
      <table class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
        <thead>
          <th># de tarjeta</th>
          <th>Tipo de tarjeta</th>
          <th>Dinero</th>
        </thead>
        <tbody>
          <tr v-for="item in collection.items" :key="item.cardId">
            <td>{{item.cardNumber}}</td>
            <td>{{item.cardType}}</td>
            <td>{{item.money}}</td>
            <td class="has-text-centered">
              <router-link :to="`/cards/${item.cardId}/edit`">Pagar</router-link>-
              <a @click="pay(item.cardId)">Pagar</a>
            </td>
          </tr>
        </tbody>
      </table>
      <Pager :paging="p => getAll(p)" :page="collection.page" :pages="collection.pages" />
    </template>
  </div>
</template>

<script src="./PayOrder.js"></script>