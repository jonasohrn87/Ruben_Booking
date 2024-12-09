import { useState } from "react";

export const useHandleBooking = (rooms) => {
  const [roomsAvailableToBook, setRoomsAvailableToBook] = useState([]);

  const checkAvailableRooms = () => {
    const availableRooms = rooms.filter((room) => room.isInService);
    setRoomsAvailableToBook(availableRooms);
  };

  return { roomsAvailableToBook, checkAvailableRooms };
};
