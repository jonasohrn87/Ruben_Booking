import { render, screen } from "@testing-library/react";
import BookingPage from "./BookingPage";

 describe("BookingPage", () => {
    test("render text heading for room booking form", () => {
        render(<BookingPage />);
        
        const bookRoomTextHeading = screen.getByText("Boka rum här");
        expect(bookRoomTextHeading).toBeInTheDocument();
    });
 });