import { connect } from 'react-redux';
import React from 'react';
import Home from '../component/Home';
import HomeService from '../../../services/HomeService';

class HomeContainer extends React.Component {
    componentDidMount() {
        HomeService.fetchHotels();
    }

    render() {
        return <Home hotelsList={this.props.list} fulfilled={this.props.fulfilled} />
    }
}

const mapStateToProps = (state) => ({ ...state.hotels });

export default connect(mapStateToProps)(HomeContainer);