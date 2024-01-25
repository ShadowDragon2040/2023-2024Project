import React from 'react'
import Image1 from "./ComponentImages/image1.png"
import Image2 from "./ComponentImages/image2.jpg"
import Image3 from "./ComponentImages/image3.jpg"
import "react-responsive-carousel/lib/styles/carousel.min.css";
import { Carousel } from 'react-responsive-carousel';
import {CarouselContainer, CarouselImage} from './TextElements';



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
    
      <Carousel className='bg-dark border border-dark rounded ' autoPlay={true} infiniteLoop={true} showThumbs={false} showStatus={false}>
     
          <CarouselImage src={Image1}/>
          <CarouselImage src={Image2}/>
          <CarouselImage src={Image3}/>
       
     
      
    </Carousel>
  )
}

export default CarouselComponent