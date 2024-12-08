import { render, screen } from "@testing-library/react";
import LoginPage from "./LoginPage";
import LoginButton from "./LoginButton";
import { vi } from "vitest";
import { MemoryRouter } from "react-router-dom";

vi.mock("./LoginButton", () => ({
    default: () => <button>Mocked Login Button</button>,
}));

describe("LoginPage component", () => {
    test("renders the LoginPage with the correct heading", () => {
        render(<MemoryRouter>
            <LoginPage />
            </MemoryRouter>);
        
        const heading = screen.getByRole("heading", { name: /login/i });
        expect(heading).toBeInTheDocument();
    });

    test("renders the LoginButton component", () => {
        render(<MemoryRouter>
            <LoginPage />
            </MemoryRouter>);
        
        const loginButton = screen.getByRole("button", { name: /mocked login button/i});
        expect(loginButton).toBeInTheDocument();
    });    
});
