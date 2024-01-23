import React from 'react'
function DisplaySingleData(props) {
  return (
    <>
        <div className="container">
          <div className="row align-items-start">
            <div className="col-2">
            </div>
            <div className="col-6 w-100">
              <div className='card w-100' style={{margin:'25% 20% 10% 20%'}}>
                <img src={props.ItemData.keputvonal} alt={props.ItemData.termekId}/>
                <div className='card-body'>
                  <h4>{props.ItemData.termekNev} </h4>
                  <p >{props.ItemData.leiras}</p>
                  <p>Raktáron: {props.ItemData.menyiseg} db</p>
                </div>
                  <button onClick={()=>props.setSingleItem(true)}>Vissza</button>
                </div>
            </div>
            <div className="col-4">
            </div>
          </div>
        </div>
    </>
)}
export default DisplaySingleData