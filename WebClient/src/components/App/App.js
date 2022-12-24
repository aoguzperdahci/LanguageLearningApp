import { BrowserRouter, Routes, Route } from 'react-router-dom';
import ForumPage from '../Forum/ForumPage';
import NavbarComponent from '../NavbarComponent/NavbarComponent';
import ToastComponent from '../ToastComponent/ToastComponent';
import './App.css';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <NavbarComponent />
        <ForumPage/>
        <Routes>
          {/* <Route index element={<HomePage />}/> */}
        </Routes>

        <ToastComponent />
      </div>
    </BrowserRouter>
  );
}

export default App;
