import { createStore } from 'redux';
import { reducer } from '../reducers/combinedReducer';

let store = createStore(reducer);

export default store;