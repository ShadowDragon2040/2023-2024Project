import React, { useState, useEffect } from 'react';
import axios from 'axios';


function GetTermekek(props) {
  const [newsList, setNewsList] = useState([]);

  const setSingleItemData=(item)=>{
    props.setSingleItem(false);
    console.log(item);
    props.setItemData(item);
  }

  useEffect(() => {
    axios.get('http://localhost:5219/Termekek')
      .then(response => setNewsList(response.data))
      .catch(error => console.error('Hiba a lekérdezés során:', error));
  }, []);

  const cards = newsList.map(item => (
    <div className="col-sm-4" key={item.termekId}>
      <div className="card border-dark rounded" style={{ width: '100%', minHeight: '15vw', margin: '0px 10px 10px 10px', boxShadow: '0 4px 8px rgba(0, 0, 0, 0.1)' }}>
      <div className="card-body bg-success">
          <h5 className="card-title">{item.termekNev}</h5>
          <img className="card-img-top" src={item.keputvonal} alt="Card image cap" style={{ height:'100%', objectFit: 'cover',margin:'1vw 0vw 1vw 0vw' }} />
          <button className="btn btn-dark" onClick={() => setSingleItemData(item)}>Details</button>

        </div>
      </div>
    </div>
  ));

  return (
    <div className="row">
      {cards}
    </div>
  );
}

export default GetTermekek;
