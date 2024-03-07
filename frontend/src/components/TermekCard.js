import React  from 'react';
import { NavLink } from 'react-router-dom/cjs/react-router-dom.min';

function TermekCard(props) {

  return (
    <NavLink  key={props.item.termekId} className="col-4" to={"/ShopPage/"+props.item.termekId}>
      <button className="btn cardbtn">
        <div className="card border-dark rounded ">
          <div className="card-body">
            <img className="card-img-top " src={props.item.keputvonal} alt="Image not found!" />
            <h5 className="card-title">{props.item.termekNev} </h5>
            <p>{props.item.leiras}</p>
            <p className='font-weight-bold'>{props.item.ar}. -HUF</p>
          </div>
        </div>
      </button>
    </NavLink>
  );
}

export default TermekCard;
