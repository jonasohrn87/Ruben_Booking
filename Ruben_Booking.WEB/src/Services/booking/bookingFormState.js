import React, { useState } from "react";

export const useBookingFormState = () => {
  const initialBookingFormData = {
    startDate: "",
    endDate: "",
    timeFrom: "",
    timeTo: "",
    selectedRoom: "",
  };

  const [bookingLengthCheckbox, setBookingLengthCheckbox] = useState("");
  const [timeOfDayInput, setTimeOfDayInput] = useState(false);
  const [dateBookingEnds, setDateBookingEnds] = useState(false);
  const [bookingFormData, setBookingFormData] = useState(
    initialBookingFormData
  );

  const handleCheckboxType = (event) => {
    const selectedCheckboxType = event.target.value;
    setBookingLengthCheckbox(selectedCheckboxType);
    setTimeOfDayInput(selectedCheckboxType === "partOfDayBookingSelected");
    setDateBookingEnds(selectedCheckboxType === "severalDaysBookingSelected");

    if (selectedCheckboxType !== "partOfDayBookingSelected") {
      setBookingFormData((prev) => ({
        ...prev,
        timeFrom: "",
        timeTo: "",
      }));
    }
  };

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setBookingFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const resetBookingForm = () => {
    setBookingLengthCheckbox("");
    setTimeOfDayInput(false);
    setDateBookingEnds(false);
    setBookingFormData(initialBookingFormData);
  };

  return {
    bookingLengthCheckbox,
    timeOfDayInput,
    dateBookingEnds,
    bookingFormData,
    handleCheckboxType,
    handleInputChange,
    resetBookingForm,
  };
};
