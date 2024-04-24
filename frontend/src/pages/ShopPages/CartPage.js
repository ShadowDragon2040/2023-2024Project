//import React, { useState, useEffect } from "react";
import { Button } from 'react-bootstrap';
import {
  NavBtnLink, NiceButton, ShopPageContainer,
} from '../../components/TextElements';
import { MdArrowBack } from "react-icons/md";
import Footer from '../../components/FooterComponent';
import Navbar from '../../components/MainNavbarComponent';
import TermekCartCard from '../../components/ShopPageComponent/TermekCartCard';


const CartPage = ({ cart, setCart }) => {

  console.log(setCart);
  console.log(cart);
  const totalPayment = cart.reduce((acc, item) => acc + item.price * item.quantity, 0);
  return (
<>
      <Navbar/>
    <ShopPageContainer>
      <div className='container'>
        <div className='row'>
          <div className='col-xl-6'>
            <div className="card border border-success rounded border-5" style={{ marginTop: "100px", height: '150vh',width:'85vh', float: 'left'}}>
              <div className="card-header">
                <h5 className="card-title">Cart Items</h5>
              </div>
              {cart.map((item, index) => (
                <div key={item.id} style={{ marginBottom: '10px', border: '1px solid #ccc'}}>
                  <TermekCartCard index={index} setCart={setCart} item={item} />
                </div>
              ))}
            </div>
          </div>
          <div className='col-xl-6' style={{minHeight:'1500px'}}>
            <div className='card border border-success rounded border-5' style={{marginTop: "100px", height: '50vh',width:'70vh', float: 'left' }}>
              <div className="card-header">
                <h5 className="card-title">User Information</h5>
              </div>
              <div className='card-body'>
                <img src={`${process.env.REACT_APP_KEP_URL}ppp.jpg`} style={{borderRadius:"150px"}} className='mx-auto' width={"150px"} alt='profilkep' ></img>
                <p>Username:</p>
                <p>Address: </p>
                <p>PhoneNumber: </p>
              </div>
            </div>
            <div className='card border border-success rounded border-5' style={{marginTop: "500px", height: '25vh', width:'70vh' }}>
            <div className='mx-auto' style={{ alignSelf: 'flex-end', marginTop: '50px', width: '80%' }}>
                <h5>Total Payment: {totalPayment}</h5>
                <div className="row">
                    <div className="col-6">
                        <NavBtnLink to='/ShopPage'><MdArrowBack />Vissza a weboldalra</NavBtnLink>
                    </div>
                    <div className="col-6">
                        <NavBtnLink variant="primary" onClick={() => console.log('Fizetés')}>Fizetés</NavBtnLink>
                    </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <Footer className="fixed-bottom" isButtom={true}/>
    </ShopPageContainer>
</>

  );

};

export default CartPage;
