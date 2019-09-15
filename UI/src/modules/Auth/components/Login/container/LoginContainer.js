import React from 'react';
import Login from '../component/Login';
import { connect } from 'react-redux';
import LoginService from '../../../services/LoginService';
import { Redirect } from 'react-router-dom';

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

    render() {
        if (this.props.auth.authorized) {
            if (this.props.auth.user.role === "admin") {
                return <Redirect to="/admin" />;
            }
            else
                return <Redirect to="/catalog" />;            
        }

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