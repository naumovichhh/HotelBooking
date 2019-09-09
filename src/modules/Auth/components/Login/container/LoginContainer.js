import React from 'react';
import Login from '../component/Login';
import { connect } from 'react-redux';
import LoginService from '../../../services/LoginService';

class LoginContainer extends React.Component {
    constructor(properties) {
        super(properties);
        this.state = { login: "", password: "", loginIsValid: true, passwordIsValid: true };
    }

    onUserChange = (e) => {
        this.setState({ login: e.target.value });
    }

    onPasswordChange = (e) => {
        this.setState({ password: e.target.value });
    }

    onSubmit = (e) => {
        e.preventDefault();
        let loginIsValid = LoginService.validateLogin(this.state.login);
        let passwordIsValid = LoginService.validatePassword(this.state.password);
        if (loginIsValid & passwordIsValid) {
            LoginService.login(this.props.history, { login: this.state.login, password: this.state.password } );

        }
        else {
            this.setState({ loginIsValid, passwordIsValid });
        }
    }

    logIn() {
        let login = this.state.login, password = this.state.password;
        let authorization = this.props.auth;
        this.props.authorize();
        if (authorization.authorize(login, password)) {
            if (authorization.currentAccount.role === 'admin')
                this.props.history.push('/edit');
            else
                this.props.history.push('/home');
        }
        else
            this.setState({ wrongCredentials: true });
    }

    render() {
        console.log(this.props);
        return <Login wrong={this.props.auth.failed}
            loginIsValid={this.state.loginIsValid}
            passwordIsValid={this.state.passwordIsValid}
            onSubmit={this.onSubmit}
            onUserChange={this.onUserChange}
            onPasswordChange={this.onPasswordChange}
            authorized={this.props.auth.authorized}
            inProcess={this.props.auth.inProcess}
        />
    }
}

const mapStateToProps = (state) => {
    return { auth: state.auth }
}

export default connect(mapStateToProps)(LoginContainer);