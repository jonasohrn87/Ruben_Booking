import { render, fireEvent, screen } from "@testing-library/react";
import LogoutButton from "./LogoutButton";
import {beforeEach, vi} from "vitest";

const testLogoutNavigateButton = vi.fn();
vi.mock("react-router-dom", () => ({
    useNavigate: () => testLogoutNavigateButton
}));

describe("LogoutButton component", () => {
    beforeEach(() => {
        vi.clearAllMocks();
    });

    test("LogoutButton navigates to the login page when clicked", () => {
        render(<LogoutButton />);
        const logoutButton = screen.getByRole("button", { name: "Logout" });
        fireEvent.click(logoutButton);

        expect(testLogoutNavigateButton).toHaveBeenCalledWith("/login");
    });
    
});
