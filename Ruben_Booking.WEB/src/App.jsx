import "./App.css";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import BookingPage from "./Components/Booking/BookingPage";
import LoginPage from "./Components/Login/LoginPage";
import Header from "./Components/Header";

function App() {
  return (
    <Router>
      <header className="header-container">
        <Header />
      </header>
      <div className="main-container">
        <Routes>
          <Route path="/" element={<Navigate to="/login" />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/booking" element={<BookingPage />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
