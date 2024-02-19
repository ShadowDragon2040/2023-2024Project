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

function SingleProductDisplay() {
    const { ProductId } = useParams();
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

    const [singleProductData, setSingleProductData] = useState([]);
    const [transformedComments, setTransformedComments] = useState(null);
    const url = "http://localhost:5219/Termekek/EgyTermek/";
    
    useEffect(() => {
        axios.get(url + ProductId)
            .then(response => {
                setSingleProductData(response.data);
                const transformedComments = response.data.hozzaszolasok.map(productData => ({
                    userId: productData.felhasznaloId.toString(),
                    comId: productData.hozzaszolasId.toString(),
                    fullName: productData.loginNev,
                    avatarUrl: '', 
                    text: productData.leiras,
                    userProfile: '', 
                    replies: []
                }));
                setTransformedComments(transformedComments);
            })
            .catch(error => console.error('Error fetching product data:', error));
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
                            src={"/" + singleProductData.keputvonal}
                            zoomSrc={"/" + singleProductData.keputvonal}
                            fullscreenOnMobile={true}
                            moveType="drag"
                            zoomScale={1.3}
                            zoomPreload={true}
                        />
                        <div className='card-body rounded w-100 p-4'>
                            <h4>{singleProductData.termekNev}</h4>
                            <p>{singleProductData.termekLeiras}</p>
                            {singleProductData.menyiseg && <p>Available: {singleProductData.menyiseg} pieces</p>}
                            {singleProductData.ar && <h3>{singleProductData.ar} -Ft</h3>}
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

                                    commentData={transformedComments}
                                    
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
