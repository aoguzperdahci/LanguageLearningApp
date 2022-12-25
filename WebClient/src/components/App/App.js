import { BrowserRouter, Routes, Route } from 'react-router-dom';
import ForumPage from '../../pages/Forum/ForumPage';
import HomePage from '../../pages/HomePage/HomePage';
import ExamPage from '../../pages/ExamPage/ExamPage';
import InboxPage from '../../pages/InboxPage/InboxPage';
import PersonalTutorPage from '../../pages/PersonalTutorPage/PersonalTutorPage';
import TutoringPage from '../../pages/TutoringPage/TutoringPage';
import ToastComponent from '../ToastComponent/ToastComponent';
import Login from '../../pages/Login/Login'
import SignUp from '../../pages/SignUp/SignUp'
import './App.css';
import ExamResultPage from '../../pages/ExamResultPage/ExamResultPage';
import LessonListPage from '../../pages/Lesson/LessonListPage';
import { LessonDetailPage } from '../../pages/Lesson/LessonDetailPage';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <Routes>
          <Route index element={<HomePage />}/>
          <Route path="/personal-tutor" element={<PersonalTutorPage></PersonalTutorPage>}></Route>
          <Route path="/inbox" element={<InboxPage></InboxPage>}></Route>
          <Route path="/tutoring" element={<TutoringPage></TutoringPage>}></Route>
          <Route path="/exam" element={<ExamPage></ExamPage>}></Route>
          <Route path="/exam-result" element={<ExamResultPage></ExamResultPage>}></Route>
          <Route path="/forum" element={<ForumPage></ForumPage>}></Route>
          <Route path="/login" element={<Login></Login>}></Route>
          <Route path="/signup" element={<SignUp></SignUp>}></Route>

          <Route element={<LessonListPage></LessonListPage>} path="/lessons">
            
          </Route>
          <Route path="/lessonDetail" element={<LessonDetailPage></LessonDetailPage>}>
          <Route path=":lessonId" element={<LessonDetailPage></LessonDetailPage>}></Route>

          </Route>
        </Routes>
        <ToastComponent />
      </div>
    </BrowserRouter>
  );
}

export default App;
