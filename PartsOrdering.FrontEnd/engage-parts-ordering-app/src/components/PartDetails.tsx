import React, { useState } from "react";
import { Part } from "../Services/PartsService";

interface PartDetailsProps {
  part: Part | null;
  onAddToOrder: (part: Part, quantity: number) => void;
}

const PartDetails: React.FC<PartDetailsProps> = ({ part, onAddToOrder }) => {
  const [quantity, setQuantity] = useState<number>(1);

  if (!part) return null;

  return (
    <div className="part-details">
      <h3>{part.description}</h3>
      <p>Part Code: {part.partCode}</p>
      <p>Available Stock: {part.quantity}</p>
      <p>Price: £{part.price.toFixed(2)}</p>
      <input
        type="number"
        min="1"
        value={quantity}
        onChange={(e) => setQuantity(parseInt(e.target.value))}
      />
      <button onClick={() => onAddToOrder(part, quantity)}>Add to Order</button>
    </div>
  );
};

export default PartDetails;
