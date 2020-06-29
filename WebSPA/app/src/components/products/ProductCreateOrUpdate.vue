<template>
  <div>
    <h1 class="title">{{model.productId ? 'Editar producto' : 'Nuevo producto'}}</h1>
    <h2 class="subtitle">{{model.productId ? ' ' : 'Creación de producto.'}}</h2>

    <Loader v-if="isLoading" />
    <form v-else @submit.prevent="save">
      <div class="field">
        <input
          :class="{error: validation.hasError('model.productName')}"
          v-model="model.productName"
          class="input"
          type="text"
          placeholder="Ingrese el nombre"
        />
        <p class="help is-danger">{{validation.firstError('model.productName')}}</p>
      </div>

      <div class="field">
        <input
          :class="{error: validation.hasError('model.product_CategoryId')}"
          v-model.number="model.product_CategoryId"
          class="input"
          type="number"
          placeholder="Ingrese la categoria"
        />
        <p class="help is-danger">{{validation.firstError('model.product_CategoryId')}}</p>
      </div>

      <div class="field">
        <input
          :class="{error: validation.hasError('model.productPrice')}"
          v-model.number="model.productPrice"
          class="input"
          type="number"
          placeholder="Ingrese el precio"
        />
        <p class="help is-danger">{{validation.firstError('model.productPrice')}}</p>
      </div>

      <div class="field">
        <input
          :class="{error: validation.hasError('model.stock')}"
          v-model.number="model.stock"
          class="input"
          type="number"
          placeholder="Ingrese el stock"
        />
        <p class="help is-danger">{{validation.firstError('model.stock')}}</p>
      </div>

      <div class="field">
        <input
          :class="{error: validation.hasError('model.sellDay')}"
          v-model.number="model.sellDay"
          class="input"
          type="number"
          placeholder="Ingrese el dia de venta"
        />
        <p class="help is-danger">{{validation.firstError('model.sellDay')}}</p>
      </div>

      <div class="field">
        <input
          :class="{error: validation.hasError('model.imageUrl')}"
          v-model.number="model.sellDay"
          class="input"
          type="text"
          placeholder="Ingrese la url de la imagen"
        />
        <p class="help is-danger">{{validation.firstError('model.imageUrl')}}</p>
      </div>

      <div class="field">
        <input
          v-model="Ingrediente"
          class="input"
          type="text"
          placeholder="Ingrese los ingredientes"
        />
      </div>

      <div class="field">
        <td class="title">Ingredientes</td>
        <tr v-for="ingrediente in model.ingredients" :key="ingrediente">
          <td>{{ingrediente}}</td>
        </tr>
      </div>
      <div class="field">
        <button
          type="button"
          class="button is-info is-normal"
          v-on:click="AddIngrediente"
        >Agregar Ingrediente</button>
        <button
          type="button"
          class="button is-danger is-normal"
          v-on:click="DeleteIngrediente"
        >Eliminar Ingrediente</button>
      </div>

      <div class="field">
        <button type="submit" class="button is-info">Guardar</button>
      </div>
    </form>
  </div>
</template>

<script src="./ProductCreateOrUpdate.js"></script>