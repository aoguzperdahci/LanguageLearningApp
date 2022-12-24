import React from 'react';
import { Card, Col, Container, Row } from 'react-bootstrap';
import NavbarComponent from '../../components/NavbarComponent/NavbarComponent';
import './InboxPage.css';

const InboxPage = () => {
    return (
        <>
        <NavbarComponent></NavbarComponent>
        <Container fluid>
            <Row className="inbox-row">

                <Col md={4} className="inbox-message-list">
                    <Card className="mt-2 inbox-message-card">
                        <Card.Body>
                            <Card.Title>New Feedback</Card.Title>
                            <Card.Text className="text-start">
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad ...
                            </Card.Text>
                        </Card.Body>
                    </Card>

                </Col>

                <Col md={8} className="d-none d-md-block inbox-message-detail">
                    <p className="fs-3 mt-2 inbox-message-title">New Feedback</p>
                    <p className="fs-5 text-start inbox-message-body">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                    </p>
                    <p className="fs-5 text-start inbox-message-body">
                        Scelerisque felis imperdiet proin fermentum leo vel. Amet risus nullam eget felis. Amet justo donec enim diam vulputate ut. Massa ultricies mi quis hendrerit dolor magna eget. Massa eget egestas purus viverra. Non pulvinar neque laoreet suspendisse interdum consectetur libero id. Ultrices eros in cursus turpis massa tincidunt dui. Sociis natoque penatibus et magnis dis parturient montes nascetur. Magna fringilla urna porttitor rhoncus dolor purus. Phasellus vestibulum lorem sed risus ultricies tristique nulla aliquet. Massa sed elementum tempus egestas sed sed. A erat nam at lectus urna duis convallis convallis tellus. Nunc mi ipsum faucibus vitae aliquet nec ullamcorper sit amet.
                    </p>
                </Col>

            </Row>
        </Container>
        </>
    )
}

export default InboxPage