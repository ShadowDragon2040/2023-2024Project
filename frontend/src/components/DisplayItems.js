import React from 'react'
import { InfoContainer3, ItemContainer,CarouselContainer } from './TextElements'
import GetTermekek from './hooks/GetTermekek'
import CarouselComponent from './CarouselComponent'
import { NavLink } from 'react-router-dom/cjs/react-router-dom.min'
function NewItemsComponent (props) {
  return (
    <>
    <CarouselContainer>
    <InfoContainer3>
      OFFER OF THE WEEK
    </InfoContainer3>

    <CarouselComponent/>
    </CarouselContainer>

    <ItemContainer>
        <GetTermekek setSingleItem={props.setSingleItem} setItemData={props.setItemData}/>

    </ItemContainer>
    </>
  )
}

export default NewItemsComponent