import React from "react";
import dayjs from "dayjs";
import PropTypes from "prop-types";

const BookingDate = (props) => {
  return (
    <>
      <div>
        <label htmlFor="startDate">Datum: </label>
        <input
          type="date"
          id="startDate"
          name="startDate"
          value={props.startDate}
          onChange={props.onChange}
          required
          data-testid="startDate-input-test"
        />
      </div>

      {props.showEndDate && (
        <div>
          <label htmlFor="endDate">Till datum: </label>
          <input
            type="date"
            id="endDate"
            name="endDate"
            value={props.endDate}
            onChange={props.onChange}
            min={props.startDate}
            max={
              props.startDate
                ? dayjs(props.startDate).add(2, "day").format("YYYY-MM-DD")
                : ""
            }
            required
            data-testid="endDate-input-test"
          />
        </div>
      )}
    </>
  );
};

BookingDate.propTypes = {
  startDate: PropTypes.string.isRequired,
  endDate: PropTypes.string.isRequired,
  showEndDate: PropTypes.bool.isRequired,
  onChange: PropTypes.func.isRequired,
};

export default BookingDate;
