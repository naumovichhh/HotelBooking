import requestMock from './mock/requestMock';

function request(params) {
    return requestMock(params);
}

export default request;