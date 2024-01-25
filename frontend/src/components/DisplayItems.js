import React from 'react'
import { InfoContainer3, ItemContainer,CarouselContainer } from './TextElements'
import GetTermekek from './hooks/GetTermekek'
import CarouselComponent from './CarouselComponent'
function NewItemsComponent (props) {
  return (
    <>
    <CarouselContainer>
    <InfoContainer3>
      FEATURED ITEMS
    </InfoContainer3>

    <CarouselComponent/>
    </CarouselContainer>

    <ItemContainer>
        
        <div>
        <GetTermekek setSingleItem={props.setSingleItem} setItemData={props.setItemData}/>
        </div>
    </ItemContainer>
    </>
  )
}

export default NewItemsComponent