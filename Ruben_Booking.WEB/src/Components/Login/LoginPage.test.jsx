import { render, screen } from "@testing-library/react";
import LoginPage from "./LoginPage";
import LoginButton from "./LoginButton";
import { vi } from "vitest";

vi.mock("./LoginButton", () => ({
    default: () => <button>Mocked Login Button</button>,
}));

describe("LoginPage component", () => {
    test("renders the LoginPage with the correct heading", () => {
        render(<LoginPage />);
        
        const heading = screen.getByRole("heading", { name: /ruben booking login/i });
        expect(heading).toBeInTheDocument();
    });

    test("renders the LoginButton component", () => {
        render(<LoginPage />);
        
        const loginButton = screen.getByRole("button", { name: /mocked login button/i});
        expect(loginButton).toBeInTheDocument();
    });    
});
