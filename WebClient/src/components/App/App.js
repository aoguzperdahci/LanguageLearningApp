import { BrowserRouter, Routes, Route } from 'react-router-dom';
import HomePage from '../../pages/HomePage/HomePage';
import ExamPage from '../../pages/ExamPage/ExamPage';
import InboxPage from '../../pages/InboxPage/InboxPage';
import PersonalTutorPage from '../../pages/PersonalTutorPage/PersonalTutorPage';
import TutoringPage from '../../pages/TutoringPage/TutoringPage';
import ToastComponent from '../ToastComponent/ToastComponent';
import Footer from '../Footer/Footer';
import './App.css';
import FooterComponent from '../Footer/Footer';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <Routes>
          <Route index element={<HomePage />}/>
          <Route index element={<FooterComponent />}/>
          <Route path="/personal-tutor" element={<PersonalTutorPage></PersonalTutorPage>}></Route>
          <Route path="/inbox" element={<InboxPage></InboxPage>}></Route>
          <Route path="/tutoring" element={<TutoringPage></TutoringPage>}></Route>
          <Route path="/exam" element={<ExamPage></ExamPage>}></Route>
        </Routes>
        <ToastComponent />
      </div>
    </BrowserRouter>
  );
}

export default App;
