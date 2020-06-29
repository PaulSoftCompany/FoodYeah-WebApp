<template>
  <div>
    <Loader v-if="isLoading" />
    <template v-else>
      <h1 class="title">Bienvenido {{customer.customerName}}</h1>
      <h2 class="subtitle">Desde aquí podras crear una nueva orden de compra.</h2>
      <div class="box">
        <table class="table is-fullwidth is-striped">
          <thead>
            <tr>
              <th colspan="2">Producto</th>
              <th class="has-text-right" style="width:150px;">Unidades</th>
              <th class="has-text-right" style="width:150px;">Precio</th>
              <th class="has-text-right" style="width:150px;">Disponible</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td colspan="2">
                <div class="select is-fullwidth">
                  <select @change="onChangeProductSelection" v-model.number="product.productId">
                    <option v-for="product in products" :key="product.productId" :value="product.productId">{{product.productName}}</option>
                  </select>
                </div>
              </td>
              <td>
                <input class="input" type="number" style="width:150px;" v-model.number="product.quantity" />
              </td>
              <td>
                <th class="has-text-right" style="width:150px;">S/.{{product.productPrice.toFixed(2)}}</th>
              </td>
              <td>
                <th class="has-text-right" style="width:150px;">{{product.stock}} unid.</th>
              </td>
              <td class="has-text-right" colspan="3">
                <button @click="addProduct" class="button">Agregar</button>
              </td>
            </tr>

            <tr v-if="model.orderDetails.length === 0">
              <td class="has-text-centered is-size-5" colspan="7">No se ha seleccionado un producto</td>
            </tr>
            <tr v-else v-for="item in this.itemsview" :key="item.productId">
              <td colspan="2">{{item.productName}}</td>
              <td class="has-text-right" style="width:150px;">{{item.quantity}}</td>
              <td class="has-text-right" style="width:150px;">S/.{{item.price.toFixed(2)}}</td>
              <td class="has-text-centered" style="width:150px;">-</td>
              <td class="has-text-centered" style="width:100px;">
                <a class="has-text-danger" @click="removeProduct(item.productId)">Retirar</a>
              </td>              
            </tr>
            
          </tbody>

        </table>
        <button @click="create" :disabled="model.orderDetails.length === 0" class="button is-primary is-medium is-fullwidth">Crear orden</button>
      </div>
    </template>
  </div>
</template>

<script src="./OrderCreate.js"></script>