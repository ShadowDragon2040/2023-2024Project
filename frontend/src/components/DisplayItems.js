import React, { useState, useEffect } from 'react'
import { InfoContainer3, ItemContainer,CarouselContainer } from './TextElements'
import { NavLink } from 'react-router-dom/cjs/react-router-dom.min'
import Image1 from "./ComponentImages/image1.png"
import Image2 from "./ComponentImages/image2.jpg"
import Image3 from "./ComponentImages/image3.jpg"
import "react-responsive-carousel/lib/styles/carousel.min.css";
import { Carousel } from 'react-responsive-carousel';
import {CarouselImage} from './TextElements';
import axios from 'axios'
import TermekCard from './TermekCard'


function NewItemsComponent (props) {
  const [newsList, setNewsList] = useState([]);
  const [data, setData] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5219/Termekek')
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
            <CarouselImage src={Image1} style={{width: props.collapsed ? '80%' : '100%',transition: 'width 0.3s', borderRadius: '20px'}}/>
            <CarouselImage src={Image2} style={{width: props.collapsed ? '80%' : '100%',transition: 'width 0.3s',borderRadius: '20px'}}/>
            <CarouselImage src={Image3} style={{width: props.collapsed ? '80%' : '100%',transition: 'width 0.3s', borderRadius: '20px'}}/>
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