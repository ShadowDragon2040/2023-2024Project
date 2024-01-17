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
    
    <div className="card"  key={item.termekId}>
    <img className="card-img-top image-fluid" src={item.keputvonal} alt="Card image cap"/>
    <div className="card-body">
      <h5 className="card-title">{item.termekNev}</h5>
      <p className="card-text">{item.leiras}</p>
      <a href="#" className="btn btn-primary">Go somewhere</a>
    </div>
  </div>
  ));

  return (
    <div>
      {cards}
    </div>
  );
}

export default GetTermekek;
