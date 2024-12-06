import React from "react";
import PropTypes from "prop-types";
const BookableRoom = ({
  id,
  maxSeats,
  name,
  description,
  isInService,
  hasProjector,
  hasWhiteBoard,
}) => {
  return (
    <div>
      <p className="bookableRoom-roomNumber">Rum {id}</p>
      <div className="bookableRoom-container">
        <div>
          <h4>{name}</h4>
          <p>{description}</p>
          <p>{maxSeats} platser</p>
          <p>{hasProjector ? "Har projektor" : "Har ej projektor"}</p>
          <p>{hasWhiteBoard ? "Har whiteboard" : "Har ej whiteboard"}</p>
        </div>
        <h3>
          {isInService ? <button>Boka rum</button> : "Rummet är ur funktion"}
        </h3>
      </div>
    </div>
  );
};

BookableRoom.propTypes = {
  id: PropTypes.number.isRequired,
  maxSeats: PropTypes.number.isRequired,
  name: PropTypes.string.isRequired,
  description: PropTypes.string.isRequired,
  isInService: PropTypes.bool.isRequired,
  hasProjector: PropTypes.bool.isRequired,
  hasWhiteBoard: PropTypes.bool.isRequired,
};

export default BookableRoom;
