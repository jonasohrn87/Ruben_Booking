import React from "react";
import { render, screen, fireEvent, waitFor } from "@testing-library/react";
import { vi } from "vitest";
import { MemoryRouter, useNavigate } from "react-router-dom";
import LoginPage from "./LoginPage";
import { authenticateUserLogginCredentialsService } from "../../Services/apiService";

vi.mock("../../Services/apiService", () => ({
  authenticateUserLogginCredentialsService: {
    login: vi.fn(),
  },
}));

vi.mock("react-router-dom", async () => {
  const actual = await vi.importActual("react-router-dom");
  return {
    ...actual,
    useNavigate: vi.fn(),
  };
});

describe("LoginPage Component", () => {
  const mockNavigate = vi.mocked(useNavigate());
  const mockOnSubmit = vi.fn();

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
    expect(screen.getAllByRole("button", { name: "Login" })[0]).toBeInTheDocument();
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
