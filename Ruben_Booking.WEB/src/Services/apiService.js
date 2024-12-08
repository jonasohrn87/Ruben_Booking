const API_RUBENBOOKING_URL = "https://localhost:7294/api";

export const getRoomService = {
  async getAllRooms() {
    const response = await fetch(`${API_RUBENBOOKING_URL}/rooms`);
    if (!response.ok) {
      throw new Error("Failed to fetch, no rooms found");
    }
    return await response.json();
  },

  async getRoomById(id) {
    const response = await fetch(`${API_RUBENBOOKING_URL}/rooms/${id}`);
    if (!response.ok) {
      throw new Error("Failed to fetch, room id not found");
    }
    return await response.json();
  },
};
