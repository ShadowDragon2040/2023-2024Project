//import React, { useState, useEffect } from "react";
import { Button } from 'react-bootstrap';
import {
  ItemContainer2,
  NavBtnLink, ShopPageContainer,
} from '../../components/TextElements';
import { MdArrowBack } from "react-icons/md";
import Footer from '../../components/FooterComponent';
import Navbar from '../../components/MainNavbarComponent';
import TermekCartCard from '../../components/ShopPageComponent/TermekCartCard';


const CartPage = ({ handleClose, cart, setCart }) => {

  console.log(setCart);
  console.log(cart);
  const totalPayment = cart.reduce((acc, item) => acc + item.price * item.quantity, 0);
  return (

    <ShopPageContainer>

      <Navbar/>

      <div className='container' style={{ height: '150vh' }}>
        <div className='row'>
          <div className='col-xl-6'>
            <div className="card" style={{ marginTop: "100px", height: '150vh', float: 'left' }}>
              <div className="card-header">
                <h5 className="card-title">Cart Items</h5>
              </div>

              {cart.map((item, index) => (
                <div key={item.id} style={{ marginBottom: '10px', border: '1px solid #ccc' }}>
                  <TermekCartCard index={index} setCart={setCart} item={item} />
                </div>
              ))}

              <div className='mx-auto' style={{ alignSelf: 'flex-end', marginRight: '10px', marginTop: '50px', width: '75%' }}>
                <h5>Total Payment: {totalPayment}</h5>
                <div className="card-footer">
                  <NavBtnLink to='/ShopPage'><MdArrowBack />Vissza a weboldalra</NavBtnLink>
                  <Button variant="primary" onClick={() => console.log('Fizetés')}>Fizetés</Button>
                </div>
              </div>
            </div>
          </div>
          <div className='col-xl-6'>
            <div className='card' style={{marginTop: "100px", height: '50vh',width:'50vh', float: 'left' }}>
              <div className="card-header">
                <h5 className="card-title">User Information</h5>
              </div>
              <div className='card-body'>
                <img src="Profilkép" ></img>
                <p>Username:</p>
                <p>Address: </p>
                <p>PhoneNumber: </p>
              </div>
            </div>
          </div>
        </div>
      </div>

      <Footer className="fixed-bottom" isButtom={true}/>

    </ShopPageContainer>


  );

};

export default CartPage;
