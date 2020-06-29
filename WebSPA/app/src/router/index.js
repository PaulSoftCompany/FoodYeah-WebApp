import Vue from 'vue'
import VueRouter from 'vue-router'
import Default from '../components/Default.vue';
import OrderIndex from '../components/orders/OrderIndex.vue';
import OrderCreate from '../components/orders/OrderCreate.vue';
import ClientIndex from '../components/clients/ClientIndex.vue';
import ProductIndex from '../components/products/ProductIndex.vue';
import ProductCreateOrUpdate from '../components/products/ProductCreateOrUpdate.vue';
import UserIndex from '../components/users/UserIndex.vue';
import store from '../store/index'
import ProductCategoryCreateOrUpdate from '../components/productsCategories/ProductCategoryCreateOrUpdate.vue';
import ProductCategoriesIndex from '../components/productsCategories/ProductCategoriesIndex.vue';
import CardIndex from '../components/cards/CardIndex.vue';
import CardCreateOrUpdate from '../components/cards/CardCreateOrUpdate.vue';
import PayOrder from '../components/orders/PayOrder.vue';
Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'default',
    component: Default
  },
  {
    path: '/orders',
    name: 'orders',
    component: OrderIndex
  },  
  {
    path: '/orders/create',
    name: 'orderscreate',
    component: OrderCreate
  },
  {
    path: '/orders/:id/payorder',
    name: 'payorder',
    component: PayOrder
  },
  {
    path: '/clients',
    name: 'clients',
    component: ClientIndex,
    beforeEnter: authorization
  },
  {
    path: '/products',
    name: 'products',
    component: ProductIndex
  },
  {
    path: '/products/create',
    name: 'productscreate',
    component: ProductCreateOrUpdate,
    beforeEnter: authorization
  },
  {
    path: '/products/:id/edit',
    name: 'productsedit',
    component: ProductCreateOrUpdate,
    beforeEnter: authorization
  },
  {
    path: '/productcategories/:id/edit',
    name: 'productscategoriesedit',
    component: ProductCategoryCreateOrUpdate,
    beforeEnter: authorization
  },
  {
    path: '/productcategories/create',
    name: 'productscategoriescreate',
    component: ProductCategoryCreateOrUpdate,
    beforeEnter: authorization
  },
  {
    path: '/productcategories',
    name: 'productcategories',
    component: ProductCategoriesIndex,
    beforeEnter: authorization
  },
  {
    path: '/users',
    name: 'users',
    component: UserIndex,
    beforeEnter: authorization
  },
  {
    path: '/cards',
    name: 'cards',
    component: CardIndex,
    beforeEnter: authorization
  },
  {
    path: '/cards/create',
    name: 'cardscreate',
    component: CardCreateOrUpdate,
  },
  {
    path: '/cards/:id/edit',
    name: 'cardsupdate',
    component: CardCreateOrUpdate,
    beforeEnter: authorization
  }
]

//to:a donde va, from: de donde viene: next: si procede a que ruta lo enviamos
function authorization(to, from, next) {
  let user = store.state.user;

  if (user) {
    //Si nombre de la ruta es users && el usuario no incluye al admin 
    if (to.name === 'USER' && !user.roles.includes('ADMIN')) {
      return next('/');//ir a la pagina principal
    }
  }

  return next();
}

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
