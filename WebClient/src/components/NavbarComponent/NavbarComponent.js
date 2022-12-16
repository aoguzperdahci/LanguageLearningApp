import React from 'react';
import { Button, Container, Nav, Navbar, NavDropdown } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import { NavLink } from 'react-router-dom';

const NavbarComponent = () => {
    const user = useSelector(state => state.user);
    const dispacth = useDispatch();

    const renderNavigation = () => {
        let navigation = <></>;

        switch (user.role) {
            case "student":
                navigation = (
                    <>
                        <NavLink>
                            <Button>Lessons</Button>
                        </NavLink>
                        <NavLink>
                            <Button>Personal Tutor</Button>
                        </NavLink>
                        <NavLink>
                            <Button>Inbox</Button>
                        </NavLink>
                    </>);
                break;
            case "teacher":
                navigation = (
                    <>
                        <NavLink>
                            <Button>Tutor a Student</Button>
                        </NavLink>
                        <NavLink>
                            <Button>Evaluate Exercise</Button>
                        </NavLink>
                    </>);
                break;
            case "admin":
                navigation = (
                    <>
                        <NavLink>
                            <Button>Edit Lessons</Button>
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
                        <NavDropdown.Item>Account</NavDropdown.Item>
                        <NavDropdown.Divider />
                        <NavDropdown.Item>Log out</NavDropdown.Item>
                    </NavDropdown>

                </>);
        } else {
            loginState = (
                <>
                    <NavLink>
                        <Button>Sign up</Button>
                    </NavLink>
                    <NavLink>
                        <Button>Log in</Button>
                    </NavLink>
                </>);
        }

        return loginState;
    }

    return (
        <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark" fixed="top">
            <Container>
                <Navbar.Brand href="#home">LLA</Navbar.Brand>
                <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                <Navbar.Collapse id="responsive-navbar-nav" className="justify-content-end">
                    <Nav>
                        {user.role && renderNavigation()}
                        {renderLoginState()}
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}

export default NavbarComponent