import React from 'react';

class Login extends React.Component {
    constructor(properties) {
        super(properties);
        this.state = { user: "", password: "", userIsValid: true, passwordIsValid: true };
    }

    passwordIsInvalidMessage = "Password must contain at least 8 characters";
    userIsInvalidMessage = "User must contain valid e-mail address";

    onUserChange = (e) => {
        this.setState({ user: e.target.value });
    }

    onPasswordChange = (e) => {
        this.setState({ password: e.target.value });
    }

    checkUserValid(s) {
        if (s.search(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/) != -1)
            return this.setState;
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
        let userIsValid = this.checkUserValid(this.state.user);
        let passwordIsValid = this.checkPasswordValid(this.state.password);
        if (userIsValid & passwordIsValid) {
            //do authorize
        }
        else {
            this.setState({ userIsValid: userIsValid, passwordIsValid: passwordIsValid });
        }
    }

    render() {
        return (
            <form>
                <div>
                    <input name="user" type="text" value={this.state.user} onChange={this.onUserChange} />
                    {!this.state.userIsValid && <span style={{color: "red"}} >{this.userIsInvalidMessage}</span>}
                </div>
                <div>
                    <input name="password" type="password" value={this.state.password} onChange={this.onPasswordChange}/>
                    {!this.state.passwordIsValid && <span style={{color: "red"}}>{this.passwordIsInvalidMessage}</span>}
                </div>
                <div>
                    <input name="send" type="submit" value="Войти" onClick={this.onSubmit} />
                </div>
            </form>
        );
    }
}

export default Login;