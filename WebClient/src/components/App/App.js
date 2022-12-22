import { BrowserRouter, Routes, Route } from 'react-router-dom';
import InboxPage from '../../pages/InboxPage/InboxPage';
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
          <Route path="/inbox" element={<InboxPage></InboxPage>}></Route>
        </Routes>

        <ToastComponent />
      </div>
    </BrowserRouter>
  );
}

export default App;
