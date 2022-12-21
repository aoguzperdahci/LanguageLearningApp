import { BrowserRouter, Routes, Route } from 'react-router-dom';
import NavbarComponent from '../NavbarComponent/NavbarComponent';
import ToastComponent from '../ToastComponent/ToastComponent';
import Footer from '../Footer/Footer';
import './App.css';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <NavbarComponent />
        <Footer />
        <Routes>
          {/* <Route index element={<HomePage />}/> */}
        </Routes>

        <ToastComponent />
      </div>
    </BrowserRouter>
  );
}

export default App;
