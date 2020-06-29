import Loader from '../../shared/Loader'
import Pager from '../../shared/Pager'

export default {
    name: 'PayOrder',
    components: {
        Loader, Pager
    },
    validators: {
        'model.cardNumber'(value) {
            return this.$validator
                .value(value)
                .required()
                .minLength(16)
                .maxLength(20);
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
                .required()
        },
    },
    data() {
        return {
            user: this.$store.state.user,
            isLoading: false,
            model: {
                cardNumber: null,
                cardCvi: null,
                cardExpireDate: null,
            },
            collection: {
                hasItems: false,
                items: [],
                total: 0,
                page: 1,
                pages: 0
            }
        }
    },
    methods: {
        pay() {
            this.$validate().then(success => {
                if (!success) return;
                this.isLoading = true;

                console.log(this.model.cardNumber);
                console.log(this.model.cardCvi);
                console.log(this.model.cardExpireDate);

                this.$proxies.cardProxy.getAll(1, 10)
                .then(x => {
                    this.collection = x.data;
                    this.collection.items.forEach(element => {
                        
                        console.log(element.cardNumber);
                        console.log(element.cardCvi);
                        console.log(element.cardExpireDate);
    
                        if (element.cardNumber == this.model.cardNumber &&
                            element.cardCvi == this.model.cardCvi &&
                            element.cardExpireDate == this.model.cardExpireDate
                        ) {
                            let orderid = this.$route.params.id;
                            this.$proxies.orderProxy.pay(element.cardId, orderid).then(() => {
                                this.$notify({
                                    group: "global",
                                    type: "is-success",
                                    text: 'Orden pagada con exito'
                                });
                                this.isLoading = false;
                                this.$router.push('/orders');
                                return;
                            });
                        }
                    }
                    );
                });
            });
                this.isLoading = false;
                this.$notify({
                    group: "global",
                    type: "is-danger",
                    text: 'Credenciales Erróneas'
                });
        }
    }
}