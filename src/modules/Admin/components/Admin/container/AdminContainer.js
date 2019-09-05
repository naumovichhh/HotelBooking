import React from 'react';
import { connect } from 'react-redux';
import Admin from '../component/Admin';
import AdminService from '../../../services/AdminService';

class AdminContainer extends React.Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        AdminService.fetchHotels();
    }

    render() {
        return <Admin hotelsList={this.props.list} fulfilled={this.props.fulfilled} />;
    }
}

const mapStateToProps = (state) => ({ ...state.hotels });

export default connect(mapStateToProps)(AdminContainer);