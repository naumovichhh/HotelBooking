import React from 'react';
import { connect } from 'react-redux';
import Admin from '../../../modules/Admin/components/component/Admin';

class AdminContainer extends React.Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        this.props.dispatch();
    }

    render() {
        let hotelsList = this.props.hotelsList;
        return <Admin hotelsList={hotelsList}/>;
    }
}

const mapStateToProps = (state) => { state.hotels };

export default connect(mapStateToProps)(AdminContainer);