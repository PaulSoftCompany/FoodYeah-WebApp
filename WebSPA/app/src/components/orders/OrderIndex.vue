<template>
  <div>
    <h1 class="title">Módulo de órdenes</h1>
    <h2 class="subtitle">Desde aquí puede gestionar sus órdenes.</h2>

    <Loader v-if="isLoading" />
    <template v-else>
      <div class="field has-text-right">
        <router-link to="/orders/create">Agregar nueva orden</router-link>
      </div>
      <table class="table is-striped is-fullwidth">
        <thead>
          <th style="width:100px;" class="has-text-right">Cliente</th>
          <th style="width:110px;" class="has-text-right">Fecha</th>
          <th style="width:120px;" class="has-text-right">Hora del pedido</th>
          <th style="width:100px;" class="has-text-right">Hora de entrega</th>
          <th style="width:100px;" class="has-text-right">Precio total</th>
          <th style="width:100px;" class="has-text-right">Estado</th>
          <th style="width:100px;" class="has-text-right"></th>
        </thead>
        <tbody>
          <tr v-for="item in collection.items" :key="item.orderId">
            <td style="width:100px;" class="has-text-right">{{item.customer.customerName}}</td>
            <td style="width:110px;" class="has-text-right">{{item.date}}</td>
            <td style="width:120px;" class="has-text-right">{{item.initTime}}</td>
            <td style="width:100px;" class="has-text-right">{{item.endTime === "00:00:00"? "Pendiente de pago" : item.endTime}}</td>
            <td style="width:100px;" class="has-text-right">{{item.totalPrice}}</td>
            <td style="width:100px;" class="has-text-right">{{item.status === "NOTDELIVERED"? "" : item.status}}</td>
            <td class="has-text-centered">
              <router-link :to="`/orders/${item.orderId}/payorder`">Pagar</router-link>
            </td>
          </tr>
        </tbody>
      </table>
      <Pager :paging="p => getAll(p)" :page="collection.page" :pages="collection.pages" />
    </template>
  </div>
</template>

<script src="./OrderIndex.js"></script>
//El juason:
// {
//     "hasItems": true,
//     "items": [
//         {
//             "orderId": 1,
//             "orderDetails": [
//                 {
//                     "orderDetailId": 1,
//                     "orderId": 1,
//                     "productId": 1,
//                     "product": {
//                         "productId": 1,
//                         "product_Category": null,
//                         "productName": "dadsdsasaddas",
//                         "productPrice": 20.0,
//                         "sellDay": 1,
//                         "stock": 100,
//                         "imageUrl": "test",
//                         "ingredients": []
//                     },
//                     "quantity": 1,
//                     "unitPrice": 20.0,
//                     "totalPrice": 20.0
//                 }
//             ],
//             "customerId": 1,
//             "customer": {
//                 "customerId": 1,
//                 "customerName": "nombre",
//                 "customerAge": 0,
//                 "customer_Category": null,
//                 "cards": [],
//                 "orders": [
//                     {
//                         "orderId": 1,
//                         "orderDetails": [
//                             {
//                                 "orderDetailId": 1,
//                                 "orderId": 1,
//                                 "productId": 1,
//                                 "product": {
//                                     "productId": 1,
//                                     "product_Category": null,
//                                     "productName": "dadsdsasaddas",
//                                     "productPrice": 20.0,
//                                     "sellDay": 1,
//                                     "stock": 100,
//                                     "imageUrl": "test",
//                                     "ingredients": []
//                                 },
//                                 "quantity": 1,
//                                 "unitPrice": 20.0,
//                                 "totalPrice": 20.0
//                             }
//                         ],
//                         "customerId": 1,
//                         "date": "2020-06-28",
//                         "initTime": "04:38:30 AM",
//                         "endTime": "00:00:00",
//                         "totalPrice": 20,
//                         "status": "NOTDELIVERED"
//                     }
//                 ],
//                 "email": "d1b11643-aa99-49fc-a3bb-f79f430e0dd8"
//             },
//             "date": "2020-06-28",
//             "initTime": "04:38:30 AM",
//             "endTime": "00:00:00",
//             "totalPrice": 20,
//             "status": "NOTDELIVERED"
//         }
//     ],
//     "total": 1,
//     "page": 1,
//     "pages": 1
// }
