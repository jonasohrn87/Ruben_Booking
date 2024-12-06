import { useState, useEffect } from "react";
import { getRoomService } from "../apiService";

export const useHandleRoom = () => {
    const [bookableRoomInfo, setBookableRoomInfo] = useState([]);
    const [errorMessage, setErrorMessage] = useState(null);

    useEffect(() => {
        const fetchRooms = async () => {
            try {
                const rooms = await getRoomService.getAllRooms();
                setBookableRoomInfo(rooms);
            } catch (errorFetchingRooms) {
                setErrorMessage("Kunde inte hämta rum, försök igen senare");
                console.error(errorFetchingRooms);
            }
        };
        fetchRooms();
    }, []);

    return { bookableRoomInfo, errorMessage };
};
