import React from 'react';
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom';
import Login from 'modules/Auth/components/Login';
import Home from 'modules/Home/components/Home';
import Hotel from 'modules/Hotel/components/Hotel';
import Admin from 'modules/Admin/components/Admin';
import About from 'common/components/About';
import Footer from 'common/components/Footer';
import Navigation from 'common/components/Navigation';
import NotFound from 'common/components/NotFound';
import AuthorizedRoute from '../AuthorizedRoute';
import { Provider } from 'react-redux';
import store from 'rdx/store';
import { Container } from 'react-bootstrap';

const App = () => {
    return (
        <Provider store={store} >
            <Navigation />
            <br />
            <Container>
                <BrowserRouter>
                    <Switch>
                        <Route exact path="/home" component={Home} />
                        <Route path="/hotel/:id" component={Hotel} />
                        <Route exact path="/login" component={Login} />
                        <Route exact path="/about" component={About} />
                        <AuthorizedRoute exact role="admin" path="/edit" component={Admin} />
                        <Redirect exact from="/" to="/home" />
                        <Route component={NotFound} />
                    </Switch>
                </BrowserRouter>
            <Footer />
            </Container>
        </Provider>
    );
}

export default App;
