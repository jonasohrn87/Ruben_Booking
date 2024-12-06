import React, { useState, useEffect } from "react";
import BookableRoom from "../Room/BookableRoom";
import { getRoomService } from "../../Services/apiService";

const BookingPage = () => {
  const [bookableRoomInfo, setBookableRoomInfo] = useState([]);
  const [errorMessage, setErrorMessage] = useState(null);

  useEffect(() => {
    const fetchRooms = async () => {
      try {
        const rooms = await getRoomService.getAllRooms();
        setBookableRoomInfo(rooms);
      } catch (errorFetchingRooms) {
        setErrorMessage("Kunde inte hämta rum, försök igen senare");
        console.error(errorFetchingRooms);
      }
    };
    fetchRooms();
  }, []);

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
