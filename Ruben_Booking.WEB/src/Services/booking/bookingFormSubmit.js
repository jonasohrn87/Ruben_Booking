import { bookingService } from "../apiService";

export const bookingFormSubmit = (
    bookingFormData,
    bookingLengthCheckbox,
    resetBookingForm
  ) => {
    return async (event) => {
    event.preventDefault();

    let dateFrom = bookingFormData.startDate;
    let dateTo = bookingFormData.endDate || bookingFormData.startDate;

    if (
      bookingFormData.endDate &&
      bookingFormData.endDate < bookingFormData.startDate
    ) {
      alert("Slutdatum kan inte vara före startdatum");
      return;
    }
    
    if (bookingLengthCheckbox === "partOfDayBookingSelected") {
      if (!bookingFormData.timeFrom || !bookingFormData.timeTo) {
        alert("Välj både start- och sluttid");
        return;
      }

      if (bookingFormData.timeFrom >= bookingFormData.timeTo) {
        alert("Sluttiden kan inte vara före starttiden");
        return;
      }

      dateFrom = `${bookingFormData.startDate}T${bookingFormData.timeFrom}`;
      dateTo = `${bookingFormData.startDate}T${bookingFormData.timeTo}`;
    } else {
      dateFrom = `${dateFrom}T00:00:00`;
      dateTo = `${dateTo}T23:59:59`;
    }

    const bookingData = {
      roomId: bookingFormData.selectedRoom,
      personId: 1,
      dateFrom: dateFrom,
      dateTo: dateTo,
      participants: [],
    };

    try {
      await bookingService.createBooking(bookingData);
      const bookingConfirmation = `Bokningen är skapad!
        Från: ${bookingFormData.startDate}
        Till: ${bookingFormData.endDate || bookingFormData.startDate}${
        bookingLengthCheckbox === "partOfDayBookingSelected"
          ? `
        Tid: ${bookingFormData.timeFrom} - ${bookingFormData.timeTo}`
          : ""
      }
        Rum: ${bookingFormData.selectedRoom}`;

      alert(bookingConfirmation);
      resetBookingForm();
    } catch (error) {
      console.error("Failed to create booking:", error);
      alert("Fel vid bokning. Försök igen.");
    }
    console.log("Booking request:", bookingData);
  };
};