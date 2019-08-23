import React from 'react';
import accounts from './accounts.json';

class Login extends React.Component {
    constructor(properties) {
        super(properties);
        this.state = { login: "", password: "", loginIsValid: true, passwordIsValid: true };
    }

    passwordIsInvalidMessage = "Password must contain at least 4 characters";
    loginIsInvalidMessage = "Login must contain valid email address";

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
        if (s.length >= 4)
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
            this.props.history.push("/admin");
        }
        else {
            if (accounts.users.find(e => e.login === login && e.password === password) !== undefined) {
                this.props.history.push("/home");
            }
            else {
                this.setState({ wrongData: true });
            }
        }
    }

    render() {
        return (
            <form style={{marginLeft: "10px", marginRight: "10px", marginTop: "20px", minWidth: "760px"}} role="form" className="form form-signin col-7" >
                <div className="form-group">
                    <input className="form-control col-3" style={{display: "inline"}} placeholder="Username" name="user" type="text" value={this.state.login} onChange={this.onUserChange} />
                    {!this.state.loginIsValid ? <span className="col-3" style={{color: "red"}} >{this.loginIsInvalidMessage}</span> : <span> </span>}
                </div>
                <div className="form-group">
                    <input className="form-control col-3" style={{display: "inline"}} placeholder="Password" name="password" type="password" value={this.state.password} onChange={this.onPasswordChange}/>
                    {!this.state.passwordIsValid ? <span className="col-3" style={{color: "red"}}>{this.passwordIsInvalidMessage}</span> : <span> </span>}
                </div>
                <div className="form-group">
                    <input className="btn btn-primary" name="send" type="submit" value="Войти" onClick={this.onSubmit} />
                </div>
            </form>
        );
    }
}

export default Login;