import { Form, Card, Button } from 'react-bootstrap';
import './ForumPage.css'
import CloseButton from 'react-bootstrap/CloseButton';
import { ReactionBarSelector } from '@charkour/react-reactions';
import { MdEdit } from 'react-icons/md';
import NavbarComponent from '../../components/NavbarComponent/NavbarComponent'
import Footer from '../../components/Footer/Footer'

export default function ForumPage() {
    return (
        <div id="containAll">

            <NavbarComponent/>
            <div className="left-comments">

                <Card className="contain-comments">
                    <h1 className='comments-header'>Lesson name</h1>
                    <h4 className='comments-header2'>Comments for the lesson</h4>
                    <div class="container">
                        <div class="be-comment-block">
                        <a href="#"><MdEdit className="editButton" size={20}></MdEdit></a>
                        <CloseButton className="closeButton"></CloseButton>
                            <div class="be-comment">
                                <div class="be-img-comment">
                                    <a href="blog-detail-2.html">
                                        <img src="https://bootdey.com/img/Content/avatar/avatar1.png" alt="photo" class="be-ava-comment" />
                                    </a>
                                </div>
                                <div class="be-comment-content">

                                    <span class="be-comment-name">
                                        <a href="blog-detail-2.html">Ravi Sah</a>
                                    </span>
                                    <span class="be-comment-time">
                                        <i class="fa fa-clock-o"></i>
                                        May 27, 2015 at 3:14am
                                    </span>

                                    <p class="be-comment-text">
                                    
                                        Pellentesque gravida tristique ultrices.
                                        Sed blandit varius mauris, vel volutpat urna hendrerit id.
                                        Curabitur rutrum dolor gravida turpis tristique efficitur.
                                    </p>
                                    <ReactionBarSelector iconSize={20}/>
                                </div>
                            </div>
                        </div>
                        <div class="be-comment-block">
                        <CloseButton className="closeButton"></CloseButton>

                            <div class="be-comment">
                                <div class="be-img-comment">
                                    <a href="blog-detail-2.html">
                                        <img src="https://bootdey.com/img/Content/avatar/avatar2.png" alt="" class="be-ava-comment" />
                                    </a>
                                </div>
                                <div class="be-comment-content">
                                    <span class="be-comment-name">
                                        <a href="blog-detail-2.html">Phoenix, the Creative Studio</a>
                                    </span>
                                    <span class="be-comment-time">
                                        <i class="fa fa-clock-o"></i>
                                        May 27, 2015 at 3:14am
                                    </span>
                                    <p class="be-comment-text">
                                        Nunc ornare sed dolor sed mattis. In scelerisque dui a arcu mattis, at maximus eros commodo. Cras magna nunc, cursus lobortis luctus at, sollicitudin vel neque. Duis eleifend lorem non ant. Proin ut ornare lectus, vel eleifend est. Fusce hendrerit dui in turpis tristique blandit.
                                    </p>
                                    <ReactionBarSelector iconSize={20}/>

                                </div>
                            </div>


                        </div>

                    </div>
                </Card>

            </div>
            <div className='right-comments'>
                <Card className="contain-forum">
                    <h1 className='form-header'>Leave Comment</h1>
                    <h4 className='form-header2'>Start a discussion!</h4>
                    <br></br><br></br>

                    <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">Title</label>
                        <input class="form-control" id="exampleFormControlInput1" placeholder="Please enter the title of your comment" />
                    </div>
                    <div class="mb-3">
                        <label for="exampleFormControlTextarea1" class="form-label">Comment</label>
                        <textarea class="form-control" id="exampleFormControlTextarea1" rows="3" placeholder='Your comment'></textarea>
                    </div>

                    <label class="form-label" for="customFile">Upload Image</label>
                    <input type="file" class="form-control" id="customFile" />
                    <br></br><br></br>
                    <Button className='comment-button'>
                        Comment
                    </Button>

                </Card>

            </div>
            <Footer/>
        </div>
     
        




    );

}