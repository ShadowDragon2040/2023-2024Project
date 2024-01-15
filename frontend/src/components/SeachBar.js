import React from 'react'
import "../App.css"
function SearchBar() {
  return (
    <>
        <div className="form">
        <i className="fa fa-search" aria-hidden={true}></i>
        <input type="text" className="form-control form-input" id='searchbarId' placeholder="Search anything..."/>
        </div>
    </>
  )
}

export default SearchBar