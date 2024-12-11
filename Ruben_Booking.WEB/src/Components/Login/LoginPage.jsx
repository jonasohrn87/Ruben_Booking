import React from "react";
import LoginForm from "./LoginForm";

const LoginPage = () => {

    const handleLogin = (credentials) => {
        console.log("Login credentials:", credentials);
      };

    return (
        <div>
            <h1>Login</h1>
            <LoginForm onSubmit={handleLogin} />
        </div>
    );
};

export default LoginPage;