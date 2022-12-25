import { useState } from "react";
import { Col, Button, Row, Container, Card, Form } from "react-bootstrap";
import './SignUp.css'
import NavbarComponent from '../../components/NavbarComponent/NavbarComponent'
import Footer from '../../components/Footer/Footer'


export default function SignUp() {
      
    return (
        <div>
       <NavbarComponent/>
        <div class="row" className="baseSignUp">
           <div class="col-10">
                <Card class="shadow w-50 p-3 mb-5 bg-white rounded" className="shadowSignUp">
                    <Card.Body className="cardBody">
                        <h2 className="fw-bold mb-2 text-uppercase ">SIGN UP</h2>
                        <h4 className="info">Please enter needed information</h4>
                        <Form className="form-signup">
                            <Row>
                            <Col className="col-6">
                                <Form.Group className="mb-3" controlId="formBasic">
                                    <Form.Label className="labelSignup">
                                        Name
                                    </Form.Label>
                                    <Form.Control className="inputs" />
                                </Form.Group>
                                <Form.Group className="mb-3" controlId="formBasic">
                                    <Form.Label  className="labelSignup">
                                        Date of Birth
                                    </Form.Label >
                                    <Form.Control className="inputs" placeholder="GG-AA-YYYY"/>
                                </Form.Group>
                                <Form.Group className="mb-3" controlId="formBasic">
                                    <Form.Label  className="labelSignup">
                                        Address
                                    </Form.Label>
                                    <Form.Control className="inputs" />
                                </Form.Group>
                                <Form.Group
                                    className="mb-3"
                                    controlId="formBasicPassword"
                                >
                                    <Form.Label  className="labelSignup" >Password</Form.Label>
                                    <Form.Control className="inputs" type="password" />
                                </Form.Group>
                            </Col>
                            <Col className="col-6">
                            <Form.Group className="mb-3" controlId="formBasic">
                                    <Form.Label  className="labelSignup">
                                        Surname
                                    </Form.Label>
                                    <Form.Control className="inputs"/>
                                </Form.Group>
                                <Form.Group className="mb-3" controlId="formBasic">
                                    <Form.Label  className="labelSignup">
                                        Email address
                                    </Form.Label>
                                    <Form.Control className="inputs" type="email" />
                                </Form.Group>
                                <Form.Group className="mb-3" >
                                    <Form.Label  className="labelSignup">
                                        Phone Number
                                    </Form.Label>
                                    <Form.Control className="inputs" type="phone" placeholder="(5**)*** ** **"/>
                                </Form.Group>
                                
                                <Form.Group
                                    className="mb-3"
                                    controlId="formBasicPassword"
                                >
                                    <Form.Label  className="labelSignup">Password</Form.Label>
                                    <Form.Control className="inputs" type="password" />
                                </Form.Group>

                            </Col>
                            </Row>
                               <div class="row">
                               <Form.Check className = "text-start" type="checkbox" label="I accept the terms and conditions." />
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
         <Footer/>
        </div>
      
        </div>
        
    );
    
}