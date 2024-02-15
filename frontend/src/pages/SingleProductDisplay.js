import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { NavLink, useParams } from 'react-router-dom';
import { MdArrowBack } from "react-icons/md";
import InnerImageZoom from 'react-inner-image-zoom';
import Navbar from '../components/Navbar';
import Footer from '../components/Footer';

function SingleProductDisplay() {
    const { ProductId } = useParams();
    const [itemData, setItemData] = useState({});
    const [commentData, setCommentData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`http://localhost:5219/Termekek/${ProductId}`);
                setItemData(response.data[0]);
            } catch (error) {
                console.log(error);
            }
        };

        const fetchComments = async () => {
            try {
                const response = await axios.get(`http://localhost:5219/Hozzaszolas/termek/${ProductId}`);
                setCommentData(response.data);
                console.log(response.data);
            } catch (error) {
                console.log(error);
            }
        };

        fetchData();
        fetchComments();
        
    }, [ProductId]);

    return (
        <>
            <div className='SingleItemContainer'>
                <Navbar />
                <div className="container mt-3">
                    <NavLink to={"/ShopPage"} className='back-btn'>
                        <MdArrowBack/>
                    </NavLink>
                    <div className="row align-items-start">
                        <div className='mx-auto d-flex flex-row mt-2'>
                            <InnerImageZoom
                                className='rounded ImageZoom w-100'
                                src={"/" + itemData.keputvonal}
                                zoomSrc={"/" + itemData.keputvonal}
                                fullscreenOnMobile={true}
                                moveType="drag"
                                zoomScale={1.3}
                                zoomPreload={true}
                            />
                            <div className='card-body w-100 p-4'>
                                <h4>{itemData.termekNev}</h4>
                                <p>{itemData.leiras}</p>
                                {itemData.menyiseg && <p>Available: {itemData.menyiseg} pieces</p>}
                                {itemData.ar && <h3>{itemData.ar} -Ft</h3>}
                            </div>
                        </div>
                    </div>
                </div>
                <div className='footerContainer'>
                    <Footer/>
                </div>
            </div>
        </>
    );
}

export default SingleProductDisplay;
