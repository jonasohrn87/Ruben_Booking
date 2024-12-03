import {useState} from 'react';

const LoginButton = () => {
    const [messageForUnitTest, setMessageForUnitTest] = useState("");
    const handleClick = () => {
        setMessageForUnitTest("Login button pressed");
    };

    return (
        <div>
        <button onClick={handleClick}>Login</button>
        <p>{messageForUnitTest}</p>
        </div>
    );
}

export default LoginButton;