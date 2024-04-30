import {
  NavBtnLink,
  ShopPageContainer,
  NavBtn
} from '../../components/TextElements';
import { MdArrowBack } from "react-icons/md";
import Footer from '../../components/FooterComponent';
import Navbar from '../../components/MainNavbarComponent';
import TermekCartCard from '../../components/ShopPageComponent/TermekCartCard';
import { useEffect, useState } from 'react';
import axios from 'axios';
import { toast } from 'react-toastify';

const CartPage = ({ cart, setCart}) => {

  const [userProfile,setUserProfile]=useState([]);
  const [getUserProfile,setGetUserProfile]=useState([]);
  
  const token = localStorage.getItem("LoginToken");
  const userId = localStorage.getItem("userId");

  useEffect(() => {
      try {
        axios.get(`${process.env.REACT_APP_BASE_URL}Helyadatok/${userId}`,{
          headers:{'Authorization': 'Bearer ' + token}
        })
        .then(response=>setUserProfile(response.data[0]));
      } catch (error) {
        console.error('Error fetching user profile:', error);
      }
  },[])

  useEffect(() => {
    try {
      axios.get(`${process.env.REACT_APP_BASE_URL}Felhasznalok/${userId}`, {
        headers: {'Authorization': 'Bearer ' + token}
      })
      .then(response=>setGetUserProfile(response.data[0]))
     
    } catch (error) {
      console.error('Error fetching user profile:', error);
    }
},[userProfile])

  const handlePayment = async () => {
    try {
      const cart = localStorage.getItem("kosar");
      const response = await axios.post(
        `${process.env.REACT_APP_BASE_URL}Szamlazas/purchaseMail`,
        {
          Cart: cart,
          UserEmail: getUserProfile.email,
          UserId: userId,
          TotalPurchase: totalPayment,
        },
        {
          headers: {
            "Content-Type": "application/json",
            'Authorization': 'Bearer ' + token
          }
        }
      )
      .then(localStorage.setItem("kosar",""))
      .finally(toast.success("Order placed successfully!"));
  
    } catch (error) {
      toast.error("Failed to place order!")
    }
  }


  const totalPayment = cart.reduce((acc, item) => acc + item.price * item.quantity, 0);

  return (
    <ShopPageContainer>
      <Navbar/>
        <NavBtn style={{margin: '100px 0px 0px 50px'}}>
          <NavBtnLink to='/ShopPage'><MdArrowBack />Back</NavBtnLink>
        </NavBtn>
        <div className='row'>
          <div className='col-xl-6 col'>
            <div className="card border border-success rounded border-5" style={{ marginTop: "50px",marginLeft:'50px', minHeight:'500px',width:'70%', float: 'left'}}>
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
            <div className='card border border-success rounded border-5' style={{marginTop: "50px", height: '50vh',width:'50%', float: 'left' }}>
              <div className="card-header">
                <h5 className="card-title">User Information</h5>
              </div>
              <div className='card-body'>
                  <div className='row'>
                    <div className='col'>
                      <img src={`${getUserProfile.profilKep}`} style={{borderRadius:"150px",position:'relative',float:'left'}} className='mx-auto' width={"150px"} alt='profilkep' ></img>
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
            <div className='card border border-success rounded border-5' style={{marginTop: "10px", height: '100%', width:'100%' }}>
            <div className='mx-auto' style={{padding:'20px', width: '100%' }}>
                <h5>Total Payment: {totalPayment}</h5>
                <div className="row">
                    <div className="col">
                        <NavBtnLink to='/ShopPage'><MdArrowBack />Back</NavBtnLink>
                    </div>
                    <div className="col">
                        <NavBtnLink variant="primary" onClick={() => handlePayment()}>Payment</NavBtnLink>
                    </div>
                </div>
              </div>
            </div>
          </div>
          <br/>
        </div>
      </div>
      <Footer/>
    </ShopPageContainer>
  );
};

export default CartPage;
