import React from "react";
import BookableRoom from "../Room/BookableRoom";
import { useHandleRoom } from "../../Services/room/handleRoom";

const BookingPage = () => {
    const { bookableRoomInfo, errorMessage } = useHandleRoom();

  if (errorMessage) {
    return <div>{errorMessage}</div>;
  }

  return (
    <div className="bookingPage-container">
      <h3>Boka rum här</h3>
      <div className="bookingPage-rooms">
        {bookableRoomInfo.map((room) => (
          <BookableRoom key={room.id} {...room} />
        ))}
      </div>
    </div>
  );
};

export default BookingPage;