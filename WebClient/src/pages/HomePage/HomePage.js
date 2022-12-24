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
                            <img className="content-image" src="https://www.svgrepo.com/show/245856/video-call-webcam.svg"/>
                            <p> Chance to get help from tutor via video call anytime.</p>
                        </div>
                        <div class="col-md-4">
                            <h4>
                                Diverse Exercises
                            </h4>
                            <img className="content-image" src="https://cdn2.iconfinder.com/data/icons/iconustration-education-color/96/basic-education-listening-speaking-writing-reading-512.png"/>
                            <p>After every lesson, opportunity to take 6 different type of exercises.</p>
                        </div>
                        <div class="col-md-4">
                            <h4>
                                Discussion Forum
                            </h4>
<img className="content-image" src="https://thumbs.dreamstime.com/b/speech-bubbles-flat-style-vector-design-shadows-42260864.jpg"/>
                            <p> Chance to discuss topics with other users.</p>
                        </div>
                    </div>
                </div>
            </div>
            <div className='right'>
<img bg="transparent" className= "big-image" src="https://previews.123rf.com/images/melpomen/melpomen1703/melpomen170300709/74615080-language-school-text-with-colorful-illustrations-on-a-yellow-background.jpg"/>

            </div>
        </div>


    );
}