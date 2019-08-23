import React from 'react';
import hotels from './hotels.json';

class Admin extends React.Component {
    constructor(props) {
        super(props);

    }

    renderHotelsList() {
        let list = hotels.hotels.map((e) =>
        <li key={e.name} className="list-group-item">
            <h4>{e.name}</h4>
            <ul>
                <li key="country">{e.country}</li>
                <li key="locality">{e.locality}</li>
                <li key="address">{e.address}</li>
            </ul>
        </li>
        );
        return <ul className="list-group" >{list}</ul>;
    }

    render() {
        return <div className="col-8" style={{minWidth: "700px"}} >
            {this.renderHotelsList()}
        </div>
    }
}

export default Admin;