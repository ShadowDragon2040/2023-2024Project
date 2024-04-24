import React  from 'react';
import { NavLink } from 'react-router-dom';
import { TermekCartButtonCard,TermekListImage } from '../TextElements'
import { CloseButton } from 'react-bootstrap';

function TermekCartCard(props) {
  
  return (
    <>
    <CloseButton onClick={()=>props.setCart(props.index)} style={{ float: 'right'}}/>
    <NavLink style={{textDecoration: 'none'}}  key={props.item.id} className="col" to={"/ShopPage/"+props.item.id}>
      <TermekCartButtonCard>
        <TermekListImage className="card-img-top" src={props.item.image} alt="Image not found!" />
        <div style={{marginLeft:"50px"}}>
            <h5 className="card-title">{props.item.name} </h5>
            <p>{props.item.leiras}</p>
            <p className='font-weight-bold'>Price: {props.item.price}. -HUF</p>
            <p className='font-weight-bold'>Quantity: {props.item.quantity}</p>
            <p className='font-weight-bold'>Color: {props.item.color}</p>
        </div>
      </TermekCartButtonCard>
    </NavLink>
   

    </>

  );
}

export default TermekCartCard;
