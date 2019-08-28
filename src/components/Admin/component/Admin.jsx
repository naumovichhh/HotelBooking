import React from 'react';

function Admin({hotelsList: list}) {
    let markupList = list.map((e) =>
    <li key={e.name} className="list-group-item">
        <h4>{e.name}</h4>
        <ul>
            <li key="country">{e.country}</li>
            <li key="locality">{e.locality}</li>
            <li key="address">{e.address}</li>
        </ul>
    </li>
    );
    let ul = <ul className="list-group" >{list}</ul>;
    return <div className="col-8" style={{minWidth: "700px"}} >
        {ul}
    </div>;
}

export default Admin;