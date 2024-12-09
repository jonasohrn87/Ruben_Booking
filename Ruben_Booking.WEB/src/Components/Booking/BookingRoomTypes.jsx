import React from "react";
import PropTypes from "prop-types";

const BookingRoomTypes = (props) => {
  if (!props.show) return null;

  return (
    <div>
      <label htmlFor="selectedRoom">Välj rum: </label>
      <select
        id="selectedRoom"
        name="selectedRoom"
        value={props.selectedRoom}
        onChange={props.onChange}
        required
      >
        <option value="">Välj ett rum</option>
        {props.rooms.map((room) => (
          <option key={room.id} value={room.id}>
            {room.name} ({room.maxSeats} platser)
            {room.hasProjector && " - Projektor"}
            {room.hasWhiteBoard && " - Whiteboard"}
          </option>
        ))}
      </select>
    </div>
  );
};

BookingRoomTypes.propTypes = {
  show: PropTypes.bool.isRequired,
  rooms: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      name: PropTypes.string.isRequired,
      maxSeats: PropTypes.number.isRequired,
      hasProjector: PropTypes.bool.isRequired,
      hasWhiteBoard: PropTypes.bool.isRequired,
    })
  ).isRequired,
  selectedRoom: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
};

export default BookingRoomTypes;
