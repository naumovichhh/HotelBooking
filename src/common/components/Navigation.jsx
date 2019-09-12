import React from 'react';
import { Navbar, Nav } from 'react-bootstrap';

const Navigation = () => <Navbar bg="primary" className="justify-content-between" >
    <Navbar.Brand>Booking Machine</Navbar.Brand>
    <Nav className="mr-auto" >
        <Nav.Item>
            <Nav.Link href="/home" >Home</Nav.Link>
        </Nav.Item>
        <Nav.Item>
            <Nav.Link href="/about" >About</Nav.Link>
        </Nav.Item>
    </Nav>
    <Nav>
        <Nav.Item>
            <Nav.Link href="/login" >Log in</Nav.Link>
        </Nav.Item>
    </Nav>
</Navbar>;

export default Navigation;