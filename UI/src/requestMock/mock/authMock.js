import json from './accounts.json';

const authMock = {
    GET: () => {
        
    },
    POST: ({login, password}) => {
        const user = json.accounts.find(a => a.login === login && a.password === password);
        if (user) {
            return { authorized: true, user };
        }
        else {
            return { authorized: false };
        }
    },
    DELETE: () => {
        
    },
    PUT: () => {
        
    }
}

export default authMock;