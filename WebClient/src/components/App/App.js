import { BrowserRouter, Routes, Route } from 'react-router-dom';
import InboxPage from '../../pages/InboxPage/InboxPage';
import PersonalTutorPage from '../../pages/InboxPage/PersonalTutorPage/PersonalTutorPage';
import TutoringPage from '../../pages/InboxPage/TutoringPage/TutoringPage';
import NavbarComponent from '../NavbarComponent/NavbarComponent';
import ToastComponent from '../ToastComponent/ToastComponent';
import './App.css';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <NavbarComponent />
        <Routes>
          {/* <Route index element={<HomePage />}/> */}
          <Route path="/personal-tutor" element={<PersonalTutorPage></PersonalTutorPage>}></Route>
          <Route path="/inbox" element={<InboxPage></InboxPage>}></Route>
          <Route path="/tutoring" element={<TutoringPage></TutoringPage>}></Route>
        </Routes>

        <ToastComponent />
      </div>
    </BrowserRouter>
  );
}

export default App;
