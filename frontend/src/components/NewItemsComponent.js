import React from 'react'
import { ItemContainer } from './TextElements'
import GetTermekek from './hooks/GetTermekek'

function NewItemsComponent () {
  return (
    <ItemContainer>
        <h5>
            NEW ITEMS
        </h5>
        <div>
        <GetTermekek/>
        </div>
    </ItemContainer>
  )
}

export default NewItemsComponent