import React from "react";
import PropTypes from "prop-types";

const BookingDurationType = (props) => {
  return (
    <div>
      {[
        { value: "fullDayBookingSelected", label: "Hela dagen" },
        { value: "partOfDayBookingSelected", label: "Del av dagen" },
        { value: "severalDaysBookingSelected", label: "Flera dagar" },
      ].map((durationTypeOption) => (
        <label key={durationTypeOption.value}>
          <input
            type="radio"
            name="bookingDurationType"
            value={durationTypeOption.value}
            checked={props.selected === durationTypeOption.value}
            onChange={props.onChange}
            required={durationTypeOption.value === "fullDayBookingSelected"}
          />
          <span>{durationTypeOption.label}</span>
        </label>
      ))}
    </div>
  );
};

BookingDurationType.propTypes = {
  selected: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
};

export default BookingDurationType;
