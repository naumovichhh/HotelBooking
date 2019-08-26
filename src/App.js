import React from 'react';
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom';
import Login from './Login';
import Home from './Home';
import Admin from './modules/Admin/components/Admin';
import AuthorizedRoute from './AuthorizedRoute';

function App() {
    return (
        <BrowserRouter>
            <Switch>
                <Route exact path="/home" component={Home} />
                <Route exact path="/login" component={Login} />
                <AuthorizedRoute exact role="admin" path="/edit" component={Admin} />
                <Redirect exact from="/" to="home" />
                <Route component={NoMatch} />
            </Switch>
        </BrowserRouter>
    );
}

function NoMatch() {
    return <div>Not found</div>;
}

export default App;
