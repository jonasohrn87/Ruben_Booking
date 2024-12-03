import {useState} from 'react';
import { useNavigate } from 'react-router-dom';

const LoginButton = () => {
    const [messageForUnitTest, setMessageForUnitTest] = useState("");
    const navigateToBookingPage = useNavigate();
    const handleLoginButtonClick = () => {
        setMessageForUnitTest("Login button pressed");
        navigateToBookingPage('/booking');
    };
    
    return (
        <div>
        <button onClick={handleLoginButtonClick}>Login</button>
        <p>{messageForUnitTest}</p>
        </div>
    );
}

export default LoginButton;