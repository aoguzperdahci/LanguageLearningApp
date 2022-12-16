import { BrowserRouter, Routes, Route } from 'react-router-dom';
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
        </Routes>

        <div style={{ height: "1000px", backgroundColor: "green" }}></div>

        <ToastComponent />
      </div>
    </BrowserRouter>
  );
}

export default App;
