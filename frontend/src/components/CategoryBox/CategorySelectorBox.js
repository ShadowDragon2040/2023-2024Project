import React, { useState, useEffect, useRef } from 'react';

const CategorySelector = () => {
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
    // Adjust the height of the input field based on its content
    if (inputRef.current) {
      inputRef.current.style.height = 'auto';
      inputRef.current.style.height = `${inputRef.current.scrollHeight}px`;
    }
  }, [displayedCategory]);

  return (
    <div>
      <h5>Categories</h5>
      <div>
        <input
          className='form-select'
          disabled
          type="text"
          value={displayedCategory}
          readOnly
          ref={inputRef}
          style={{ height: 'auto', minHeight: '20px' }}
        />
      </div>
      <div>
        {['Category 1', 'Category 2', 'Category 3'].map((category) => (
          <div key={category}>
            <label>
              <input
                style={{marginLeft:'50px'}}
                type="checkbox"
                value={category}
                checked={selectedCategories.includes(category)}
                onChange={() => handleCheckboxChange(category)}
              />
              {category}
            </label>
          </div>
        ))}
      </div>
    </div>
  );
};

export default CategorySelector;
