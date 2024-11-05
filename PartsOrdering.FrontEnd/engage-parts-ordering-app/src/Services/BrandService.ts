import axios from "axios";

const API_BASE_URL = "http://localhost:5043/api";

export interface Brand {
  description: string;
  brandCode: string;
}

export interface BrandsResponse {
  brands: Brand[];
  totalItems: number;
  totalPages: number;
}

export const getBrands = async (page: number, pageSize: number) => {
  const response = await axios.get<BrandsResponse>(
    `${API_BASE_URL}/Brand?page=${page}&pageSize=${pageSize}`
  );
  console.log("response: ", response);
  return response.data.brands;
};
