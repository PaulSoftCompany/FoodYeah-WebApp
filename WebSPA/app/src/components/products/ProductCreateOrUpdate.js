import Loader from '../../shared/Loader'
import Pager from '../../shared/Pager'

export default {
  name: 'ProductCreateOrUpdate',
  components: {
    Loader, Pager
  },
  mounted() {
    this.get();
  },
  validators: {
    'model.productName'(value) {
      return this.$validator
        .value(value)
        .required()
        .minLength(5)
        .maxLength(50);
    },
    'model.productPrice'(value) {
      return this.$validator
        .value(value)
        .required()
        .greaterThan(0);
    },
  },
  data() {
    return {
      user: this.$store.state.user,
      isLoading: false,
      model: {
        productId: 0,
        productName: null,
        product_CategoryId: null,
        productPrice: null,
        stock:null,
        sellDay:null,
        ingredients: new Array,
        imageUrl:null,
        ingrediente:null
      },
      product_categories: []
    }
  },
  methods: {
    get() {
      this.$proxies.productcategoryProxy.getAll(1, 100).then( x => this.product_categories = x.data.items);

      let id = this.$route.params.id;

      if (!id) return;

      this.isLoading = true;
      this.$proxies.productProxy.get(id)
        .then(x => {
          this.model = x.data;
          this.isLoading = false;
        })
        .catch(() => {
          this.isLoading = false;
          this.$notify({
            group: "global",
            type: "is-danger",
            text: 'Ocurrió un error inesperado'
          });
        })
    },
    save() {
      this.$validate().then(success => {
        if (!success) return;

        this.isLoading = true;

        if(this.model.productId) {
          this.$proxies.productProxy.update(this.model.productId, this.model)
          .then(() => {
            this.$notify({
              group: "global",
              type: "is-success",
              text: 'Producto actualizado con éxito'
            });
            this.$router.push('/products');
          })
          .catch(() => {
            this.isLoading = false;
            this.$notify({
              group: "global",
              type: "is-danger",
              text: 'Ocurrió un error inesperado'
            });
          });
        } else {
          this.$proxies.productProxy.create(this.model)
          .then(() => {
            this.$notify({
              group: "global",
              type: "is-success",
              text: 'Producto creado con éxito'
            });
            this.$router.push('/products');
          })
          .catch(() => {
            this.isLoading = false;
            this.$notify({
              group: "global",
              type: "is-danger",
              text: 'Ocurrió un error inesperado'
            });
          });
        }


      })
    },
    AddIngrediente(){
      this.model.Ingredients.push(this.Ingrediente);
    },
    DeleteIngrediente(){
      this.model.Ingredients.pop();
    },
        onChangeProductSelection() {
            let product = this.products.find(
                x => x.productId === this.product.productId
            );
            //TODO: ver bien lo del stock
            this.product.stock = product.stock;
            this.product.quantity = 1;
            this.product.productPrice = product.productPrice;
            this.product.productName = product.productName;
        },
  }
}