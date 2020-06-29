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
    data() {
        return {
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
        },
        pay(cardid){
            let id = this.$route.params.id;
            this.$proxies.orderProxy.pay(id, cardid).then(() => {
                this.$notify({
                  group: "global",
                  type: "is-success",
                  text: 'Orden pagada con exito'
                });
                this.$router.push('/orders');
              });
        }
    }
}