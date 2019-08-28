import React from 'react';

function Login() {
    if (this.state.showWrongCredentials)
        return this.wrongCredentials();
    else
        return this.form();
}