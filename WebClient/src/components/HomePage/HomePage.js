import { Button } from 'react-bootstrap';
import './HomePage.css';


export default function HomePage() {
    return (

        <div>
            <div className="left">
                <h1 className='header'>
                    Learn Languages <br></br>
                    As Easy As Possible !
                </h1>
                <p className='explain'>
                    With the help of LLA you can not imagine how fast you can learn the language. <br></br>Let's give it a try.
                </p>
                <div class="container">

                    <div class="row" id='content'>
                        <div class="col-md-4">
                            <h4>
                                Tutor Support
                            </h4>
                            <p> Chance to get help from tutor via video call anytime.</p>
                        </div>
                        <div class="col-md-4">
                            <h4>
                                Diverse Exercises
                            </h4>
                            <p>After every lesson, opportunity yo take 6 different type of exercises.</p>
                        </div>
                        <div class="col-md-4">
                            <h4>
                                Discussion Forum
                            </h4>
                            <p> Chance to discuss topics with other users.</p>
                        </div>
                    </div>
                </div>
            </div>
            <div className='right'>


            </div>
        </div>


    );
}