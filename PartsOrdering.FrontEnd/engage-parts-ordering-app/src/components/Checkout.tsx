// src/components/Checkout.tsx
import React from "react";

interface CheckoutProps {
  onCheckout: () => void;
}

const Checkout: React.FC<CheckoutProps> = ({ onCheckout }) => {
  return (
    <div className="checkout">
      <button onClick={onCheckout}>Place Order</button>
    </div>
  );
};

export default Checkout;
