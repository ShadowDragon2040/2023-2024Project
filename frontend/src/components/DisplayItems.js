import React from 'react'
import { ItemContainer } from './TextElements'
import GetTermekek from './hooks/GetTermekek'
import CarouselComponent from './CarouselComponent'

function NewItemsComponent (props) {
  return (
    <>
    <CarouselComponent/>
    <ItemContainer>
        <h5>
            NEW ITEMS
        </h5>
        <div>
        <GetTermekek setSingleItem={props.setSingleItem} setItemData={props.setItemData}/>
        </div>
    </ItemContainer>
    </>
  )
}

export default NewItemsComponent