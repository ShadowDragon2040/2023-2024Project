import React, { useState, useEffect, useRef } from 'react';
import { BiCategory } from "react-icons/bi";

const CategorySelector = (props) => {
  const [selectedCategories, setSelectedCategories] = useState([]);
  const inputRef = useRef(null);

  useEffect(() => {
    if (inputRef.current) {
      inputRef.current.style.height = 'auto';
      inputRef.current.style.height = `${inputRef.current.scrollHeight}px`;
    }
  }, [selectedCategories]);

  const handleCheckboxChange = (category) => {
    const updatedCategories = selectedCategories.includes(category)
      ? selectedCategories.filter((selectedCategory) => selectedCategory !== category)
      : [...selectedCategories, category];

    setSelectedCategories(updatedCategories);
 
  }

  return (
    <div>
      <h5 className='p-2 menupont'>
        <BiCategory/> Kategories
      </h5>
        <ul>
          {props.tagsList.map((category) => (
            <div key={category} className='form-check form-switch menupont'>
              <label>
                {category}
                <input
                  className='form-check-input bg-success'
                  id="flexSwitchCheckDefault"
                  type="checkbox"
                  value={category}
                  checked={selectedCategories.includes(category)}
                  onChange={() => handleCheckboxChange(category)}
                />
              </label>
            </div>
          ))}
        </ul>
    </div>
  );
}

export default CategorySelector;
