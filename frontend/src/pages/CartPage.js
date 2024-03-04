import React, { useState, useEffect } from "react";

const Cart = ({ cart, setCart, handleChange }) => {
  const [price, setPrice] = useState(0);

  const handleRemove = (id) => {
    const all = cart.filter((item) => item.id !== id);
    setCart(all);
    handlePrice();
  };

  const handlePrice = () => {
    let ar = 0;
    cart.map((item) => (ar += item.amount * item.price));
    setPrice(ar);
  };

  useEffect(() => {
    handlePrice();
  });

  console.log(setCart);

  return (
    <article>
      {cart.map((item) => (
        <div className="cart_box" key={item.id}>
          <div>
            <button onClick={() => handleChange(item, 1)}>+</button>
            <button>{item.amount}</button>
            <button onClick={() => handleChange(item, -1)}>-</button>
          </div>
          <div>
            <span>{item.price}</span>
            <button onClick={() => handleRemove(item.id)}>Remove</button>
          </div>
        </div>
      ))}
      <div className="total">
        <span>Total Price of your Cart</span>
        <span>Euro - {price}</span>
      </div>
    </article>
  );
};

export default Cart;