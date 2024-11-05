import React, { useState, useEffect } from "react";
import { getPartByCode, Part } from "../Services/PartsService";
import { getBrands, Brand } from "../Services/BrandService";

interface PartSearchProps {
  onSearchResult: (part: Part | null) => void;
}

const page: number = 1;
const pageSize: number = 50;

const PartSearch: React.FC<PartSearchProps> = ({ onSearchResult }) => {
  const [partCode, setPartCode] = useState<string>("");
  const [brandCode, setBrandCode] = useState<string>("");
  const [brands, setBrands] = useState<Brand[]>([]);
  const [loading, setLoading] = useState<boolean>(false);

  useEffect(() => {
    const fetchBrands = async () => {
      try {
        const brandData = await getBrands(page, pageSize);
        setBrands(brandData);
        if (brandData.length > 0) {
          setBrandCode(brandData[0].brandCode);
        }
      } catch (error) {
        console.error("Error fetching brands:", error);
      }
    };

    fetchBrands();
  }, []);

  const handleSearch = async () => {
    setLoading(true);
    const part = await getPartByCode(brandCode, partCode, 1, 50);
    console.log("call made", part);
    onSearchResult(part);
    setLoading(false);
  };

  return (
    <div className="part-search">
      <select value={brandCode} onChange={(e) => setBrandCode(e.target.value)}>
        {brands.map((brand) => (
          <option key={brand.brandCode} value={brand.brandCode}>
            {brand.description} ({brand.brandCode})
          </option>
        ))}
      </select>
      <input
        type="text"
        placeholder="Enter Part Code"
        value={partCode}
        onChange={(e) => setPartCode(e.target.value)}
      />
      <button onClick={handleSearch} disabled={loading}>
        {loading ? "Searching..." : "Search"}
      </button>
    </div>
  );
};

export default PartSearch;
