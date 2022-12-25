import { useEffect } from 'react';
import './Lesson.css';
import { useDispatch, useSelector } from 'react-redux';
import { getAllLessons, getCurrentLesson } from '../../redux/LessonSlice';
import { NavLink } from 'react-router-dom';


import NavbarComponent from '../../components/NavbarComponent/NavbarComponent'
import Footer from '../../components/Footer/Footer'

export const LessonListPage = () => {
    const lessonList = useSelector(state => state.lesson);
    const student = useSelector(state => state.user);
    const activeLesson = lessonList.activeLesson;
    const listItems = lessonList.lessonList.map((item,index) => {
        return (
          
        <NavLink key= {2000+index} to={"/lessonDetail/"+item.id}>{
        item.id === activeLesson.id ?
          <button key = {5000+index} style={{ backgroundColor: '#8643AE' }} type="button" class="list-group-item list-group-item-action" className='buttonList'>{item.name}</button> 
          :<button key = {5000+index} type="button" class="list-group-item list-group-item-action" className='buttonList'>{item.name}</button> }
        </NavLink>
            );
           
    });

    const dispatch = useDispatch();
    useEffect(() => {
        dispatch(getAllLessons());
        dispatch(getCurrentLesson(student.id))
    }, []);
    return (
     
            
            <div className='contain-list'>
            <NavbarComponent />
                <div class="list-group">
                    <h1 id="list-header">Lessons</h1>
                    {listItems}
                </div>
                <Footer />
            </div>
            
  

    );
}


export default LessonListPage


