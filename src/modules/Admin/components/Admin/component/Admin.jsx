import React from 'react';

function Admin(props) {
    let list = props.hotelsList;

    if (props.fulfilled) {
        let markupList = list.map((e) =>
            <li key={e.name} className="list-group-item">
                <h4><a href="path">{e.name}</a></h4>
                <ul>
                    <li key="locality">{e.locality}</li>
                </ul>
            </li>
        );
        let ul = <ul className="list-group" >{markupList}</ul>;
        return <div className="col-8" style={{ minWidth: "700px" }} >
            {ul}
        </div>;
    }
    else {
        return <div>Loading hotels</div>;
    }
}

/*function Admin(props) {
    let list = props.hotelsList;

    if (props.fulfilled) {
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
        let ul = <ul className="list-group" >{markupList}</ul>;
        return <div className="col-8" style={{ minWidth: "700px" }} >
            {ul}
        </div>;
    }
    else {
        return <div>Loading hotels</div>;
    }
}
*/

export default Admin;