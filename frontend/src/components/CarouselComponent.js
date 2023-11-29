import React from 'react'
import Image1 from "./ComponentImages/image1.jpg"
import Image2 from "./ComponentImages/image2.jpg"
import Image3 from "./ComponentImages/image3.jpg"
import Carousel from "react-grid-carousel"
import {CarouselContainer, CarouselImage} from './TextElements';


function CarouselComponent() {
  return (
    
    <CarouselContainer>
    <Carousel cols={3} rows={1} gap={1} autoplay={3500} loop>
      <Carousel.Item>
        <CarouselImage src={Image1}></CarouselImage>
      </Carousel.Item>
      <Carousel.Item>
        <CarouselImage src={Image2}></CarouselImage>
      </Carousel.Item>
      <Carousel.Item>
        <CarouselImage src={Image3}></CarouselImage>
      </Carousel.Item>

      <Carousel.Item>
        <CarouselImage src={Image3}></CarouselImage>
      </Carousel.Item>
      <Carousel.Item>
        <CarouselImage src={Image2}></CarouselImage>
      </Carousel.Item>
      <Carousel.Item>
        <CarouselImage src={Image1}></CarouselImage>
      </Carousel.Item>
    </Carousel>
   </CarouselContainer>
  )
}

export default CarouselComponent