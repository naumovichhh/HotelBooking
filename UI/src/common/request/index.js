import requestMock from './mock/requestMock';
import store from 'common/redux/store';

function request(params) {
    return requestMock(params);
}

function realRequest(url, options) {
    options.headers["Accept"] =  "application/json";
     
    if (store.getState().auth.authorized)
        options.headers.Authorization = "Bearer " + store.getState().auth.token;
    
    return fetch("https://localhost:44339/" + url, options);
}

export default realRequest;