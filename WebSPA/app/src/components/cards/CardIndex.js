import Loader from '../../shared/Loader'
import Pager from '../../shared/Pager'

export default {
    name: 'CardIndex',
    components: {
        Loader, Pager
    },
    mounted() {
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
            }
        }
    },
    methods: {
        getAll(page) {
            this.isLoading = true;
            this.$proxies.cardProxy.getAll(page, 10)
                .then(x => {
                    this.collection = x.data;
                    this.isLoading = false;
                }).catch(() => {
                    this.isLoading = false;
                });
                //Falta filtrar tarjetas por cliente!
            //this.collection.items = this.collection.items.filter(x => x.)
        },
        remove(cardid){
            this.isLoading = true;
            this.$proxies.cardProxy.remove(cardid)
                .then(() => {
                    this.getAll(1);
                }).catch(() => {
                    this.isLoading = false;
                });
        }
    }
}