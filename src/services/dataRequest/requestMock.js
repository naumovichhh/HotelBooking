import dataMock from './dataMock';

function requestMock(params) {
    let {url, method, data} = params;
    return dataMock[method](data);
}

export default requestMock;