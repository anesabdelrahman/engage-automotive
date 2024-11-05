import React from "react";

interface OrderReferenceProps {
  onReferenceChange: (value: string) => void;
}

const OrderReference: React.FC<OrderReferenceProps> = ({
  onReferenceChange,
}) => {
  return (
    <div className="order-reference">
      <span>*Order Reference</span>
      <input
        type="text"
        placeholder="Enter Job Number or VRN"
        onChange={(e) => onReferenceChange(e.target.value)}
      />
    </div>
  );
};

export default OrderReference;
