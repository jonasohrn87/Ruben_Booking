import React from "react";
import { useLocation } from "react-router-dom";
import LogoutButton from "./Logout/LogoutButton";

const Header = () => {
    const locationHook = useLocation();
    const IsPathLoginPage = locationHook.pathname === "/login";
    
    return (
        <div className="header-content">
            <h1>Rubens Bokningstjänst</h1>
            {!IsPathLoginPage && <LogoutButton />}
        </div>
    );
}

export default Header;