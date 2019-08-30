import React from 'react';
import Login from '../component/Login';
import { connect } from 'react-redux';

class LoginContainer extends React.Component {
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
        let authorization = this.props.auth;
        authService.Logn(cred);
        this.props.authorize();
        if (authorization.authorize(login, password)) {
            if (authorization.currentAccount.role === 'admin')
                this.props.history.push('/edit');
            else
                this.props.history.push('/home');
        }
        else
            this.setState({ showWrongCredentials: true });
    }

    onTryAgainClick = () => {
        this.setState({ showWrongCredentials: false, login: "", password: "" });
    }

    render() {
        if (this.state.showWrongCredentials)
            return this.wrongCredentials();
        else
            return this.form();

            errors || ''
    }
}

const mapStateToProps = (state) => {
    return { auth: state.auth }
}

export default connect(mapStateToProps)(LoginContainer);