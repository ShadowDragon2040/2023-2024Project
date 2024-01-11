import React from 'react'
import "../App.css"
function SearchBar() {
  return (
    <>
        <div className="form">
        <i className="fa fa-search" aria-hidden="true"></i>
        <input type="text" class="form-control form-input" placeholder="Search anything..."/>
        </div>
    </>
  )
}

export default SearchBar