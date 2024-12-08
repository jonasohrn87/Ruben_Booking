import { render, screen } from "@testing-library/react";
import BookingRoomTypes from "./BookingRoomTypes";
import { expect, vi } from "vitest";

describe("BookingRoomTypes component", () => {
    
    test("mock room setup", () => {
      const mockRoomData = {
        show: true,
        rooms: [
          {
            id: 1,
            name: "Vårsolen",
            maxSeats: 6,
            hasProjector: false,
            hasWhiteBoard: true,
          },
          {
            id: 2,
            name: "Höstlöven",
            maxSeats: 8,
            hasProjector: true,
            hasWhiteBoard: false,
          },
        ],
        selectedRoom: "",
        onChange: vi.fn(),
      };
    render(<BookingRoomTypes {...mockRoomData} />);

    expect(screen.getByText("Välj ett rum")).toBeInTheDocument();
    
    const selectRoomOne = screen.getByText((content) => 
    content.includes("Vårsolen") &&
    content.includes("6 platser") &&
    !content.includes("Projektor") &&
    content.includes("Whiteboard"));
    expect(selectRoomOne).toBeInTheDocument();

    const selectRoomTwo = screen.getByText((content) =>
    content.includes("Höstlöven") &&
    content.includes("8 platser") &&
    content.includes("Projektor") &&
    !content.includes("Whiteboard"));
    expect(selectRoomTwo).toBeInTheDocument();
  });

  test("if props show is false, return null", () => {
    render(<BookingRoomTypes show={false} />);
    expect(screen.queryByText("Välj ett rum")).not.toBeInTheDocument();
  });
});
