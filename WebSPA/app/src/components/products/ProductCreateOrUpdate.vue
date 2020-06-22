<template>
  <div>
    <h1 class="title">{{model.productId ? model.name : 'Nuevo producto'}}</h1>
    <h2 class="subtitle">{{model.productId ? model.description : 'Creación de producto.'}}</h2>

    <Loader v-if="isLoading" />
    <form v-else @submit.prevent="save">
      <div class="field">
        <input
          :class="{error: validation.hasError('model.ProductName')}"
          v-model="model.ProductName"
          class="input"
          type="text"
          placeholder="Ingrese el nombre"
        />
        <p class="help is-danger">{{validation.firstError('model.ProductName')}}</p>
      </div>

      <div class="field">
        <input
          :class="{error: validation.hasError('model.Product_CategoryId')}"
          v-model.number="model.Product_CategoryId"
          class="input"
          type="number"
          placeholder="Ingrese la categoria"
        />
        <p class="help is-danger">{{validation.firstError('model.Product_CategoryId')}}</p>
      </div>

      <div class="field">
        <input
          :class="{error: validation.hasError('model.ProductPrice')}"
          v-model.number="model.ProductPrice"
          class="input"
          type="number"
          placeholder="Ingrese el precio"
        />
        <p class="help is-danger">{{validation.firstError('model.ProductPrice')}}</p>
      </div>


         <div class="field">
        <input
          :class="{error: validation.hasError('model.Stock')}"
          v-model.number="model.Stock"
          class="input"
          type="number"
          placeholder="Ingrese el stock"
        />
        <p class="help is-danger">{{validation.firstError('model.Stock')}}</p>
      </div>

 <div class="field">
        <input
          :class="{error: validation.hasError('model.SellDay')}"
          v-model.number="model.SellDay"
          class="input"
          type="number"
          placeholder="Ingrese el dia de venta"
        />
        <p class="help is-danger">{{validation.firstError('model.SellDay')}}</p>
      </div>

 <div class="field">
<input 
     v-model="Ingrediente"
     class="input"
    type="text"
      placeholder="Ingrese los ingredientes"/>
      </div>
      <div class="field">
          <td class="title" >Ingredientes</td>
          <tr v-for="Ingrediente in model.Ingredients" :key="Ingrediente">
              <td>{{Ingrediente}}</td>
          </tr>
      </div>
<div class="field">
        <button   type="button" class="button is-info is-normal" v-on:click="AddIngrediente" >Agregar Ingrediente</button>
        <button   type="button" class="button is-danger is-normal" v-on:click="DeleteIngrediente" >Eliminar Ingrediente</button>
      </div>


      <div class="field">
        <button type="submit" class="button is-info">Guardar</button>
      </div>
    </form>
  </div>
</template>

<script src="./ProductCreateOrUpdate.js"></script>