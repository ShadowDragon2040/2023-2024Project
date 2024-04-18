import React  from 'react';
import { NavLink } from 'react-router-dom';
import { TermekListButtonCard,TermekListImage } from '../TextElements'

function TermekCard(props) {
  
  return (
    <NavLink style={{textDecoration: 'none'}} key={props.item.termekId} className="col" to={"/ShopPage/"+props.item.termekId}>
      <TermekListButtonCard>
        <TermekListImage className="card-img-top" src={props.item.keputvonal} alt="Image not found!" />
        <div style={{marginLeft:"50px"}}>
            <h5 className="card-title">{props.item.termekNev} </h5>
            <p>{props.item.leiras}</p>
            <p className='font-weight-bold'>Price: {props.item.ar}. -HUF</p>
        </div>
      </TermekListButtonCard>
    </NavLink>
  );
}

export default TermekCard;
