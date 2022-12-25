import { Col, Button, Row, Container, Card, Form } from "react-bootstrap";
import './Login.css'
import NavbarComponent from '../../components/NavbarComponent/NavbarComponent'
import Footer from '../../components/Footer/Footer'
import { useDispatch } from "react-redux";
import { setUser } from "../../redux/UserSlice";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const dispatch = useDispatch();
  let navigate = useNavigate();
    const routeChange = () => {
        let path = '/'
        navigate(path);
    }
  const handleClickStudent = ()=>{
    dispatch(setUser({id:1,name:"student", role:"student"}));
    routeChange();
  }
  const handleClickTeacher = ()=>{
    dispatch(setUser({id:2,name:"teacher", role:"teacher"}))
    routeChange();
  }

  const handleClickAdmin = ()=>{
    dispatch(setUser({id:3,name:"admin", role:"admin"}))
    routeChange();
  }


  return (
    <div className="base">
      <Container>
        <NavbarComponent/>
        <Row className="vh-100 d-flex justify-content-center align-items-center">
          <Col md={8} lg={6} xs={12}>
            
            <Card className="shadow">
              <Card.Body>
                <div className="mb-3 mt-md-4">
                  <h2 className="fw-bold mb-2 text-uppercase ">LOG IN</h2>
                  <p className=" mb-5">Please enter your e-mail and password!</p>
                  <div className="mb-3">
                    <Form>
                      <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label className="text-center">
                          Email address
                        </Form.Label>
                        <Form.Control type="email" placeholder="Enter email" />
                      </Form.Group>

                      <Form.Group
                        className="mb-3"
                        controlId="formBasicPassword"
                      >
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" placeholder="Password" />
                      </Form.Group>
                      <Form.Group
                        className="mb-3"
                        controlId="formBasicCheckbox"
                      >
                        <p className="small">
                          <a className="text-primary" href="#!">
                            Forgot password?
                          </a>
                        </p>
                      </Form.Group>
                      <div className="d-grid">
                        <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#myModal" 
                        id="login-button">
                          Login
                        </button>
                       

                    </div>
                    </Form>
                    <div className="mt-3">
                      <p className="mb-0  text-center">
                        Don't have an account?{" "}
                        <a href="/signUp" className="text-primary fw-bold">
                          Sign Up
                        </a>
                      </p>
                    </div>
                  </div>
                </div>
              </Card.Body>
            </Card>
          </Col>
        </Row>
      </Container>
      <Footer/>
      <div class="modal fade" id="myModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">User Role</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <button style={{backgroundColor:"#d2f1ff", borderColor:"#d2f1ff"}} className="roleButtons" data-bs-dismiss="modal" onClick={handleClickStudent}>Student</button>
              <button style={{backgroundColor:"#3752b4",borderColor:"#3752b4"}} className="roleButtons"data-bs-dismiss="modal" onClick={handleClickTeacher}>Teacher</button>
              <button style={{backgroundColor:"#FFD753",borderColor:"#FFD753"}} className="roleButtons"data-bs-dismiss="modal" onClick={handleClickAdmin}>Admin</button>
      </div>
    </div>
  </div>
</div>
</div>
  );
}