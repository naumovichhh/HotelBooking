import React from 'react';
import { Spinner } from 'react-bootstrap';

const Login = (props) => {
    if (props.inProcess)
        return <Spinner animation="border" />;

    const loginIsInvalidMessage = "Login is invalid";
    const passwordIsInvalidMessage = "Password is invalid";
    return (
        <React.Fragment>
            <form style={{ marginLeft: "10px", marginRight: "10px", marginTop: "20px", minWidth: "700px" }} className="form form-signin col-9" >
                <div className="form-group">
                    <input className="form-control col-3" style={{ display: "inline" }} placeholder="Enter username" name="user" type="text" value={props.login} onChange={props.onUserChange} />
                    {!props.loginIsValid ? <span className="col-3" style={{ color: "red" }} >{loginIsInvalidMessage}</span> : <span> </span>}
                </div>
                <div className="form-group">
                    <input className="form-control col-3" style={{ display: "inline" }} placeholder="Enter password" name="password" type="password" value={props.password} onChange={props.onPasswordChange} />
                    {!props.passwordIsValid ? <span className="col-3" style={{ color: "red" }}>{passwordIsInvalidMessage}</span> : <span> </span>}
                </div>
                <div className="form-group">
                    <input className="btn btn-primary" name="send" type="submit" value="Log in" onClick={props.onSubmit} />
                </div>
            </form>
            {props.wrong && <span>Wrong credentials!</span>}
        </React.Fragment>
    );
};

export default Login;