import hotelsMock from './hotelsMock';
import authMock from './authMock';

const mocksUrls = {
    "api/auth": authMock,
    "api/hotels": hotelsMock
};

function requestMock(params) {
    let {url, method, payload} = params;
    return new Promise((resolve, reject) => {
        const result = mocksUrls[url][method](payload);
        setTimeout(() => resolve(result), 1000);
    });
}

export default requestMock;