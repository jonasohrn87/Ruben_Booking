import React, { useState } from "react";

export const useBookingFormState = () => {
    const [bookingLengthCheckbox, setBookingLengthCheckbox] = useState("");
    const [timeOfDayInput, setTimeOfDayInput] = useState(false);
    const [dateBookingEnds, setDateBookingEnds] = useState(false);
    const [bookingFormData, setBookingFormData] = useState({
      startDate: "",
      endDate: "",
      timeFrom: "",
      timeTo: "",
      selectedRoom: "",
    });
  
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
  
    return {
      bookingLengthCheckbox,
      timeOfDayInput,
      dateBookingEnds,
      bookingFormData,
      handleCheckboxType,
      handleInputChange,
    };
  };