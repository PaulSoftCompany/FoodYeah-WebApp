import Loader from '../../shared/Loader'
import Pager from '../../shared/Pager'

export default {
  name: 'CardCreateOrUpdate',
  components: {
    Loader, Pager
  },
  mounted() {
    this.get();
  },
  validators: {

    'model.cardNumber'(value) {
      return this.$validator
        .value(value)
        .required()
        .minLength(16)
        .maxLength(20);
    },
    'model.cardType'(value) {
      return this.$validator
        .value(value)
        .required()
    },
    'model.customerId'(value) {
      return this.$validator
        .value(value)
        .required()
    },
    'model.cardCvi'(value) {
      return this.$validator
        .value(value)
        .required()
        .minLength(1)
        .maxLength(3);
    },
    'model.cardExpireDate'(value) {
      return this.$validator
        .value(value)
        .required();
    },
  },

  data() {
    return {
      isLoading: false,
      user: this.$store.state.user,
      userName: null,
      customers: [],
      model: {
        cardNumber: null,
        customerId: null,
        cardType: null,
        cardCvi: null,
        cardExpireDate: null,
      }

    }
  },
  methods: {
    get() {
      let customers = this.$proxies.userProxy.getAll(1, 100);
      Promise.all([customers])
        .then(values => {
          //Cargamos los datos:
          this.customers = values[0].data.items;
          let customer = this.customers.find(x=> x.email === this.user.id);
          this.model.customerId = customer.customerId;
          this.userName = customer.customerName;
        })

      let id = this.$route.params.id;
      if (!id) return;
      this.isLoading = true;
      this.$proxies.cardProxy.get(id)
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

        ////////////////
        if (this.model.cardId) {
          this.$proxies.cardProxy.update(this.model.cardId, this.model)
            .then(() => {
              this.$notify({
                group: "global",
                type: "is-success",
                text: 'Tarjeta actualizada con éxito'
              });
              this.$router.push('/cards');
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
          this.$proxies.cardProxy.create(this.model)
            .then(() => {
              this.$notify({
                group: "global",
                type: "is-success",
                text: 'Tarjeta creada con éxito'
              });
              this.$router.push('/cards');
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
    }
  }
}
