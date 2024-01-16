import React from 'react'
import CategorySelectorBox from './CategoryBox/CategorySelectorBox'
import { ShopSidebarContainer } from './TextElements'

function ShopSideBar() {
  return (
    <>
    <ShopSidebarContainer >
      <a href="#">Home</a> <br></br>
      <a href='#'>News</a> <br></br>

      <CategorySelectorBox/>
      <a href='#'>Paints</a> <br></br>
      <a href='#'>Lab</a>
    </ShopSidebarContainer>
   
    </>
  )
}

export default ShopSideBar