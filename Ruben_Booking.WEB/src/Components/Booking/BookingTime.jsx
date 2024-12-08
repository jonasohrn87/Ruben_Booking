import React from "react";
import PropTypes from "prop-types";

const BookingTime = (props) => {
  return (
    <div>
      <div>
        <label htmlFor="timeFrom">Från: </label>
        <input
          type="time"
          id="timeFrom"
          name="timeFrom"
          value={props.timeFrom}
          onChange={props.onChange}
          required
        />
      </div>
      <div>
        <label htmlFor="timeTo">Till: </label>
        <input
          type="time"
          id="timeTo"
          name="timeTo"
          value={props.timeTo}
          onChange={props.onChange}
          required
        />
      </div>
    </div>
  );
};

BookingTime.propTypes = {
  timeFrom: PropTypes.string.isRequired,
  timeTo: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
};

export default BookingTime;
