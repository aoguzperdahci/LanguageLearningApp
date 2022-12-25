import { useEffect } from 'react';
import './Lesson.css';
import { useDispatch, useSelector } from 'react-redux';
import { getAllLessons, getCurrentLesson } from '../../redux/LessonSlice';
import { useNavigate } from "react-router-dom";

export const LessonListPage = () => {
    const lessonList = useSelector(state => state.lesson);
    const student = useSelector(state => state.user);
    const activeLesson = lessonList.activeLesson;
    const listItems = lessonList.lessonList.map((item) => {
        return item.id === activeLesson.id ? 
        <button  style={{backgroundColor:'#8643AE'}} type="button" class="list-group-item list-group-item-action" className='buttonList'>{item.name}</button>:
        <button   type="button" class="list-group-item list-group-item-action" className='buttonList'>{item.name}</button>
    });

    let navigate = useNavigate(); 
    const routeChange = (id) =>{ 
      let path = '/lessons/detail?id='+ {id}; 
      navigate(path);
    }
    const onClick=(id)=>{
        {routeChange(id)}
    }
    

    const dispatch = useDispatch();
    useEffect(() => {
        dispatch(getAllLessons());
        dispatch(getCurrentLesson(student.id))
    }, []);
    return (
        <div className='contain-list'>

            <div class="list-group">
                <h1 id="list-header">Lessons</h1>
                {listItems}
            </div>
        </div>
    );
}


export default LessonListPage


