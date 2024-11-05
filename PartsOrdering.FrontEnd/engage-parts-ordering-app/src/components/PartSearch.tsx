// src/components/PartSearch.tsx
import React, { useState } from "react";
import { getPartByCode, Part } from "../Services/PartsService";

interface PartSearchProps {
  onSearchResult: (part: Part | null) => void;
}

const PartSearch: React.FC<PartSearchProps> = ({ onSearchResult }) => {
  const [partCode, setPartCode] = useState<string>("");
  const [loading, setLoading] = useState<boolean>(false);

  const handleSearch = async () => {
    setLoading(true);
    const part = await getPartByCode(
      "WHAT IS THE BRAND CODE?",
      partCode,
      1,
      50
    );
    onSearchResult(part); // Send the part data back to the parent component
    setLoading(false);
  };

  return (
    <div className="part-search">
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
