import { render, screen } from "@testing-library/react";
import BookingDate from "./BookingDate";
import { vi } from "vitest";

describe("BookingDate component", () => {
  const mockPorps = {
    startDate: "",
    endDate: "",
    showEndDate: false,
    onChange: vi.fn(),
  };

  test("render booking start date input", () => {
    render(<BookingDate {...mockPorps} />);

    const startDateInput = screen.getByTestId("startDate-input-test");
    expect(startDateInput).toBeInTheDocument();
  });

  test("render booking end date input", () => {
    render(<BookingDate {...mockPorps} showEndDate={true} />);

    const endDateInput = screen.getByTestId("endDate-input-test");
    expect(endDateInput).toBeInTheDocument();
  });

  test("test with max end date input", () => {
    render(
      <BookingDate {...mockPorps} showEndDate={true} startDate="2024-12-05" />
    );

    const endDateInput = screen.getByTestId("endDate-input-test");
    expect(endDateInput).toHaveAttribute("max", "2024-12-07");
  });
});
