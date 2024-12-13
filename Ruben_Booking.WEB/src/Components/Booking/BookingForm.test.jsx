import { render, screen, fireEvent } from "@testing-library/react";
import BookingForm from "./BookingForm";

describe("BookingForm component", () => {
  const mockRoomSetup = [
    {
      id: 1,
      name: "Vårsolen",
      description: "Konferensrum 4",
      maxSeats: 6,
      hasProjector: true,
      hasWhiteBoard: true,
      isInService: true,
    },
    {
      id: 2,
      name: "Höstvinden",
      description: "Konferensrum 2",
      maxSeats: 4,
      hasProjector: true,
      hasWhiteBoard: false,
      isInService: true,
    },
  ];

  test("book a room with date, durationtype and room select", () => {
    const mockBookingChange = vi.fn();

    render(<BookingForm rooms={mockRoomSetup} onChange={mockBookingChange} />);

    const selectDateInput = screen.getByLabelText("Datum:");
    fireEvent.change(selectDateInput, { target: { value: "2024-12-05" } });
    expect(selectDateInput.value).toBe("2024-12-05");

    const selectDurationInput = screen.getByLabelText("Hela dagen");
    fireEvent.click(selectDurationInput);
    expect(selectDurationInput).toBeChecked();

    const selectRoomInput = screen.getByLabelText("Välj rum:");
    fireEvent.change(selectRoomInput, { target: { value: "1" } });
    expect(selectRoomInput.value).toBe("1");

    const submitButton = screen.getByRole("button", { name: "Boka rum" });
    expect(submitButton).toBeInTheDocument();
  });
});
