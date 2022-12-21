import { BrowserRouter, Routes, Route } from 'react-router-dom';
import NavbarComponent from '../NavbarComponent/NavbarComponent';
import ToastComponent from '../ToastComponent/ToastComponent';
import Login from '../Login/Login'
import SignUp from '../SignUp/SignUp'
import './App.css';
import Try from '../Login/Try';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <NavbarComponent />
        <Login/>
        <SignUp/>
        <Routes>
          {/* <Route index element={<HomePage />}/> */}
        </Routes>

        <div style={{ height: "1000px", backgroundColor: "#D2F1FF" }}></div>

        <ToastComponent />
      </div>
    </BrowserRouter>
  );
}

export default App;
