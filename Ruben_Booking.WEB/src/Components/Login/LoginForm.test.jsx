import React from "react";
import { render, screen, fireEvent, waitFor } from "@testing-library/react";
import { vi } from "vitest";
import { MemoryRouter } from "react-router-dom";
import LoginPage from "./LoginPage";
import { authenticateUserLogginCredentialsService } from "../path/to/apiService";

vi.mock("../path/to/apiService");

describe("LoginPage Component", () => {
    const mockNavigate = vi.fn();
    const mockOnSubmit = vi.fn();

    vi.mock("react-router-dom", async () => ({
        ...LoginPage(await vi.importActual("react-router-dom")),
        useNavigate: () => mockNavigate,        
    }));
    
    beforeEach(() => {
        vi.clearAllMocks();
      });
    
      test("renders the login form", () => {
        render(
          <MemoryRouter>
            <LoginPage onSubmit={mockOnSubmit} />
          </MemoryRouter>
        );
    
        expect(screen.getByLabelText("Username")).toBeInTheDocument();
        expect(screen.getByPlaceholderText("Username")).toBeInTheDocument();
        expect(screen.getByRole("form")).toBeInTheDocument();
        expect(screen.getByRole("button", { name: "Submit" })).toBeInTheDocument();
      });

      test("calls onSubmit and login service on successful login", async () => {
        authenticateUserLogginCredentialsService.login.mockResolvedValueOnce({
          token: "fake-token",
          user: { id: 1, name: "Test User" },
        });
    
        render(
          <MemoryRouter>
            <LoginPage onSubmit={mockOnSubmit} />
          </MemoryRouter>
        );
    
        fireEvent.change(screen.getByPlaceholderText("Username"), {
          target: { value: "testuser" },
        });
        fireEvent.change(screen.getByPlaceholderText("Password"), {
          target: { value: "password123" },
        });
    
        fireEvent.submit(screen.getByRole("form"));
    
        await waitFor(() =>
          expect(authenticateUserLogginCredentialsService.login).toHaveBeenCalledWith(
            "testuser",
            "password123"
          )
        );
        expect(mockOnSubmit).toHaveBeenCalledWith({
          token: "fake-token",
          user: { id: 1, name: "Test User" },
        });
        expect(mockNavigate).toHaveBeenCalledWith("/booking");
      });
    
      test("shows error message on invalid credentials", async () => {
        authenticateUserLogginCredentialsService.login.mockRejectedValueOnce(
          new Error("Invalid credentials")
        );
    
        render(
          <MemoryRouter>
            <LoginPage onSubmit={mockOnSubmit} />
          </MemoryRouter>
        );

        fireEvent.change(screen.getByPlaceholderText("Username"), {
          target: { value: "wronguser" },
        });
        fireEvent.change(screen.getByPlaceholderText("Password"), {
          target: { value: "wrongpassword" },
        });
    

        fireEvent.submit(screen.getByRole("form"));
    
        await waitFor(() =>
          expect(authenticateUserLogginCredentialsService.login).toHaveBeenCalledWith(
            "wronguser",
            "wrongpassword"
          )
        );
        expect(screen.getByText("Invalid username or password. Please try again.")).toBeInTheDocument();
        expect(mockOnSubmit).not.toHaveBeenCalled();
      });
    });