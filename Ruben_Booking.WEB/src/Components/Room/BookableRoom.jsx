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
          <h3>{isInService ? "" : "Ur funktion"}</h3>
        </div>
        {isInService ? <button>Boka rum</button> : <p>Rummet är ur funktion</p>}
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
