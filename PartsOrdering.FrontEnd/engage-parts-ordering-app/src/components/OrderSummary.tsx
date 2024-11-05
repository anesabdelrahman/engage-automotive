import React from "react";
import { Part } from "../Services/PartsService";

interface OrderItem {
  part: Part;
  quantity: number;
}

interface OrderSummaryProps {
  orderItems: OrderItem[];
  onRemoveItem: (index: number) => void;
}

const OrderSummary: React.FC<OrderSummaryProps> = ({
  orderItems,
  onRemoveItem,
}) => {
  const totalPrice = orderItems.reduce(
    (sum, item) => sum + item.quantity * item.part.price,
    0
  );

  return (
    <div className="order-summary">
      <h3>Order Summary</h3>
      {orderItems.map((item, index) => (
        <div key={index} className="order-item">
          <span>{item.part.description}</span>
          <span>Quantity: {item.quantity}</span>
          <span>£{(item.quantity * item.part.price).toFixed(2)}</span>
          <button onClick={() => onRemoveItem(index)}>Remove</button>
        </div>
      ))}
      <h4>Total: £{totalPrice.toFixed(2)}</h4>
    </div>
  );
};

export default OrderSummary;
