import React, { useRef } from 'react';
import { FaSearch } from 'react-icons/fa';

function SearchBar() {
  const inputRef = useRef(null);

  const handleIconClick = () => {
    if (inputRef.current) {
      inputRef.current.focus();
    }
  };

  return (
    <div className="form">
      <div className="input-container">
        <input
          ref={inputRef}
          type="text"
          className="form-control"
          id="searchbarId"
          placeholder="Search anything..."
        />
        <FaSearch className="search-icon" size={24} onClick={handleIconClick} />
      </div>
    </div>
  );
}

export default SearchBar;
