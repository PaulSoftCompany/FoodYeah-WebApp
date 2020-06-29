<template>
  <div>
    <h2 class="subtitle">Pagar la orden</h2>
    <Loader v-if="isLoading" />
    <form v-else @submit.prevent="pay">
      <div class="field">
        <input
          :class="{error: validation.hasError('model.cardNumber')}"
          v-model.number="model.cardNumber"
          class="input"
          type="number"
          placeholder="Ingrese el Número de su tarjeta"
        />
        <p class="help is-danger">{{validation.firstError('model.cardNumber')}}</p>
      </div>

      <div class="field">
        <input
          :class="{error: validation.hasError('model.cardExpireDate')}"
          v-model="model.cardExpireDate"
          class="input"
          type="text"
          placeholder="Ingrese la fecha de expiración de su tarjeta"
        />
        <p class="help is-danger">{{validation.firstError('model.cardExpireDate')}}</p>
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
        <button type="submit" class="button is-info">Pagar</button>
      </div>
    </form>
  </div>
</template>

<script src="./PayOrder.js"></script>
<style scoped>
input[type="number"]::-webkit-outer-spin-button,
input[type="number"]::-webkit-inner-spin-button {
    -webkit-appearance: none;
    margin: 0;
}
input[type="number"] {
    -moz-appearance: textfield;
}
</style>