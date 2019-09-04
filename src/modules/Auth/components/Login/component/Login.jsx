import React from 'react';

class Login extends React.Component {
    form() {
        return (
            <form style={{marginLeft: "10px", marginRight: "10px", marginTop: "20px", minWidth: "760px"}} role="form" className="form form-signin col-9" >
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

    wrongCredentials() {
        return <React.Fragment>
            <span>Wrong credentials!</span>
            <button className="btn btn-secondary" onClick={this.onTryAgainClick} >Try again</button>
        </React.Fragment>
    }

    render() {
        return <div>
        </div>;
    }
}

export default Login;