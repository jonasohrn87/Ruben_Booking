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

export const authenticateUserLogginCredentialsService = {
  async login(email, password) {
    const response = await fetch(`${API_RUBENBOOKING_URL}/login`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ email, password }),
    });

    if(!response.ok) {
      throw new Error("Invalid credentials");
    }
    return await response.json();
  },
};
