import React, { useState, useEffect } from 'react'
import { InfoContainer3, ItemContainer,CarouselContainer } from './TextElements'
import { NavLink } from 'react-router-dom/cjs/react-router-dom.min'
import "react-responsive-carousel/lib/styles/carousel.min.css";
import { Carousel } from 'react-responsive-carousel';
import {CarouselImage} from './TextElements';
import axios from 'axios'
import TermekCard from './TermekCard'

function NewItemsComponent (props) {
  const [newsList, setNewsList] = useState([]);
  const [data, setData] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:7026/Termekek')
      .then(response => setData(response.data))
      .catch(error => console.error('Hiba a lekérdezés során:', error));
  }, []);

  return (
    <>
      <CarouselContainer>
          <InfoContainer3>
            OFFER OF THE WEEK:
          </InfoContainer3>

          <Carousel style={{width: props.collapsed ? '80%' : '100%',borderRadius: '20px'}} autoPlay={true} infiniteLoop={true} showThumbs={false} showStatus={false}>
            <NavLink to={"/ShopPage/"+25}>
              <CarouselImage src={'http://printfusion.nhely.hu/test/image1.png'} style={{width: props.collapsed ? '80%' : '100%',transition: 'width 0.3s', borderRadius: '20px'}}/>
            </NavLink>
            <NavLink to={"/ShopPage/"+26}>
              <CarouselImage src={'http://printfusion.nhely.hu/test/image2.jpg'} style={{width: props.collapsed ? '80%' : '100%',transition: 'width 0.3s',borderRadius: '20px'}}/>
            </NavLink>
            <NavLink to={"/ShopPage/"+27}>
              <CarouselImage src={'http://printfusion.nhely.hu/test/image3.jpg'} style={{width: props.collapsed ? '80%' : '100%',transition: 'width 0.3s', borderRadius: '20px'}}/>
            </NavLink>
          </Carousel>
      </CarouselContainer>

      <ItemContainer>
          <div className="row">
            <div className="col-md-6">
            <InfoContainer3>
            All products:
            </InfoContainer3>
            </div>
          </div>
          <div className="row w-100">
              {
                data.map(item => (
                  <TermekCard  item={item} key={item.id}/>
                ))
              }
          </div>
      </ItemContainer>
    </>
  )
}

export default NewItemsComponent