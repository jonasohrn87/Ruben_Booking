import React from "react";
import BookableRoom from "../Room/BookableRoom";
import BookingForm from "./BookingForm";
import { useHandleRoom } from "../../Services/room/handleRoom";

const BookingPage = () => {
  const { bookableRoomInfo, errorMessage } = useHandleRoom();

  if (errorMessage) {
    return <div>{errorMessage}</div>;
  }

  return (
    <div className="bookingPage-container">
      <div>
        <h3>Boka rum här</h3>
      </div>
      <div>
        <BookingForm rooms={bookableRoomInfo} />
      </div>
      <div className="bookingPage-rooms">
        {bookableRoomInfo.map((room) => (
          <BookableRoom key={room.id} {...room} />
        ))}
      </div>
    </div>
  );
};

export default BookingPage;
