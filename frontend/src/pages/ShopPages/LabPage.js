import React from 'react';
import ReactDOM from 'react-dom';
import {StlViewer} from "react-stl-viewer";

const url = "http://printfusion.nhely.hu/test/skull_art.stl"

const style = {
    top: 0,
    left: 0,
    width: '100vw',
    height: '100vh',
}

function LabPage() {
    return (
        <StlViewer
            style={style}
            orbitControls
            shadows
            url={url}
        />
    );
}

export default LabPage