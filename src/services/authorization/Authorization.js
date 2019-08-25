import accounts from './accounts.json';

const authorization = {
    isAuthorized: false,
    
    currentAccount: null,
    authorize: function(login, password) {
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
    },
    signout: function() {
        this.isAuthorized = false;
        this.currentAccount = null;
    }
};

export default authorization;