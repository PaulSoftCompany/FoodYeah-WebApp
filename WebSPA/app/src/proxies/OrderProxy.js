export default class OrderProxy {
    constructor(axios, url) {
        this.axios = axios;
        this.url = url;
    }

    get(id) {
        return this.axios.get(this.url + `orders/${id}`);
    }

    getAll(page, take) {
        return this.axios.get(this.url + `orders?page=${page}&take=${take}`);
    }

    create(params) {
        return this.axios.post(this.url + `orders`, params);
    }
    pay(cardid, orderid){
        return this.axios.put(this.url+`cards/${cardid}/orderDelivered/${orderid}`)
    }
}