import { render, screen } from "@testing-library/react";
import Header from "./Header";

describe("Header component", () => {
    test("Header title is rendered", () => {
        render(<Header />);
        const headerTitle = screen.getByRole("heading", {name: "Rubens Bokningstjänst"});

        expect(headerTitle).toBeInTheDocument();
    })    
})