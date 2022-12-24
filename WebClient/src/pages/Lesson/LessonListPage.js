import { Card } from 'react-bootstrap'
import { useEffect} from 'react';
import './Lesson.css';
import { useDispatch, useSelector } from 'react-redux';
import { getAllLessons, getCurrentLesson } from '../../redux/LessonSlice';

export const LessonListPage =()=>{
    const lessonList =  useSelector(state => state.lesson);
    const student = useSelector(state=>state.user);

    const dispatch = useDispatch();
    useEffect(()=>{
        dispatch(getAllLessons());
        dispatch(getCurrentLesson(student.id))
    }, []);

    return (
        <div>
            <Card className="listCard">
                <ul class="list-group list-group-flush">
                    {lessonList?.map(item => (
                        <li key={item.Id} class="list-group-item">
                            <a href={item.url}>{item.Name}</a>
                            </li>
                    ))}
                </ul>

            </Card>


        </div>
    );
} 





    