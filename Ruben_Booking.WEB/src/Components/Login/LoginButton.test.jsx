import { render, fireEvent, screen } from "@testing-library/react";
import LoginButton from "./LoginButton";
import {beforeEach, vi} from "vitest";

const testLoginNavigateButton = vi.fn();
vi.mock("react-router-dom", () => ({
    useNavigate: () => testLoginNavigateButton
}));

describe("LoginButton component", () => {
    beforeEach(() => {
        vi.clearAllMocks();
    });
    
    test("LoginButton set and print test message when clicked", () => {
        render(<LoginButton />);
        const loginButton = screen.getByRole("button", { name: "Login" });
        fireEvent.click(loginButton);

        expect(screen.getByText("Login button pressed")).toBeInTheDocument();
    });

    test("LoginButton navigates to booking page when clicked", () => {
        render(<LoginButton />);
        const loginButton = screen.getByRole("button", { name: "Login" });
        fireEvent.click(loginButton);

        expect(testLoginNavigateButton).toHaveBeenCalledWith("/booking");
    });
});