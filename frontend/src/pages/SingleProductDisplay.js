import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { NavLink, useParams } from 'react-router-dom';
import { MdArrowBack } from "react-icons/md";
import InnerImageZoom from 'react-inner-image-zoom';
import { CommentSection } from 'react-comments-section';
import 'react-comments-section/dist/index.css';
import Navbar from '../components/Navbar';
import {Rating} from 'react-simple-star-rating';
import Footer from '../components/Footer';
import { TbSend } from "react-icons/tb";

function SingleProductDisplay() {
    const { ProductId } = useParams();
    const [itemData, setItemData] = useState({});
    const [commentsData, setCommentData] = useState([]);
    const [rating, setRating] = useState(0);
    const [commentString, setCommentString] = useState("");

    const handleRating = (rate) => {
        setRating(rate);
    }


    const handleCommentSubmit = async () => {
        try {
            console.log(commentString);
            console.log(rating);

            setCommentString("");
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

        const fetchComments = async () => {
            try {
                const response = await axios.get(`http://localhost:5219/Hozzaszolas/termek/${ProductId}`);
                setCommentData(response.data); 
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
                        <MdArrowBack />
                    </NavLink>
                        <div className=' rounded mx-auto d-flex flex-row mt-2 FirstRow'>
                            <InnerImageZoom
                                className='ImageZoom w-100'
                                src={"/" + itemData.keputvonal}
                                zoomSrc={"/" + itemData.keputvonal}
                                fullscreenOnMobile={true}
                                moveType="drag"
                                zoomScale={1.3}
                                zoomPreload={true}
                            />
                            <div className='card-body rounded w-100 p-4'>
                                <h4>{itemData.termekNev}</h4>
                                <p>{itemData.leiras}</p>
                                {itemData.menyiseg && <p>Available: {itemData.menyiseg} pieces</p>}
                                {itemData.ar && <h3>{itemData.ar} -Ft</h3>}
                            </div>
                        </div>
                    
                    <div className="row align-items-start">
                        <div className='rounded mx-auto d-flex flex-row'>
                            <div className='wrapper card-body rounded mt-3 w-100 p-2'>
                                    <Rating
                                        onClick={handleRating}
                                    />
                                    <CommentSection
                                      
                                        currentUser={{
                                            currentUserId: 'YourUserId',
                                            currentUserFullName: 'YourUserName',
                                            currentUserImg: 'YourUserImageURL'
                                        }}
                                    />
                                
                                   
                              
                                    
                                 
                                
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
