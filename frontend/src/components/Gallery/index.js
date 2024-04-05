import React, { useState } from 'react';
import Carousel from 'react-bootstrap/Carousel';
import 'bootstrap/dist/css/bootstrap.min.css';
import {CarouselContainer, ImgWrap, Img, baseImageUrl} from '../TextElements';

function Gallery() {
  const [index, setIndex] = useState(0);

  const handleSelect = (selectedIndex, e) => {
    setIndex(selectedIndex);
  };

  return(
    <CarouselContainer>
      <Carousel activeIndex={index} onSelect={handleSelect}>
        <Carousel.Item>
            <ImgWrap>
                <Img
                  src={`${baseImageUrl}anycubicphotonmono.jpg`}
                  alt={'Third slide'}
                  className="d-block w-100"
                />
            </ImgWrap>
          <Carousel.Caption>
            <h3>First slide label</h3>
            <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
            <ImgWrap>
                <Img
                  src={`${baseImageUrl}anycubicphotonmono.jpg`}
                  alt={'Third slide'}
                  className="d-block w-100"
                />
            </ImgWrap>
          <Carousel.Caption>
            <h3>Second slide label</h3>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
            <ImgWrap>
                <Img
                  src={`${baseImageUrl}anycubicphotonmono.jpg`}
                  alt={'Third slide'}
                  className="d-block w-100"
                />
            </ImgWrap>
          <Carousel.Caption>
            <h3>Third slide label</h3>
            <p>
              Praesent commodo cursus magna, vel scelerisque nisl consectetur.
            </p>
          </Carousel.Caption>
        </Carousel.Item>
      </Carousel>
    </CarouselContainer>
  );
}

export default Gallery