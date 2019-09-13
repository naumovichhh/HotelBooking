import React from 'react';
import { connect } from 'react-redux';
import Hotel from '../component/Hotel';

class HotelContainer extends React.Component {
    render() {
        return <Hotel />;
    }
}

export default connect(() => {})(HotelContainer);