import React from 'react';
import InnerImageZoom from 'react-inner-image-zoom';
import { MdArrowBack } from "react-icons/md";

function DisplaySingleData(props) {
  return (
    <>
        <div className='back-btn'>
          <MdArrowBack onClick={() => props.setSingleItem(false)}/>
        </div>
      <div className="container">
        <div className="row align-items-start">
          <div className="col-2">
          </div>
          <div className="col-6 w-100">
            <div className='card singlecard w-100 mx-auto'  >
              <InnerImageZoom
                width={'100%'}
                src={props.ItemData.keputvonal}
                zoomSrc={props.ItemData.keputvonal}
                fullscreenOnMobile={true}
                moveType="drag"
                zoomScale={1.3}
                zoomPreload={true}
              />
              <div className='card-body'>
                <h4>{props.ItemData.termekNev} </h4>
                <p>{props.ItemData.leiras}</p>
                <p>Raktáron: {props.ItemData.menyiseg} db</p>
                <h3>{props.ItemData.ar} -Ft</h3>
                <p>Tagek: {props.ItemData.tagId}</p>
                <p>Színek: {props.ItemData.szinId}</p>
              </div>
            </div>
          </div>
          <div className="col-4">
          </div>
        </div>
      </div>
    </>
  );
}

export default DisplaySingleData;
