import { render, screen } from "@testing-library/react";
import BookableRoom from "./BookableRoom";

describe("BookableRoom component", () => {
  const roomSampleToTest = {
    id: 1,
    maxSeats: 6,
    name: "Vårsolen",
    description: "Konferansrum 3",
    isInService: true,
    hasProjector: false,
    hasWhiteBoard: true,
  };

  test("Check room configuration", () => {
      render(<BookableRoom {...roomSampleToTest} />);

      expect(screen.getByText("6 platser")).toBeInTheDocument();
      expect(screen.getByText("Vårsolen")).toBeInTheDocument();
      expect(screen.getByText("Konferansrum 3")).toBeInTheDocument();
      expect(screen.getByText("Har ej projektor")).toBeInTheDocument();
      expect(screen.getByText("Har whiteboard")).toBeInTheDocument();
    });
});
