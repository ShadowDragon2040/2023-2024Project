import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { animateScroll as scroll } from 'react-scroll';

function GetTermekek(props) {
  const [newsList, setNewsList] = useState([]);
  const [visibleCards, setVisibleCards] = useState(3);

  const setSingleItemData = (item) => {
    scroll.scrollToTop();
    props.setSingleItem(true);
    console.log(item);
    props.setItemData(item);
  };

  useEffect(() => {
    axios.get('http://localhost:5219/Termekek')
      .then(response => setNewsList(response.data))
      .catch(error => console.error('Hiba a lekérdezés során:', error));
  }, []);

  const cards = newsList.slice(0, visibleCards).map(item => (
    <div className="col-md-4 mb-2" key={item.termekId}>

    <button className="btn cardbtn" onClick={() => setSingleItemData(item)}>
      <div className="card w-100 border-dark rounded">
        <div className="card-body">
          <img className="card-img-top" src={item.keputvonal} alt="Image not found!" />
          <h5 className="card-title">{item.termekNev} </h5>
          <p>{item.leiras}</p>
          <p className='font-weight-bold'>{item.ar}. -HUF</p>

        </div>
      </div>
         </button>
    </div>
  ));

  const handleShowMore = () => {
    setVisibleCards(prevVisibleCards => prevVisibleCards + 6);
  };

  return (
    <div>
        <div className="row">
        <div className="col-md-6">
          <h5>NEW ITEMS</h5>
        </div>
      {visibleCards < newsList.length && (
        <div className="col-md-6 text-right mr-5">
          <a className='link' onClick={handleShowMore}>Show More</a>
        </div>
      
      )}
      </div>
      <div className="row w-100">
        {cards}
      </div>
    </div>
  );
}

export default GetTermekek;
