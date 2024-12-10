import React, { useEffect } from "react";
import BookingDurationType from "./BookingDurationType";
import BookingDate from "./BookingDate";
import BookingTime from "./BookingTime";
import BookingRoomTypes from "./BookingRoomTypes";
import { useBookingFormState } from "../../Services/booking/bookingFormState";
import PropTypes from "prop-types";
import { useHandleBooking } from "../../Services/booking/handleBooking";
import { bookingFormSubmit } from "../../Services/booking/bookingFormSubmit";

const BookingForm = (props) => {
  const {
    bookingLengthCheckbox,
    timeOfDayInput,
    dateBookingEnds,
    bookingFormData,
    handleCheckboxType,
    handleInputChange,
    resetBookingForm,
  } = useBookingFormState();

  const { roomsAvailableToBook, checkAvailableRooms } = useHandleBooking(
    props.rooms
  );

  useEffect(() => {
    checkAvailableRooms(
      bookingFormData.startDate,
      bookingFormData.timeFrom,
      bookingFormData.timeTo
    );
  }, [
    bookingFormData.startDate,
    bookingFormData.timeFrom,
    bookingFormData.timeTo,
  ]);

      const handleBookingFormSubmit = bookingFormSubmit(
        bookingFormData,
        bookingLengthCheckbox,
        resetBookingForm
      );

  return (
    <div className="bookingForm-container">
      <form onSubmit={handleBookingFormSubmit}>
        <BookingDate
          startDate={bookingFormData.startDate}
          endDate={bookingFormData.endDate}
          showEndDate={dateBookingEnds}
          onChange={handleInputChange}
        />

        <BookingDurationType
          selected={bookingLengthCheckbox}
          onChange={handleCheckboxType}
        />

        {timeOfDayInput && (
          <BookingTime
            timeFrom={bookingFormData.timeFrom}
            timeTo={bookingFormData.timeTo}
            onChange={handleInputChange}
          />
        )}

        <BookingRoomTypes
          show={!!bookingFormData.startDate}
          rooms={roomsAvailableToBook}
          selectedRoom={bookingFormData.selectedRoom}
          onChange={handleInputChange}
        />

        {bookingFormData.startDate && bookingFormData.selectedRoom && (
          <button type="submit">Boka rum</button>
        )}
      </form>
    </div>
  );
};

BookingForm.propTypes = {
  rooms: PropTypes.array.isRequired,
};

export default BookingForm;
