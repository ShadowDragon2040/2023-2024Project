import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { NavLink, useParams } from 'react-router-dom';
import { MdArrowBack } from "react-icons/md";
import InnerImageZoom from 'react-inner-image-zoom';
import { Rating } from 'react-simple-star-rating'
import Navbar from '../components/Navbar';
import Footer from '../components/Footer';
import { TbSend } from "react-icons/tb";

function SingleProductDisplay() {
    const { ProductId } = useParams();
    const [itemData, setItemData] = useState({});
    const [commentData, setCommentData] = useState([]);
    const [rating, setRating] = useState(0);
    const [commentString, setCommentString] = useState("");

    const handleCommentSubmit = async () => {
        try {
           console.log(commentString);
           console.log(rating);

            fetchComments();
            setCommentString("");
        } catch (error) {
            console.log(error);
        }
    };

    const fetchComments = async () => {
        try {
            const response = await axios.get(`http://localhost:5219/Hozzaszolas/termek/${ProductId}`);
            setCommentData(response.data);
        } catch (error) {
            console.log(error);
        }
    };

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
        fetchComments();

    }, [ProductId]);

    const handleRating = (rate) => {
        setRating(rate);
    }

 

    return (
        <>
            <div className='SingleItemContainer'>
                <Navbar />
                <div className="container mt-3">
                    <NavLink to={"/ShopPage"} className='back-btn'>
                        <MdArrowBack />
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
                    <div className="row align-items-start">
                        <div className='mx-auto d-flex flex-row mt-2'>

                            <div className='wrapper card-body rounded mt-3 w-100 p-2'>
                                <div className='sendIcon' onClick={handleCommentSubmit}>
                                    <TbSend />
                                </div>
                                <input
                                    className='input form-control'
                                    type='text'
                                    placeholder='New Comment..'
                                    value={commentString}
                                    onChange={(e) => setCommentString(e.target.value)}
                                />
                                <div>
                                    <Rating
                                        onClick={handleRating}
                                       
                                    />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div className='footerContainer'>
                    <Footer />
                </div>
            </div>
        </>
    );
}

export default SingleProductDisplay;
