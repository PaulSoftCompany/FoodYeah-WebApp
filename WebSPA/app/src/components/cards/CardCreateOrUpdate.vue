<template>
  <div>
    <h1 class="title">{{model.productId ? 'Editar tarjeta' : 'Nueva tarjeta'}}</h1>
    <h2 class="subtitle">{{model.productId ? ' ' : 'Creación de tarjeta.'}}</h2>

    <Loader v-if="isLoading" />
    <form v-else @submit.prevent="save">
      <div class="field">
        <input
          :class="{error: validation.hasError('model.cardNumber')}"
          v-model="model.cardNumber"
          class="input"
          type="text"
          placeholder="Ingrese el Número de su tarjeta"
        />
        <p class="help is-danger">{{validation.firstError('model.cardNumber')}}</p>
      </div>

      <div class="field">
        <input
          :class="{error: validation.hasError('model.customerId')}"
          v-model.number="model.customerId"
          class="input"
          type="number"
          placeholder="Ingrese su ID"
        />
        <p class="help is-danger">{{validation.firstError('model.customerId')}}</p>
      </div>

      <div class="field">
        <input
          :class="{error: validation.hasError('model.cardType')}"
          v-model.number="model.cardType"
          class="input"
          type="boolean"
          placeholder="Ingrese el tipo de tarjeta"
        />
        <p class="help is-danger">{{validation.firstError('model.cardType')}}</p>
      </div>


    <div class="field">
        <input
          :class="{error: validation.hasError('model.cardCvi')}"
          v-model.number="model.cardCvi"
          class="input"
          type="number"
          placeholder="Ingrese el cvi"
        />
        <p class="help is-danger">{{validation.firstError('model.cardCvi')}}</p>
      </div>

 <div class="field">
     <input
          :class="{error: validation.hasError('model.cardExpireDate')}"
          v-model="model.cardExpireDate"
          class="input"
          type="text"
          placeholder="Ingrese el Número de su tarjeta"
        />
        <p class="help is-danger">{{validation.firstError('model.cardExpireDate')}}</p>

      </div>
  
      <div class="field">
        <button type="submit" class="button is-info">Guardar</button>
      </div>
    </form>
  </div>
</template>

<script src="./CardCreateOrUpdate.js"></script>