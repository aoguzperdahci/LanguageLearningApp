import { BrowserRouter, Routes, Route } from 'react-router-dom';
import HomePage from '../../pages/HomePage/HomePage';
import InboxPage from '../../pages/InboxPage/InboxPage';
import PersonalTutorPage from '../../pages/PersonalTutorPage/PersonalTutorPage';
import TutoringPage from '../../pages/TutoringPage/TutoringPage';
import NavbarComponent from '../NavbarComponent/NavbarComponent';
import ToastComponent from '../ToastComponent/ToastComponent';
import Footer from '../Footer/Footer';
import './App.css';
import LessonListPage from '../../pages/Lesson/LessonListPage';
import { LessonDetailPage } from '../../pages/Lesson/LessonDetailPage';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <NavbarComponent />
        
        <Routes>
          <Route index element={<HomePage />}/>
          <Route path="/personal-tutor" element={<PersonalTutorPage></PersonalTutorPage>}></Route>
          <Route path="/inbox" element={<InboxPage></InboxPage>}></Route>
          <Route path="/tutoring" element={<TutoringPage></TutoringPage>}></Route>
          <Route path="/lessons" element={<LessonListPage></LessonListPage>}></Route>
          <Route path="/lesson/detail" element={<LessonDetailPage></LessonDetailPage>}></Route>
        </Routes>
        <Footer />
        <ToastComponent />
      </div>
    </BrowserRouter>
  );
}

export default App;
