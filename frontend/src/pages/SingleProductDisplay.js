import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { NavLink, useParams } from 'react-router-dom/cjs/react-router-dom.min';
import { MdArrowBack } from "react-icons/md";
import InnerImageZoom from 'react-inner-image-zoom';

function SingleProductDisplay() {
    const { ProductId } = useParams();
    const [itemData, setItemData] = useState({});

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`http://localhost:5219/Termekek/${ProductId}`);
                setItemData(response.data[0]);
            } catch (error) {
                console.log(error);
            }
        };
    
        fetchData();
        
    }, [ProductId]);
 
    return (
        <>
            <NavLink to={"/ShopPage"} className='back-btn'>
                <MdArrowBack/>
            </NavLink>
            <div className="container">
                <div className="row align-items-start">
                    <div className="col-sm-6 w-100" >
                        <div className='singlecard w-100 mx-auto'  >
                            <InnerImageZoom
                                width={'100%'}
                                src={itemData.keputvonal}
                                zoomSrc={itemData.keputvonal}
                                fullscreenOnMobile={true}
                                moveType="drag"
                                zoomScale={1.3}
                                zoomPreload={true}
                            />
                            <div className='card-body'>
                                <h4>{itemData.termekNev}</h4>
                                <p>{itemData.leiras}</p>
                                {itemData.menyiseg && <p>Raktáron: {itemData.menyiseg} db</p>}
                                {itemData.ar && <h3>{itemData.ar} -Ft</h3>}
                                {itemData.kategoria && <p>Kategória: {itemData.kategoria}</p>}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}

export default SingleProductDisplay;
