import React, { useState } from 'react';

const ColorPicker = ({selectedColor, onColorChange}) => {
    
    const colors = ['red', 'green', 'blue', 'yellow', 'white', 'black'];

    const handleColorSelection = (color) => {
        onColorChange(color);
    };

    return (
        <div>
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
