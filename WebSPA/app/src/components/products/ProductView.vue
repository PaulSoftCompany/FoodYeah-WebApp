<template>
  <div>
 <div class="box">
       <div class="content">
        <h1>
          <b>MENÚ DEL DÍA</b>
        </h1>
      </div>
      <Loader v-if="isLoading" />
      <template v-else>
        <div  v-for="item in collection.items" :key="item.productId">
          <div class="card" v-if="item.product_Category.product_CategoryId === 1">
            <div class="card-header">
              <div class="content">
                <h1 class="card-header-title">{{item.productName}}</h1>
              </div>
            </div>
            <div>
              <figure class="image is-4by3">
                <img v-bind:src="item.imageUrl" alt="Placeholder image" />
              </figure>
            </div>
            <div class="card-content">
              <div class="content">
                <h3>Categoria</h3>
                <p>{{item.product_Category.product_CategoryName}}</p>
                <h3>Precio</h3>
                <p>S/. {{item.productPrice}}</p>
                <h3>Stock</h3>
                <p>{{item.stock}}</p>

                <div class="buttons">
                  <button class="button is-primary">
                    Comprar
                    <div class="imgSize">
                      <img src="../../assets/shoppingcart.png" />
                    </div>
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </template>
    </div>
    <div class="box">
       <div class="content">
        <h1>
          <b>PLATOS A LA CARTA</b>
        </h1>
      </div>
      <Loader v-if="isLoading" />
      <template v-else>
        <div v-for="item in collection.items" :key="item.productId">
          <div class="card" v-if="item.product_Category.product_CategoryId === 2">
            <div class="card-header">
              <div class="content">
                <h1 class="card-header-title">{{item.productName}}</h1>
              </div>
            </div>
            <div>
              <figure class="image is-4by3">
                <img v-bind:src="item.imageUrl" alt="Placeholder image" />
              </figure>
            </div>
            <div class="card-content">
              <div class="content">
                <h3>Categoria</h3>
                <p>{{item.product_Category.product_CategoryName}}</p>
                <h3>Precio</h3>
                <p>S/. {{item.productPrice}}</p>
                <h3>Stock</h3>
                <p>{{item.stock}}</p>

                <div class="buttons">
                  <button class="button is-primary">
                    Comprar
                    <div class="imgSize">
                      <img src="../../assets/shoppingcart.png" />
                    </div>
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </template>
    </div>
  </div>
</template>


<script src="./ProductView.js"></script>
<style src="./ProductView.css"></style>