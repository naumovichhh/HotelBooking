import React from 'react';
import accounts from './accounts.json';

class Login extends React.Component {
    constructor(properties) {
        super(properties);
        this.state = { login: "", password: "", loginIsValid: true, passwordIsValid: true };
    }

    passwordIsInvalidMessage = "Password must contain at least 8 characters";
    loginIsInvalidMessage = "User must contain valid e-mail address";

    onUserChange = (e) => {
        this.setState({ login: e.target.value });
    }

    onPasswordChange = (e) => {
        this.setState({ password: e.target.value });
    }

    checkLoginValid(s) {
        if (s.search(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/) != -1)
            return true;
        else
            return false;
    }

    checkPasswordValid(s) {
        if (s.length >= 8)
            return true;
        else
            return false;
    }

    onSubmit = (e) => {        
        e.preventDefault();
        let loginIsValid = this.checkLoginValid(this.state.login);
        let passwordIsValid = this.checkPasswordValid(this.state.password);
        if (loginIsValid & passwordIsValid) {
            this.logIn();
        }
        else {
            this.setState({ loginIsValid: loginIsValid, passwordIsValid: passwordIsValid });
        }
    }

    logIn() {
        let login = this.state.login, password = this.state.password;
        if (accounts.admins.find(e => e.login === login && e.password === password) !== undefined) {
            window.open('/admin', '_self');
        }
        else {
            if (accounts.users.find(e => e.login === login && e.password === password) !== undefined) {
                window.open('/home', '_self');
            }
            else {
                this.setState({ wrongData: true });
            }
        }
    }

    render() {
        return (
            <form style={{marginLeft: "20px", marginTop: "20px"}} role="form" className="form form-horizontal" >
                <div className="form-group">
                    <div className="col-md-2 col-sm-4">
                        <input className="form-control" placeholder="Username" name="user" type="text" value={this.state.login} onChange={this.onUserChange} />
                    </div>
                    {!this.state.loginIsValid && <span className="col-md-2 col-sm-4" style={{color: "red"}} >{this.loginIsInvalidMessage}</span>}
                </div>
                <div className="form-group">
                    <div className="col-md-2 col-sm-4">
                        <input className="form-control" placeholder="Password" name="password" type="password" value={this.state.password} onChange={this.onPasswordChange}/>
                    </div>
                    {!this.state.passwordIsValid && <span className="col-md-2 col-sm-4" style={{color: "red"}}>{this.passwordIsInvalidMessage}</span>}
                </div>
                <div className="form-group col-md-2 col-sm-4">
                    <input className="btn btn-primary" name="send" type="submit" value="Войти" onClick={this.onSubmit} />
                </div>
            </form>
        );
    }
}

export default Login;