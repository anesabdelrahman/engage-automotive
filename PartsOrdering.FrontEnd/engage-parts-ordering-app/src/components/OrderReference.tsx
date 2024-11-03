// src/components/OrderReference.tsx
import React from "react";

interface OrderReferenceProps {
  onReferenceChange: (value: string) => void;
}

const OrderReference: React.FC<OrderReferenceProps> = ({
  onReferenceChange,
}) => {
  return (
    <div className="order-reference">
      <input
        type="text"
        placeholder="Enter Job Number or VRN"
        onChange={(e) => onReferenceChange(e.target.value)}
      />
      <select>
        <option value="Ford">Ford (F)</option>
        <option value="Consumables">Consumables (C)</option>
      </select>
    </div>
  );
};

export default OrderReference;
