import requestMock from './mock/requestMock';
import store from 'common/redux/store';

function request(params) {
    return requestMock(params);
}

function realRequest(params) {
    if (store.getState().auth.authorized)
        params.Authorization = "Bearer "+store.getState().auth.token;
    return fetch("https://localhost:44339/"+params.url, params);
}

export default realRequest;