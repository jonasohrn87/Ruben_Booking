import React, { useState } from "react";

const BookableRoom = ({ id, MaxSeats, Name, Description, IsInService, HasProjector, HasWhiteBoard}) => {

    return (
        <div className="bookableRoom-container">
            <div>

            <h4>{Name}</h4>
            <p>{Description}</p>
            <p>{MaxSeats} platser</p>
            <p>{HasProjector ? "Har projektor" : "Har ej projektor"}</p>
            </div>
            <p>{HasWhiteBoard ? "Har whiteboard" : "Har ej whiteboard"}</p>
            <h3>{IsInService ? "" : "Ur funktion"}</h3>
        </div>
    );
}

export default BookableRoom;