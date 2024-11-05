import axios from "axios";

export interface Part {
  partCode: string;
  description: string;
  stock: number;
  price: number;
}

const API_BASE_URL = "http://localhost:5043/api";

export const getPartByCode = async (
  brandCode: string,
  partCode: string,
  page: number,
  pageSize: number
): Promise<Part | null> => {
  try {
    const response = await axios.get<Part>(
      `${API_BASE_URL}/part?brandCode=${partCode},partCode=${partCode},page=${page},pageSize=${pageSize}`
    );
    return response.data;
  } catch (error) {
    console.error("Error fetching part info:", error);
    return null;
  }
};
