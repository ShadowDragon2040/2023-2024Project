import React,{useState,useEffect} from 'react'
import Image1 from "./ComponentImages/image1.jpg"
import Image2 from "./ComponentImages/image2.jpg"
import "react-responsive-carousel/lib/styles/carousel.min.css";
import { Carousel } from 'react-responsive-carousel';
import {CarouselContainer, CarouselImage, InfoContainer} from './TextElements';



function CarouselComponent(props) {
/*
  const [carouselItem,setCarouselItem]=useState([]);

  const url="";
  useEffect(
    fetch(url)
    .then(resp=>resp.json)
    .then((data)=>{setCarouselItem(data.result)})
  )
  const carouselElemek=props.CarouselElemek.map(item=>{
    <Carousel.Item>
    <CarouselImage src={item.src}/>
    <InfoContainer>
    <CarouselItemDetails/>
      
    </InfoContainer>
  </Carousel.Item>
  })
  */
  return (
    
    <CarouselContainer>
      <Carousel autoPlay={true} infiniteLoop={true}>
        <div style={{backgroundColor:"red"}}>
          <img src={Image1}>
          </img>
          <p>

          </p>
        </div>
        <div style={{backgroundColor:"blue"}}>
          <img src={Image2}>
          </img>
          <p>
            
          </p>
        </div>
     
      
    </Carousel>
   </CarouselContainer>
  )
}

export default CarouselComponent