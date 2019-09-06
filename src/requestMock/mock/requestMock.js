import hotelsMock from './hotelsMock';

function requestMock(params) {
    let {url, method, payload} = params;
    return new Promise((resolve, reject) => {
        alert(method);
        const data = hotelsMock[method](payload);
        setTimeout(() => resolve(data), 1000);
    });
}

export default requestMock;