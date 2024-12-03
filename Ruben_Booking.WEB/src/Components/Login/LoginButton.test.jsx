import { render, fireEvent, screen } from "@testing-library/react";
import LoginButton from "./LoginButton";

describe("LoginButton component", () => {
    test("LoginButton prints console log message when clicked", () => {
        render(<LoginButton />);
        const loginButton = screen.getByRole("button", { name: "Login" });

        fireEvent.click(loginButton);

        expect(screen.getByText("Login button pressed")).toBeInTheDocument();
    });
});