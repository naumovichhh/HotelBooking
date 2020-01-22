import React from 'react';
import { Navbar, Nav } from 'react-bootstrap';

const Navigation = (props) => <Navbar bg="primary" className="justify-content-between" >
    <Navbar.Brand>Booking Machine</Navbar.Brand>
    <Nav className="mr-auto" >
        {props.auth.authorized && props.auth.user.role === "admin" && <Nav.Item>
            <Nav.Link href="" eventKey="admin" onSelect={props.onSelect} >Admin</Nav.Link>
        </Nav.Item>
        }
        <Nav.Item>
            <Nav.Link href="" eventKey="home" onSelect={props.onSelect} >Home</Nav.Link>
        </Nav.Item>
        <Nav.Item>
            <Nav.Link href="" eventKey="about" onSelect={props.onSelect} >About</Nav.Link>
        </Nav.Item>
    </Nav>
    <Nav>
        <Nav.Item>
            <Nav.Link href="" eventKey="login" onSelect={props.onSelect} >Log in</Nav.Link>
        </Nav.Item>
    </Nav>
</Navbar>;

export default Navigation;