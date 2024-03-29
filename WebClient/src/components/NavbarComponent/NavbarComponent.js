import React from 'react';
import { Button, Container, Nav, Navbar, NavDropdown } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import { NavLink } from 'react-router-dom';
import { MdLogout, MdPersonOutline } from "react-icons/md"
import "./NavbarComponent.css"
import { setUser } from '../../redux/UserSlice';

const NavbarComponent = () => {
    const user = useSelector(state => state.user);
    const dispatch = useDispatch();

    const renderNavigation = () => {
        let navigation = <></>;

        switch (user.role) {
            case "student":
                navigation = (
                    <>
                        <NavLink to="/lessons">
                            <Button className="navbar-button-default me-1">Lessons</Button>
                        </NavLink>
                        <NavLink to="/personal-tutor">
                            <Button className="navbar-button-default me-1">Personal Tutor</Button>
                        </NavLink>
                        <NavLink to="/inbox">
                            <Button className="navbar-button-default me-1">Inbox</Button>
                        </NavLink>
                    </>);
                break;
            case "teacher":
                navigation = (
                    <>
                        <NavLink to="/tutoring">
                            <Button className="navbar-button-default me-1">Tutor a Student</Button>
                        </NavLink>
                        <NavLink to="/evaluate-exercise">
                            <Button className="navbar-button-default me-1">Evaluate Exercise</Button>
                        </NavLink>
                    </>);
                break;
            case "admin":
                navigation = (
                    <>
                        <NavLink to="/edit-lessons">
                            <Button className="navbar-button-default me-1">Edit Lessons</Button>
                        </NavLink>
                    </>);

                break;
            default:
                break;
        }

        return navigation
    }

    const renderLoginState = () => {
        let loginState = <></>;

        if (user.name) {
            loginState = (
                <>
                    <NavDropdown title={user.name} id="collasible-nav-dropdown">
                        <NavDropdown.Item className="default">
                            <NavLink to="/account">
                                <MdPersonOutline className="me-1 fs-5 icon"></MdPersonOutline>
                                Account
                            </NavLink>
                        </NavDropdown.Item>
                        <NavDropdown.Divider />
                        <NavDropdown.Item className="red" onClick={() => handleLogout()}>
                            <NavLink to="/">
                                <MdLogout className="me-1 fs-5 icon"></MdLogout>
                                Log out
                            </NavLink>
                        </NavDropdown.Item>
                    </NavDropdown>

                </>);
        } else {
            loginState = (
                <>
                    <NavLink to="/signup">
                        <Button className="navbar-button-light me-2 px-4">Sign up</Button>
                    </NavLink>
                    <NavLink to="/login">
                        <Button className="navbar-button-dark px-4">Log in</Button>
                    </NavLink>
                </>);
        }

        return loginState;
    }

    const handleLogout = () => {
        dispatch(setUser({ id: 0, name: null, role: null }));
    }

    return (
        <Navbar collapseOnSelect expand="lg" sticky="top">
            <Container>
                <NavLink to="/">
                    <Navbar.Brand className="me-5">LLA</Navbar.Brand>
                </NavLink>
                <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                <Navbar.Collapse id="responsive-navbar-nav" className="justify-content-between">
                    <Nav>
                        {user.role && renderNavigation()}
                    </Nav>

                    <Nav>
                        {renderLoginState()}
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}

export default NavbarComponent