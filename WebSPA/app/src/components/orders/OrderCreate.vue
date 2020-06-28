<template>
  <div>
    <h1 class="title">Creación de orden</h1>
    <h2 class="subtitle">Desde aquí podrá crear una nueva orden de compra.</h2>

    <Loader v-if="isLoading" />
    <template v-else>
      <div class="box">
        <div class="select is-fullwidth">
          <select v-model.number="model.customerId">
            <option v-for="customer in customers" :key="customer.customerId" :value="customer.customerId">{{customer.customerId}}</option>
          </select>
        </div>
      </div>

      <div class="box">
        <table class="table is-fullwidth is-striped">
          <thead>
            <tr>
              <th colspan="2">Producto</th>
              <th class="has-text-right" style="width:150px;">Id</th>
              <th class="has-text-right" style="width:150px;">Stock</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td colspan="2">
                <div class="select is-fullwidth">
                  <select @change="onChangeProductSelection" v-model.number="product.productId">
                    <option v-for="product in products" :key="product.productId" :value="product.productId">{{product.productId}}</option>
                  </select>
                </div>
              </td>
              <td>
                <input class="input" type="number" v-model.number="product.productId" />
              </td>
              <td>
                <input class="input" type="number" v-model.number="product.stock" />
              </td>
              <td class="has-text-right" colspan="3">
                <button @click="addProduct" class="button">Agregar</button>
              </td>
            </tr>

            <tr v-if="model.orderDetails.length === 0">
              <td class="has-text-centered is-size-5" colspan="7">No se ha seleccionado un producto</td>
            </tr>
            <tr v-else v-for="item in model.orderDetails" :key="item.productId">
              <td class="has-text-centered" style="width:100px;">
                <a class="has-text-danger" @click="removeProduct(item.productId)">Retirar</a>
              </td>
              <td>{{item.productId}}</td>
              <td class="has-text-right">{{item.stock}}</td>
            </tr>
            
          </tbody>

        </table>
        <button @click="create" :disabled="model.orderDetails.length === 0" class="button is-primary is-medium is-fullwidth">Crear orden</button>
      </div>
    </template>
  </div>
</template>

<script src="./OrderCreate.js"></script>
//El juason:(del post)
// {
// 	"OrderDetails": [
// 		{
// 			"ProductId": 1,
// 			"Quantity": 1
// 		}
// 		],
// 	"CustomerId": 1
// }