import React from "react";
import LoginButton from "./LoginButton";
import LoginForm from "./LoginForm";

const LoginPage = () => {

    const handleLogin = (credentials) => {
        console.log("Login credentials:", credentials);
      };

    return (
        <div>
            <h1>Login</h1>
            <LoginForm onSubmit={handleLogin} />
            <LoginButton />
        </div>
    );
};

export default LoginPage;