import dataMock from './dataMock';

function requestMock(params) {
    let {url, method, data} = params;
    return new Promise((resolve, reject) => {
        const data = dataMock[method](data);
        resolve(data);
    });
}

export default requestMock;