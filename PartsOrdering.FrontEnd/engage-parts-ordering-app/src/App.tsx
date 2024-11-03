// src/App.tsx
import React, { useState } from "react";
import OrderReference from "./components/OrderReference";
import PartSearch from "./components/PartSearch";
import PartDetails from "./components/PartDetails";
import OrderSummary from "./components/OrderSummary";
import Checkout from "./components/Checkout";
import "./App.css";

interface Part {
  partCode: string;
  description: string;
  stock: number;
  price: number;
}

interface OrderItem {
  part: Part;
  quantity: number;
}

const App: React.FC = () => {
  const [orderReference, setOrderReference] = useState<string>("");
  const [selectedPart, setSelectedPart] = useState<Part | null>(null);
  const [orderItems, setOrderItems] = useState<OrderItem[]>([]);

  const handleSearch = (partCode: string) => {
    const part: Part = {
      partCode: partCode,
      description: "Sample Battery",
      stock: 15,
      price: 116.07,
    };
    setSelectedPart(part);
  };

  const handleAddToOrder = (part: Part, quantity: number) => {
    setOrderItems([...orderItems, { part, quantity }]);
  };

  const handleRemoveItem = (index: number) => {
    setOrderItems(orderItems.filter((_, i) => i !== index));
  };

  const handleCheckout = () => {
    alert("Order placed successfully!");
    setOrderItems([]);
  };

  return (
    <div className="App">
      <h1>Parts Ordering System</h1>
      <OrderReference onReferenceChange={setOrderReference} />
      <PartSearch onSearch={handleSearch} />
      <PartDetails part={selectedPart} onAddToOrder={handleAddToOrder} />
      <OrderSummary orderItems={orderItems} onRemoveItem={handleRemoveItem} />
      <Checkout onCheckout={handleCheckout} />
    </div>
  );
};

export default App;
