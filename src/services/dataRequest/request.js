import requestMock from './requestMock';

function request(params) {
    return requestMock(params);
}

export default request;