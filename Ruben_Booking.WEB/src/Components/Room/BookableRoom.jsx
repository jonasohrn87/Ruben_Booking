import React from "react";
import PropTypes from "prop-types";
const BookableRoom = (props) => {
  return (
    <div>
      <p className="bookableRoom-roomNumber">Rum {props.id}</p>
      <div
        className={`bookableRoom-container ${
          props.isInService ? "roomFunctional" : "roomOutOfFunction"
        }`}
      >
        <div>
          <h4>{props.name}</h4>
          <p>{props.description}</p>
          <p>{props.maxSeats} platser</p>
          <p>{props.hasProjector ? "Har projektor" : "Har ej projektor"}</p>
          <p>{props.hasWhiteBoard ? "Har whiteboard" : "Har ej whiteboard"}</p>
        </div>
        <h3>
          {!props.isInService && (
            <p className="roomOutOfFunctionText">Rummet är ur funktion</p>
          )}
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
