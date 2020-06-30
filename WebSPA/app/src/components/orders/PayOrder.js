import Loader from '../../shared/Loader'
import Pager from '../../shared/Pager'

export default {
    name: 'PayOrder',
    components: {
        Loader, Pager
    },
    mounted() {
        this.getAll(1);
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
            },
            cards: [],
            card: {
                cardId: null,
                cardName: null
            }
        }
    },
    methods: {
        getAll(page) {
            this.isLoading = true;
            this.$proxies.cardProxy.getAll(page, 10)
                .then(x => {
                    this.cards = x.data.items;
                    this.isLoading = false;
                }).catch(() => {
                    this.isLoading = false;
                });
            //Falta filtrar tarjetas por cliente!
            //this.collection.items = this.collection.items.filter(x => x.)

        },
        pay() {
            this.$validate().then(success => {
                if (!success) {
                    this.isLoading = false;
                    this.$notify({
                        group: "global",
                        type: "is-danger",
                        text: 'Ocurrió un error inesperado'
                    });
                    return;
                }

                this.isLoading = true;
                this.$proxies.cardProxy.getAll(1, 10)
                    .then(x => {
                        this.collection = x.data;
                        this.collection.items.forEach(element => {

                            if (element.cardNumber === this.model.cardNumber &&
                                element.cardCvi === this.model.cardCvi &&
                                element.cardExpireDate === this.model.cardExpireDate
                            ) {
                                let orderid = this.$route.params.id;
                                let order = this.$proxies.orderProxy.get(orderid);
                                Promise.resolve(order).then(
                                    value => {
                                        console.log(element.money)
                                        console.log(value)
                                        console.log(value.totalPrice)
                                        if (element.money - value.data.totalPrice <= 0) {
                                            this.isLoading = false;
                                            this.$notify({
                                                group: "global",
                                                type: "is-danger",
                                                text: 'No hay suficiente dinero en la tarjeta para pagar la orden'
                                            });
                                            return;
                                        }
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
                                )
                            }
                        }
                        );
                    });
            })

        },
        onChangeProductSelection() {
            let cardaux = this.cards.find(x => x.cardId === this.card.cardId);
            this.model.cardNumber = cardaux.cardNumber;
            this.model.cardCvi = cardaux.cardCvi;
            this.model.cardExpireDate = cardaux.cardExpireDate;
        }
    }
}