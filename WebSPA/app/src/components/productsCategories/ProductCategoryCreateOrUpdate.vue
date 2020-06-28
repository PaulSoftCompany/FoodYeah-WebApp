<template>
  <div>
    <h1 class="title">{{model.product_CategoryId ?  'Editar categoría' : 'Nueva Categoría'}}</h1>
    <h2 class="subtitle">{{model.product_CategoryId ? ' ' : 'Creación de la categoría.'}}</h2>

    <Loader v-if="isLoading" />
    <form v-else @submit.prevent="save">
      <div class="field">
        <input
          :class="{error: validation.hasError('model.product_CategoryName')}"
          v-model="model.product_CategoryName"
          class="input"
          type="text"
          placeholder="Ingrese el nombre"
        />
        <p class="help is-danger">{{validation.firstError('model.product_CategoryName')}}</p>
      </div>

      <div class="field">
        <input
          :class="{error: validation.hasError('model.product_CategoryDescription')}"
          v-model.number="model.product_CategoryDescription"
          class="input"
          type="text"
          placeholder="Ingrese la descripcion"
        />
        <p class="help is-danger">{{validation.firstError('model.product_CategoryDescription')}}</p>
      </div>

      <div class="field">
        <button type="submit" class="button is-info">Guardar</button>
      </div>
    </form>
  </div>
</template>

<script src="./ProductCategoryCreateOrUpdate.js"></script>