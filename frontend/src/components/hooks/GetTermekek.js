import React, { useState, useEffect } from 'react';
import axios from 'axios';

function GetTermekek() {
  const [newsList, setNewsList] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5219/Termekek')
      .then(response => setNewsList(response.data))
      .catch(error => console.error('Hiba a lekérdezés során:', error));
  }, []);

  const cards = newsList.map(item => (
    <div className="col-sm-4" key={item.termekId}>
      <div className="card" style={{width:"15vw", minHeight:"20vw", margin:"0px 10px 10px 10px"}}>
        <img className="card-img-top image-fluid" src={item.keputvonal} alt="Card image cap" />
        <div className="card-body">
          <h5 className="card-title">{item.termekNev}</h5>
          <p className="card-text">{item.leiras}</p>
          <a href="#" className="btn btn-primary">Go somewhere</a>
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
