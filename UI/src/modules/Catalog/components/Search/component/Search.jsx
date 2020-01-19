import React from 'react';
import { Form } from 'react-bootstrap';
import Select from 'react-select';

function Search(props) {
    return <Form>
        <Form.Row>
            <Form.Group controlId="country" >
                <Form.Label>Country</Form.Label>
                <Select value={{ label: props.country, value: props.country }} onChange={props.onCountryChange} options={props.countries.map(c => ({ value: c, label: c }))} />
            </Form.Group>
            <Form.Group controlId="locality" >
                <Form.Label>Locality</Form.Label>
                <Form.Control type="text" onChange={props.onLocalityChange} value={props.locality} />
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
}

export default Search;