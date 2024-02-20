import React, { useState } from 'react';

const ColorPicker = () => {
    // Define an array of colors
    const colors = ['#FF0000', '#00FF00', '#0000FF', '#FFFF00', '#00FFFF', '#FF00FF', '#FFFFFF', '#000000'];

    // State to store the selected color
    const [selectedColor, setSelectedColor] = useState(null);

    // Function to handle color selection
    const handleColorSelection = (color) => {
        setSelectedColor(color);
    };

    return (
        <div>
            <h2>Select a Color:</h2>
            <div style={{ display: 'flex', justifyContent: 'center', marginTop: '10px' }}>
                {colors.map((color, index) => (
                    <div
                        key={index}
                        style={{
                            textAlign: 'left',
                            backgroundColor: color,
                            width: '30px',
                            height: '30px',
                            borderRadius: '50%',
                            margin: '5px',
                            cursor: 'pointer',
                            border: selectedColor === color ? '2px solid black' : 'none',
                        }}
                        onClick={() => handleColorSelection(color)}
                    ></div>
                ))}
            </div>
            {selectedColor && (
                <p style={{ textAlign: 'left', marginTop: '10px' }}>
                    Selected Color: <span style={{ color: selectedColor }}>{selectedColor}</span>
                </p>
            )}
        </div>
    );
};

export default ColorPicker;