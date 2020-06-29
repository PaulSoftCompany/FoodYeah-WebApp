import Axios from 'axios';
import IdentityProxy from './IdentityProxy';
import UserProxy from './UserProxy';
import ProductProxy from './ProductProxy';
import OrderProxy from './OrderProxy';
import ClientProxy from './ClientProxy';
import ProductCategoryProxy from './ProductCategoryProxy';
import CardProxy from './CardProxy';
// Axios default behavior
Axios.defaults.headers.common.Accept = 'application/json';

// Token
Axios.interceptors.request.use(
    config => {
        let token = localStorage.getItem('access_token');

        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }

        return config;
    },
    error => Promise.reject(error)
);

//TODO: Test
Axios.interceptors.response.use(
    response => response,
    error => {
        const { status } = error.response;

        if (status === 401) {
            localStorage.removeItem('access_token');
            window.location.reload(true);
        }

        return Promise.reject(error);
    }
);

let url = 'https://foodyeahwebapp.herokuapp.com/';

export default {
    identityProxy: new IdentityProxy(Axios,url),
    userProxy: new UserProxy(Axios, url),
    productProxy: new ProductProxy(Axios, url),
    orderProxy: new OrderProxy(Axios, url),
    clientProxy: new ClientProxy(Axios, url),
    productcategoryProxy: new ProductCategoryProxy(Axios,url),
    cardProxy: new CardProxy(Axios,url)
}