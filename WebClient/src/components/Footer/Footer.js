import { Container, Row, Col } from 'react-bootstrap';
import './Footer.css'
import { BsInstagram,BsFacebook,BsYoutube,BsTwitter } from "react-icons/bs"
export default function FooterComponent(){
    return(
        <div className='footer'>
<div bgColor='dark' className='text-center text-lg-start text-muted'>
    
      <section className=''>
        <Container className='text-center text-md-start mt-5'>
          <Row className='mt-3'>
            <Col md='2' lg='2' xl='2' className='mx-auto mb-4'>
              <h6 className='text-uppercase fw-bold mb-4'>
                
                ABOUT US
              </h6>
              <p>
                <a href='#!' className='text-reset'>
                  Courses
                </a>
              </p>
              <p>
                <a href='#!' className='text-reset'>
                  Events
                </a>
              </p>
              <p>
                <a href='#!' className='text-reset'>
                  Team
                </a>
              </p>
              <p>
                <a href='#!' className='text-reset'>
                  Career 
                </a>
              </p>
            </Col>

            <Col md='2' lg='2' xl='2' className='mx-auto mb-4'>
              <h6 className='text-uppercase fw-bold mb-4'>USEFUL LINKS</h6>
              <p>
                <a href='#!' className='text-reset'>
                  Help
                </a>
              </p>
              <p>
                <a href='#!' className='text-reset'>
                  Resources
                </a>
              </p>
              <p>
                <a href='#!' className='text-reset'>
                  Investment
                </a>
              </p>
              <p>
                <a href='#!' className='text-reset'>
                  FAQ
                </a>
              </p>
            </Col>

            <Col md='3' lg='2' xl='2' className='mx-auto mb-4'>
              <h6 className='text-uppercase fw-bold mb-4'>CONTACT</h6>
              
              <p>
                Bornova / Izmir / TURKEY
              </p>
              <p>
                egebilmuh@ogrenci.ege.com.tr
              </p>
              <p>
               0 (232) 010 01 10
              </p>
              
            </Col>

            <Col md='4' lg='3' xl='3' className='mx-auto mb-md-0 mb-4'>
              <h6 className='text-uppercase fw-bold mb-4'>SOCIAL MEDIA</h6>
              <div class="row">
                <div class='col'>
                <a href='#'><BsFacebook color="#FFFFFF"/></a>
                </div>
                <div class='col'>
                <a href='#'><BsInstagram color="#FFFFFF"/></a>

                </div>
                <div class='col'>
                <a href='#'><BsYoutube color="#FFFFFF"/></a>

                  </div>
                  <div class='col'>
                  <a href='#'><BsTwitter color="#FFFFFF"/></a>

                  </div>
             
              
              </div>
            </Col>
          </Row>
        </Container>
      </section>

      <div className='text-center p-4' style={{ backgroundColor: 'rgba(0, 0, 0, 0.05)' }}>
        © 2022 All rights reserved.
        
      </div>
    </div>
   
        </div>
    );
}