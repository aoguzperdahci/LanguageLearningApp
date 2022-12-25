
import './Lesson.css'
import { useNavigate, useParams } from "react-router-dom";
import { MdOutlineArrowDownward } from 'react-icons/md'
import { getSingleLesson } from '../../redux/LessonSlice';

import NavbarComponent from '../../components/NavbarComponent/NavbarComponent'
import Footer from '../../components/Footer/Footer'
import { useDispatch, useSelector } from 'react-redux';
import { useEffect, useLayoutEffect } from 'react';
export const LessonDetailPage = () => {
    const lesson = useSelector(state => state.lesson);
    const source = ()=>{
        return lessonId === 34 ? "http://3.bp.blogspot.com/-u-byxR6mtDw/UyidxzYeDMI/AAAAAAAABBU/80rsehSVHpY/s1600/perfect+continuous+tense+GENEL+TABLO.png":
        (lessonId===35? "https://st.adda247.com/https://s3-ap-south-1.amazonaws.com/adda247jobs-wp-assets-adda247/jobs/wp-content/uploads/sites/2/2022/08/27163530/Past-Perfect-Continuous-Tense.jpg":null);
    }
    let navigate = useNavigate();
    const routeChange = (path) => {
        path = "/" + path;
        navigate(path);
    }
    const handleForumClick = () => {
        routeChange("forum");
    }
    const handleExamClick = () => {
        routeChange("exam")
    }
    let { lessonId } = useParams();
    const dispatch = useDispatch();
    useEffect(() => {
        dispatch(getSingleLesson(lessonId));
        document.getElementById("lessonContent").innerHTML=lesson.chosenLesson.lessonContent
    }, [lessonId,lesson.chosenLesson]);

    return (
        <div>

            <div className="lesson-content">
                <NavbarComponent />
                <p>{lessonId}</p>
                <div className="content">
                    <h1 className='lesson-title'>{lesson.chosenLesson.name}</h1>
                    <img id="content-image" src={source}/>
                    <p id="lessonContent" className='lessonContents'>
                    
                    </p>
                </div>
                <p id="question">Do you have a question or a comment?</p>
                <MdOutlineArrowDownward size={32} id="arrow"></MdOutlineArrowDownward>
                <button id="forum-button" onClick={handleForumClick}>Forum</button>
                <button id="exam-button" onClick={handleExamClick}>Take Exam!</button>
                <div class="m-4" >
                    <div class="btn-group">
                        <button id='dropdownMenu' type="button" class="btn dropdown-toggle" data-bs-toggle="dropdown">
                            Exercises<span class="caret" style={{ color: 'white' }}></span>
                        </button>
                        <div class="dropdown-menu">
                            <a class="dropdown-item" href="#">Listening Exercise</a>
                            <a class="dropdown-item" href="#">Speaking Exercise</a>
                            <a class="dropdown-item" href="#">Reading Exercise</a>
                            <a class="dropdown-item" href="#">Writing Exercise</a>
                            <a class="dropdown-item" href="#">Pronounciation Exercise</a>
                            <a class="dropdown-item" href="#">Grammer Exercise</a>
                        </div>
                    </div>
                </div>

            </div>
            <Footer />
        </div>



    );

}