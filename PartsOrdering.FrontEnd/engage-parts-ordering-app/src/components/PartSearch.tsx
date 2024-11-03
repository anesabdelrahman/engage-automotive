// src/components/PartSearch.tsx
import React, { useState } from "react";

interface PartSearchProps {
  onSearch: (partCode: string) => void;
}

const PartSearch: React.FC<PartSearchProps> = ({ onSearch }) => {
  const [partCode, setPartCode] = useState<string>("");

  const handleSearch = () => {
    onSearch(partCode);
  };

  return (
    <div className="part-search">
      <input
        type="text"
        placeholder="Enter Part Code"
        value={partCode}
        onChange={(e) => setPartCode(e.target.value)}
      />
      <button onClick={handleSearch}>Search</button>
    </div>
  );
};

export default PartSearch;
