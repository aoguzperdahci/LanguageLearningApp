
import './Lesson.css'
import { useNavigate } from "react-router-dom";
import { MdOutlineArrowDownward } from 'react-icons/md'
export const LessonDetailPage = () => {
    let navigate = useNavigate(); 
    const routeChange = (path) =>{ 
      path = "/" + path; 
      navigate(path);
    }
    const handleForumClick=()=>{
        routeChange("forum");
    }
    return (
        <div className="lesson-content">
            <div className="content">
                <h1 className='lesson-title'>Dersin Adı</h1>
                <p className='lessonContents'>CONTENT</p>
            </div>
            <p id="question">Do you have a question or a comment?</p>
            <MdOutlineArrowDownward size={32} id="arrow"></MdOutlineArrowDownward>
            <button id="forum-button" onClick={handleForumClick}>Forum</button>
            <button id="exam-button">Take Exam!</button>
            <div class="m-4" >
                <div class="btn-group">
                    <button id='dropdownMenu' type="button" class="btn dropdown-toggle" data-bs-toggle="dropdown">
                        Exercises<span class="caret" style={{color:'white'}}></span>
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

    );

}