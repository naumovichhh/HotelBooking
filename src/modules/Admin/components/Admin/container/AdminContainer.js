import React from 'react';
import request from './services/dataRequest/request';
import Admin from '../component/Admin';
import AdminService from '../../../services/AdminService';

class AdminContainer extends React.Component {
    constructor(props) {
        super(props);
        this.hotelsList = AdminService.getHotels();
    }

    renderHotelsList() {
        let list = request({
            url: "/service/api",
            method: "GET"
        });
    }

    render() {
        return <Admin hotelsList={this.hotelsList}/>;
    }
}

export default AdminContainer;