import React from 'react';
import Admin from '../component/Admin';

class AdminContainer extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        let hotelsList = this.props.hotelsList;
        return <Admin hotelsList={hotelsList}/>;
    }
}

export default AdminContainer;