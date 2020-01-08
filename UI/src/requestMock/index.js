import requestMock from './mock/requestMock';

function request(params) {
    return requestMock(params);
}

function requestFetch(params) {
    return fetch("https://localohost:44339/"+params.url, params);
}

export default request;