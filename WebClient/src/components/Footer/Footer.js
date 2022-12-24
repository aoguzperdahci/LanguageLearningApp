import { MDBFooter, MDBContainer, MDBRow, MDBCol, MDBIcon } from 'mdb-react-ui-kit';
import './Footer.css'
export default function Footer(){
    return(
        <div className='footer'>
<MDBFooter bgColor='dark' className='text-center text-lg-start text-muted'>
    
      <section className=''>
        <MDBContainer className='text-center text-md-start mt-5'>
          <MDBRow className='mt-3'>
            <MDBCol md='2' lg='2' xl='2' className='mx-auto mb-4'>
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
            </MDBCol>

            <MDBCol md='2' lg='2' xl='2' className='mx-auto mb-4'>
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
            </MDBCol>

            <MDBCol md='3' lg='2' xl='2' className='mx-auto mb-4'>
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
              
            </MDBCol>

            <MDBCol md='4' lg='3' xl='3' className='mx-auto mb-md-0 mb-4'>
              <h6 className='text-uppercase fw-bold mb-4'>SOCIAL MEDIA</h6>
           
            </MDBCol>
          </MDBRow>
        </MDBContainer>
      </section>

      <div className='text-center p-4' style={{ backgroundColor: 'rgba(0, 0, 0, 0.05)' }}>
        © 2022 All rights reserved.
        
      </div>
    </MDBFooter>
   
        </div>
    );
}