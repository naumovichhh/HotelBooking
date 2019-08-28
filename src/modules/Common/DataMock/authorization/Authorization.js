import accounts from './accounts.json.js.js.js';

class Authorization {
    constructor()
    {
        this.isAuthorized = false;
        this.currentAccount = null;
    }

    authorize (login, password){
        let account;
        if ((account = accounts.admins.find(e => e.login === login && e.password === password)) !== undefined) {
            this.currentAccount = { ...account, role: "admin"};
            this.isAuthorized = true;
        }
        else {
            if (accounts.users.find(e => e.login === login && e.password === password) !== undefined) {
                this.currentAccount = { ...account, role: "user" };
                this.isAuthorized = true;
            }
        }
        return this.isAuthorized;
    }

    signout (){
        this.isAuthorized = false;
        this.currentAccount = null;
    }
};

export default authorization;