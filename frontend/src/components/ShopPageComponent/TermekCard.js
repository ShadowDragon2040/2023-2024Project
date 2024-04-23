import React from 'react';
import { NavLink } from 'react-router-dom';
import { TermekButtonCard, TermekImage } from '../TextElements';

function TermekCard(props) {
  const { id, item } = props; // Destructure props

  return (
    <NavLink style={{ textDecoration: 'none' }} key={id} className="col-4" to={"/ShopPage/" + item.termekId}>
      <TermekButtonCard>
        <div>
          <TermekImage className="card-img-top" src={item.keputvonal} alt={item.termekNev} /> {/* Provide a meaningful alt attribute */}
          <h5 className="card-title">{item.termekNev}</h5>
          <p>{item.leiras}</p>
          <p className='font-weight-bold'>Price: {item.ar}. -HUF</p>
        </div>
      </TermekButtonCard>
    </NavLink>
  );
}

export default TermekCard;
