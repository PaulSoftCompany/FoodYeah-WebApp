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
    'model.ProductName'(value) {
      return this.$validator
        .value(value)
        .required()
        .minLength(5)
        .maxLength(50);
    },
    'model.ProductPrice'(value) {
      return this.$validator
        .value(value)
        .required()
        .greaterThan(0);
    },
  },
  data() {
    return {
      isLoading: false,
      model: {
        productId: 0,
        ProductName: null,
        Product_CategoryId: null,
        ProductPrice: null,
        Stock:null,
        SellDay:null,
        Ingredients: new Array,
        ImageUrl:"test",
        Ingrediente:null

      }
    }
  },
  methods: {
    get() {
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
    }
  }
}