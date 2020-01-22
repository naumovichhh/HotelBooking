import { combineReducers } from 'redux';
import auth from './auth';
import hotels from './hotels';
import search from './search';

export default combineReducers({
    auth,
    hotels,
    search
});