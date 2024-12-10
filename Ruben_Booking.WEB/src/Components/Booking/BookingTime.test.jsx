import React from "react";
import { render, screen, fireEvent } from "@testing-library/react";
import { describe, test, vi, expect } from "vitest";
import BookingTime from "./BookingTime";

describe("BookingTime Component", () => {
    test("renders input fields with correct labels and values", () => {
        const mockOnChange  = vi.fn();

        render(
            <BookingTime
                timeFrom="08:00"
                timeTo="17:00"
                onChange={mockOnChange} 
            />
        );

        const timeFromInput = screen.getByLabelText("Från:");
        const timeToInput = screen.getByLabelText("Till:");

        expect(timeFromInput).toBeInTheDocument();
        expect(timeToInput).toBeInTheDocument();

        expect(timeFromInput.value).toBe("08:00");
        expect(timeToInput.value).toBe("17:00");   
    
    });

    test("calls onChange function when timeFrom input value changes", () => {
        const mockingOnChange = vi.fn();

        render(
            <BookingTime
                timeFrom="08:00"
                timeTo="17:00"
                onChange={mockingOnChange}
            />
        );

        const timeFromInput = screen.getByLabelText("Från:");

        fireEvent.change(timeFromInput, { target: { value: "09:00"}});

        expect(mockingOnChange).toHaveBeenCalled();
        expect(mockingOnChange).toHaveBeenCalledWith(expect.any(Object));
    });

    test("calls onChange function when timeTo input value changes", () => {
        const mockingOnChange = vi.fn();

        render(
            <BookingTime
                timeFrom="08:00"
                timeTo="17:00"
                onChange={mockingOnChange}
            />
        );

        const timeToInput = screen.getByLabelText("Till:");

        fireEvent.change(timeToInput, { target: { value: "18:00"}});

        expect(mockingOnChange).toHaveBeenCalled();
        expect(mockingOnChange).toHaveBeenCalledWith(expect.any(Object));
    });
    
        test("marks both inputs as required", () => {
            const mockOnChange = vi.fn();
        
            render(
                <BookingTime
                    timeFrom="08:00"
                    timeTo="17:00"
                    onChange={mockOnChange}
                />
            );

            const timeFromInput = screen.getByLabelText("Från:");
            const timeToInput = screen.getByLabelText("Till:");

            expect(timeFromInput).toHaveAttribute("required");
            expect(timeToInput).toHaveAttribute("required");
        });
});