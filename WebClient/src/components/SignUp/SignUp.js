import { useState } from "react";
import { Col, Button, Row, Container, Card, Form } from "react-bootstrap";
import './SignUp.css'
export default function SignUp() {
      
    return (
        <div class="row" className="baseSignUp">
           <div class="col-10">
                <Card class="shadow w-50 p-3 mb-5 bg-white rounded" className="shadowSignUp">
                    <Card.Body className="cardBody">
                        <h2 className="fw-bold mb-2 text-uppercase ">SIGN UP</h2>
                        <h4 className="info">Please enter needed information</h4>
                        <Form>
                            <Row>
                            <Col className="col-6">
                                <Form.Group className="mb-3" controlId="formBasicEmail">
                                    <Form.Label className="label">
                                        Name
                                    </Form.Label>
                                    <Form.Control />
                                </Form.Group>
                                <Form.Group className="mb-3" controlId="formBasicEmail">
                                    <Form.Label className="label">
                                        Date of Birth
                                    </Form.Label>
                                    <Form.Control placeholder="GG-AA-YYYY"/>
                                </Form.Group>
                                <Form.Group className="mb-3" controlId="formBasicEmail">
                                    <Form.Label className="label">
                                        Address
                                    </Form.Label>
                                    <Form.Control />
                                </Form.Group>
                                <Form.Group
                                    className="mb-3"
                                    controlId="formBasicPassword"
                                >
                                    <Form.Label>Password</Form.Label>
                                    <Form.Control type="password" />
                                </Form.Group>
                            </Col>
                            <Col className="col-6">
                            <Form.Group className="mb-3" controlId="formBasicEmail">
                                    <Form.Label className="label">
                                        Surname
                                    </Form.Label>
                                    <Form.Control />
                                </Form.Group>
                                <Form.Group className="mb-3" controlId="formBasicEmail">
                                    <Form.Label className="label">
                                        Email address
                                    </Form.Label>
                                    <Form.Control type="email" />
                                </Form.Group>
                                <Form.Group className="mb-3" >
                                    <Form.Label className="label">
                                        Phone Number
                                    </Form.Label>
                                    <Form.Control type="phone" placeholder="(5**)*** ** **"/>
                                </Form.Group>
                                
                                <Form.Group
                                    className="mb-3"
                                    controlId="formBasicPassword"
                                >
                                    <Form.Label>Password</Form.Label>
                                    <Form.Control type="password" />
                                </Form.Group>

                            </Col>
                            </Row>
                               <div class="row">
                                 <input class="col-sm" className="accept-box" type="checkbox"/>
                                 <p class="col-sm" className="accepted">I accept the terms and conditions.</p>
                                </div>
                                <div className="d-grid">
                                <Button id="signup-button" type="submit">
                                    Register
                                </Button>
                                
                            </div>
                            
                        </Form>

                    </Card.Body>
                </Card>
                
         </div>
        </div>
    );
    
}