import React from 'react';
import { Button, Col, Row } from 'react-bootstrap';
import { BsFillCameraVideoOffFill, BsFillMicMuteFill, BsGearFill } from 'react-icons/bs';
import "./TutoringPage.css"

const TutoringPage = () => {
    return (
        <div className="d-flex justify-content-center tutoring-page">
            <div className="tutoring-page-center">
                <div className="tutoring-webcam-box">
                    <div className="tutoring-webcam-text">
                        <BsFillCameraVideoOffFill className="fs-2 me-2 mb-1"></BsFillCameraVideoOffFill>
                        <span className="fs-5">Your camera is turned off</span>
                    </div>

                    <Row className="tutoring-webcam-bottom-bar justify-content-center">
                        <Col xs={2} className="form-check form-switch text-start">
                            <BsFillCameraVideoOffFill className="fs-5 align-text-bottom"></BsFillCameraVideoOffFill>
                            <input className="form-check-input" type="checkbox" role="switch" />
                        </Col>

                        <Col xs={2} className="form-check form-switch text-start">
                            <BsFillMicMuteFill className="fs-5 align-text-bottom"></BsFillMicMuteFill>
                            <input className="form-check-input" type="checkbox" role="switch" />
                        </Col>

                        <Col xs={2} className="form-check form-switch text-start">
                            <BsGearFill className="fs-5 align-text-bottom"></BsGearFill>
                        </Col>
                    </Row>
                </div>
                    <Button className="w-100 fs-5 tutoring-page-button">Tutor a Student</Button>
            </div>
        </div>
    )
}

export default TutoringPage