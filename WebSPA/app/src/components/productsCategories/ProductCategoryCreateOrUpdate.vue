<template>
  <div>
    <h1 class="title">{{model.productId ? model.name : 'Nueva Categoría'}}</h1>
    <h2 class="subtitle">{{model.productId ? model.description : 'Creación de la categoría.'}}</h2>

    <Loader v-if="isLoading" />
    <form v-else @submit.prevent="save">
      <div class="field">
        <input
          :class="{error: validation.hasError('model.Product_CategoryName')}"
          v-model="model.Product_CategoryName"
          class="input"
          type="text"
          placeholder="Ingrese el nombre"
        />
        <p class="help is-danger">{{validation.firstError('model.ProductCategoryName')}}</p>
      </div>

      <div class="field">
        <input
          :class="{error: validation.hasError('model.Product_CategoryDescription')}"
          v-model.number="model.Product_CategoryDescription"
          class="input"
          type="text"
          placeholder="Ingrese la descripcion"
        />
        <p class="help is-danger">{{validation.firstError('model.Product_CategoryDescription')}}</p>
      </div>
        <div class="field">
        <button type="submit" class="button is-info">Guardar</button>
      </div>
    </form>
  </div>
</template>

<script src="./ProductCategoryCreateOrUpdate.js"></script>