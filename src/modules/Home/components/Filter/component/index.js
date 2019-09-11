import React from 'react';
import { Form } from 'react-bootstrap';

function Filter(props) {
    return <Form>
        <Form.Group controlId="country" >
            <Form.Label>Country</Form.Label>
            <Form.Control type="text" />
        </Form.Group>
        <Form.Group controlId="locality" >
            <Form.Label>Locality</Form.Label>
            <Form.Control type="text" />
        </Form.Group>
        <Form.Group controlId="from" >
            <Form.Label>From</Form.Label>
            <Form.Control type="date" ></Form.Control>
        </Form.Group>
        <Form.Group controlId="to" >
            <Form.Label>To</Form.Label>
            <Form.Control type="date" ></Form.Control>
        </Form.Group>
    </Form>
}

export default Filter;