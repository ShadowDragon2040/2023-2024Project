import React  from 'react';
import { NavLink } from 'react-router-dom/cjs/react-router-dom.min';
import { TermekButtonCard,TermekImage } from './TextElements'

function TermekCard(props) {

  return (
    <NavLink style={{textDecoration: 'none'}} key={props.item.termekId} className="col-4" to={"/ShopPage/"+props.item.termekId}>
      <TermekButtonCard>
        <div>
            <TermekImage className="card-img-top" src={props.item.keputvonal} alt="Image not found!" />
            <h5 className="card-title">{props.item.termekNev} </h5>
            <p>{props.item.leiras}</p>
            <p className='font-weight-bold'>Ár: {props.item.ar}. -HUF</p>
        </div>
      </TermekButtonCard>
    </NavLink>
  );
}

export default TermekCard;
