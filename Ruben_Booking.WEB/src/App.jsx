import "./App.css";
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
import BookingPage from "./Components/Booking/BookingPage";
import LoginPage from "./Components/Login/LoginPage";

function App() {
  return (
      <Router>
        <div>
          <header className="RubenBooking-header">
            <h1>Booking System</h1>
          </header>
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
