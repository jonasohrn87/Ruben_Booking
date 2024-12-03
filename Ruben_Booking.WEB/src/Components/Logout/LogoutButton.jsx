import { useNavigate } from 'react-router-dom';

const LogoutButton = () => {
    const navigateToLoginPage = useNavigate();
    const handleLogoutButtonClick = () => {
        navigateToLoginPage('/login');
    };

    return (
        <div>
            <button onClick={handleLogoutButtonClick}>Logout</button>
        </div>
    );

}

export default LogoutButton;