import { render, screen } from "@testing-library/react";
import BookableRoom from "./BookableRoom";

describe("BookableRoom component", () => {

    const roomSampleToTest = {
        id: 1, 
        MaxSeats: 6, 
        Name: "Vårsolen", 
        Description: "Konferansrum 3", 
        IsInService: true, 
        HasProjector: false, 
        HasWhiteBoard: true
    }
    
    test("Check room configuration"), () => {
        render(<BookableRoom {...roomSampleToTest} />);

        expect(screen.getByText("6 platser")).toBeInTheDocument();
        expect(screen.getByText("Vårsolen")).toBeInTheDocument();
        expect(screen.getByText("Konferansrum 3")).toBeInTheDocument();
        expect(screen.getByText("Har projektor")).toBeInTheDocument();
        expect(screen.getByText("Har whiteboard")).toBeInTheDocument();
    }
});