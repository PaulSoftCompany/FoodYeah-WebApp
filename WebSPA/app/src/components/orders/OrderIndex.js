import Loader from '../../shared/Loader'
import Pager from '../../shared/Pager'

export default {
    name: 'OrderIndex',
    components: {
        Loader, Pager
    },
    mounted() {
        console.log(this.user)
        this.getAll(1);
    },
    data() {
        return {
            user: this.$store.state.user,
            isLoading: false,
            collection: {
                hasItems: false,
                items: [],
                total: 0,
                page: 1,
                pages: 0
            },
            orders: []
        }
    },
    methods: {
        getAll(page) {
            this.isLoading = true;
            this.$proxies.orderProxy.getAll(page, 10)
                .then(x => {
                    this.collection = x.data;
                    this.isLoading = false;
                    console.log("this.user.name");
                    console.log(this.user.name);
                    if (this.user.roles == 'USER')
                        this.orders = this.collection.items.filter(x =>
                            x.customer.email === this.user.id
                        );
                    else
                        this.orders = this.collection.items

                    console.log(this.orders)

                }).catch(() => {
                    this.isLoading = false;
                });
        }
    },
}

