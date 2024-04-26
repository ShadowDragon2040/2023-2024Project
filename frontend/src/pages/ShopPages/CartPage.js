//import React, { useState, useEffect } from "react";
import { Button } from 'react-bootstrap';
import {
  ItemContainer,
  NavBtnLink, NiceButton, ShopPageContainer,
} from '../../components/TextElements';
import { MdArrowBack } from "react-icons/md";
import Footer from '../../components/FooterComponent';
import Navbar from '../../components/MainNavbarComponent';
import TermekCartCard from '../../components/ShopPageComponent/TermekCartCard';
import { useEffect, useState } from 'react';
import axios from 'axios';


const CartPage = ({ cart, setCart }) => {

  const [userProfile,setUserProfile]=useState([]);

  useEffect(() => {
    
      try {
        const token=localStorage.getItem("LoginToken");
        const userId=localStorage.getItem("userId");
        axios.get(`${process.env.REACT_APP_BASE_URL}Helyadatok/${userId}`,{
          headers:{'Authorization': 'Bearer ' + token}
        })
        .then(response=>setUserProfile(response.data[0]))
      } catch (error) {
        console.error('Error fetching user profile:', error);
      }
    
  },[userProfile])


  const totalPayment = cart.reduce((acc, item) => acc + item.price * item.quantity, 0);
  return (
<>
    <ShopPageContainer>
      <Navbar/>

        <div className='row'>
          <div className='col-xl-6 col'>
            <div className="card border border-success rounded border-5" style={{ marginTop: "100px",marginLeft:'50px', height: '150vh',width:'70%', float: 'left'}}>
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
          <div className='col-xl-6 col' style={{minHeight:'1500px'}}>
            <div className='card border border-success rounded border-5' style={{marginTop: "100px", height: '50vh',width:'50%', float: 'left' }}>
              <div className="card-header">
                <h5 className="card-title">User Information</h5>
              </div>
              <div className='card-body'>
                <div className='row'>

                <div className='col'>
                  <img src={`${process.env.REACT_APP_KEP_URL}ppp.jpg`} style={{borderRadius:"150px",position:'relative',float:'left'}} className='mx-auto' width={"150px"} alt='profilkep' ></img>
                </div>
                <div className='col'>

                  <p>
                    <strong>Country:</strong>
                    <br/>
                    {userProfile.orszagNev}
                    </p> 
                  <p>
                    <strong>City:</strong>
                    <br/>
                    {userProfile.varosNev}
                  </p> 
                  <p>
                    <strong>Street:</strong>
                    <br/>
                    {userProfile.utcaNev}
                  </p> 
                  <p>
                    <strong>House Number:</strong>
                    <br/>
                    {userProfile.hazszam}
                  </p>
                  <p>
                    <strong>Other:</strong>
                    <br/>
                    {userProfile.egyeb}
                  </p>

                </div>
              </div>
            </div>
              <div className='card border border-success rounded border-5' style={{marginTop: "200px", height: '100%', width:'100%' }}>
            <div className='mx-auto' style={{padding:'20px', width: '100%' }}>
                <h5>Total Payment: {totalPayment}</h5>
                <div className="row">
                    <div className="col">
                        <NavBtnLink to='/ShopPage'><MdArrowBack />Back</NavBtnLink>
                    </div>
                    <div className="col">
                        <NavBtnLink variant="primary" onClick={() => console.log('Fizetés')}>Payment</NavBtnLink>
                    </div>
                </div>
              </div>
            </div>
            </div>

            <br/>
           

        </div>
      </div>
    </ShopPageContainer>
      <Footer isButtom={true}/>
</>

  );

};

export default CartPage;
