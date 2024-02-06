import React, { useState, useEffect, useRef } from 'react';
import { BiCategory } from "react-icons/bi";


const CategorySelector = (props) => {
  const [selectedCategories, setSelectedCategories] = useState([]);
  const [displayedCategory, setDisplayedCategory] = useState('');
  const inputRef = useRef(null);

  const handleCheckboxChange = (category) => {
    const updatedCategories = selectedCategories.includes(category)
      ? selectedCategories.filter((selectedCategory) => selectedCategory !== category)
      : [...selectedCategories, category];

    setSelectedCategories(updatedCategories);
    updateDisplayedCategory(updatedCategories);
  };

  const updateDisplayedCategory = (categories) => {
    setDisplayedCategory(categories.join(', '));
  };

  useEffect(() => {
    if (inputRef.current) {
      inputRef.current.style.height = 'auto';
      inputRef.current.style.height = `${inputRef.current.scrollHeight}px`;
    }
  }, [displayedCategory]);

  return (
    <div>
      <h5 className='p-2 menupont'>

      <BiCategory/> Sort by Tags
      </h5>        
      <div>
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
    </div>
  );
};

export default CategorySelector;
