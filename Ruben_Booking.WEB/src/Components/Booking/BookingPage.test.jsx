import { render, screen } from "@testing-library/react";
import BookingPage from "./BookingPage";
import { vi } from "vitest";

vi.mock("../Logout/LogoutButton", () => ({
    default: () => <button>Mocked Logout Button</button>,
 }));

 describe("BookingPage", () => {
    test("renders the BookingPage with the correct heading", () => {
        render(<BookingPage />);
        
        const heading = screen.getByRole("heading", { name: /ruben booking/i });
        expect(heading).toBeInTheDocument();
    });

    test("renders the LogoutButton component", () => {
        render(<BookingPage />);
        
        const logoutButton = screen.getByRole("button", { name: /mocked logout button/i });
        expect(logoutButton).toBeInTheDocument();
    })
 });