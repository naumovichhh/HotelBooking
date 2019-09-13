import store from 'rdx/store';
import { authorize } from '../actions';

class LoginService {
    static validateLogin(s) {
        if (s.search(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/) != -1)
            return true;
        else
            return false;
    }

    static validatePassword(s) {
        if (s.length >= 4)
            return true;
        else
            return false;
    }

    static login(history, credentials) {
        store.dispatch(authorize(credentials));
    }
}

export default LoginService;