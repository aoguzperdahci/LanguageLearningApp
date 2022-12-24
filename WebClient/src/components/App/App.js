import { BrowserRouter, Routes, Route } from 'react-router-dom';
import HomePage from '../HomePage/HomePage';
import NavbarComponent from '../NavbarComponent/NavbarComponent';
import ToastComponent from '../ToastComponent/ToastComponent';
import './App.css';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <NavbarComponent />
        <HomePage/>
        <Routes>
          {/* <Route index element={<HomePage />}/> */}
        </Routes>

        <ToastComponent />
      </div>
    </BrowserRouter>
  );
}

export default App;
