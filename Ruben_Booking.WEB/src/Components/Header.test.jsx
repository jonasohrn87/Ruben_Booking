import { render, screen } from "@testing-library/react";
import Header from "./Header";
import { MemoryRouter } from "react-router-dom";

describe("Header component", () => {
  test("Header title is rendered", () => {
    render(
      <MemoryRouter>
        <Header />
      </MemoryRouter>
    );
    const headerTitle = screen.getByRole("heading", {
      name: "Rubens Bokningstjänst",
    });
    expect(headerTitle).toBeInTheDocument();
  });

  test("Logout button not rendered on login page", () => {
    render(
      <MemoryRouter initialEntries={["/login"]}>
        <Header />
      </MemoryRouter>
    );
    const logoutButton = screen.queryByRole("button", { name: "Logout" });
    expect(logoutButton).not.toBeInTheDocument();
  });

  test("Logout button rendered when not on login page", () => {
    render(
      <MemoryRouter>
        <Header />
      </MemoryRouter>
    );
    const logoutButton = screen.queryByRole("button", { name: "Logout" });
    expect(logoutButton).toBeInTheDocument();
  });
});
