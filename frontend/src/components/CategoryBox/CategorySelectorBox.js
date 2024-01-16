import React, { useState } from "react";
import Select, { components } from "react-select";
import { colourOptions } from "./data.js";
import { CategoryContainer, SidebarContainer } from "../TextElements.js";

const Option = (props) => (
  <div>
    <components.Option {...props}>
      <input
        style={{ width: "100%" }}
        name={props.label}
        type="checkbox"
        defaultChecked={props.isSelected}
        readOnly={true}
      />
      <label>{props.label}</label>
    </components.Option>
  </div>
);

//Selection Box styling
const customStyles = {
  control: (provided) => ({
    ...provided,
    backgroundColor: "darkgreen", 
  }),
};

const CategorySelectorBox = () => {
  const [optionSelected, setOptionSelected] = useState(colourOptions);

  const handleChange = (selected) => {
    setOptionSelected(selected);
  };
  
  return (
    <>
      <label>Categories</label>

        
        
      <Select className="react-select-container"
      styles={customStyles}
      components={{
        Option
        
      }}
      options={colourOptions}
      isMulti
      closeMenuOnSelect={false}
      hideSelectedOptions={true}
      onChange={handleChange}
      allowSelectAll={true}
      value={optionSelected}
      />
      </>
  );
};

export default CategorySelectorBox;
