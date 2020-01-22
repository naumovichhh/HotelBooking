import React from 'react';
import { Form } from 'react-bootstrap';
import Select from 'react-select';
import FastSelect from 'common/components/FastSelect';

function Search(props) {
    let countries = Object.keys(props.localities).map(c => ({ value: c, label: c }));
    let localities = props.localities[props.country] && Array.from(new Set(props.localities[props.country])).map(l => ({ value: l, label: l }));
    return <div style={{ backgroundColor: "rgb(180, 180, 180)", padding: "10px 10px" }}>
        <Form >
            <Form.Row>
                <Form.Group controlId="country" >
                    <Form.Label>Country</Form.Label>
                    <Select value={{ label: props.country, value: props.country }} onChange={props.onCountryChange} options={countries} />
                </Form.Group>
                <Form.Group controlId="locality" >
                    <Form.Label>Locality</Form.Label>
                    <FastSelect value={{ label: props.locality, value: props.locality }} onChange={props.onLocalityChange} options={localities} />
                </Form.Group>
            </Form.Row>
            <Form.Row>
                <Form.Group controlId="from" >
                    <Form.Label>From</Form.Label>
                    <Form.Control type="date" onChange={props.onFromChange} value={props.from} />
                </Form.Group>
                <Form.Group controlId="to" >
                    <Form.Label>To</Form.Label>
                    <Form.Control type="date" onChange={props.onToChange} value={props.to} />
                </Form.Group>
            </Form.Row>
            <Form.Row>
                <Form.Group controlId="adult" >
                    <Form.Label>Adult places</Form.Label>
                    <Form.Control type="number" onChange={props.onAdultChange} value={props.adult} />
                </Form.Group>
                <Form.Group controlId="child" >
                    <Form.Label>Child places</Form.Label>
                    <Form.Control type="number" onChange={props.onChildChange} value={props.child} />
                </Form.Group>
            </Form.Row>
        </Form>
    </div>
}

export default Search;