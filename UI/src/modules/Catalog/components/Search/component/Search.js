import React from 'react';
import { Form, Col, Row, Button } from 'react-bootstrap';
import Select from 'react-select';
import FastSelect from 'common/components/FastSelect';

function Search(props) {
    let countries = Object.keys(props.localities).map(c => ({ value: c, label: c }));
    let localities = props.localities[props.country] && Array.from(new Set(props.localities[props.country])).map(l => ({ value: l, label: l }));
    return <div style={{ backgroundColor: "rgb(180, 180, 180)", padding: "10px 10px" }}>
        <Form >
            <Row>
                <Form.Group as={Col} controlId="country" >
                    <Form.Label>Country</Form.Label>
                    <Select value={{ label: props.country, value: props.country }} onChange={props.onCountryChange} options={countries} />
                </Form.Group>
                <Form.Group as={Col} controlId="locality" >
                    <Form.Label>Locality</Form.Label>
                    <FastSelect value={{ label: props.locality, value: props.locality }} onChange={props.onLocalityChange} options={localities} />
                </Form.Group>
            </Row>
            <Row>
                <Form.Group as={Col} controlId="from" >
                    <Form.Label>From</Form.Label>
                    <Form.Control type="date" onChange={props.onFromChange} value={props.from} />
                </Form.Group>
                <Form.Group as={Col} controlId="to" >
                    <Form.Label>To</Form.Label>
                    <Form.Control type="date" onChange={props.onToChange} value={props.to} />
                </Form.Group>
            </Row>
            <Row>
                <Form.Group as={Col} controlId="adult" >
                    <Form.Label>Adult places</Form.Label>
                    <Form.Control type="number" onChange={props.onAdultChange} value={props.adult} />
                </Form.Group>
                <Form.Group as={Col} controlId="child" >
                    <Form.Label>Child places</Form.Label>
                    <Form.Control type="number" onChange={props.onChildChange} value={props.child} />
                </Form.Group>
            </Row>
            <Button variant="primary" onClick={props.onSubmit} >
                Search
            </Button>
        </Form>
    </div>
}

export default Search;