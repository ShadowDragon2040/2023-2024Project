import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { NavLink, useParams } from 'react-router-dom';
import { MdArrowBack } from "react-icons/md";
import InnerImageZoom from 'react-inner-image-zoom';
import { CommentSection } from 'react-comments-section';
import 'react-comments-section/dist/index.css';
import Navbar from '../components/Navbar';
import { Rating } from 'react-simple-star-rating';
import Footer from '../components/Footer';
import placeholder from "../images/ppp.jpg"

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

    const [singleProductData, setSingleProductData] = useState({});
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
                    avatarUrl: placeholder,
                    text: productData.leiras,
                    userProfile: '',
                    replies: []
                }));
                setTransformedComments(transformedComments);
            })
            .catch(error => console.error('Error fetching product data:', error));
    }, [singleProductData]);

    const handleSubmitComment = (data) => {
        console.log("Submitted comment data:", data);
        axios.post("http://localhost:5219/Hozzaszolas",{
            "hozzaszolasId": 0,
            "felhasznaloId": 1,
            "termekId": ProductId,
            "leiras": data.text,
            "ertekeles": rating
          })
    }

    return (
        <>
            <div className='SingleItemContainer'>
                <Navbar />
                <div className="container mt-3">
                    <NavLink to={"/ShopPage"} className='back-btn'>
                        <MdArrowBack />
                    </NavLink>
                    <div className='bg-dark p-1 rounded mx-auto d-flex flex-row mt-2 FirstRow'>
                        <InnerImageZoom
                            width={1300}
                            className='ImageZoom rounded'
                            src={"/" + singleProductData.keputvonal}
                            zoomSrc={"/" + singleProductData.keputvonal}
                            fullscreenOnMobile={true}
                            moveType="drag"
                            zoomScale={3}
                            zoomPreload={true}
                            />
                        <div className='card-body rounded w-100 p-4'>
                            <h3>{singleProductData.termekNev}</h3>
                            <p>{singleProductData.termekLeiras}</p>
                            {singleProductData.menyiseg && <p>Available: {singleProductData.menyiseg} pieces</p>}
                            {singleProductData.ar && <h3>{singleProductData.ar} -Ft</h3>}
                        </div>
                    </div>

                    <div className="row align-items-start">
                        <div className='rounded mx-auto d-flex flex-row'>
                            <div className='wrapper card-body bg-dark rounded mt-3 w-100 p-2'>
                                <Rating
                                className='m-2'
                                    onClick={handleRating}
                                />
                                <CommentSection
                                    logIn={{
                                        loginLink: 'http://localhost:3000/Login',
                                        signupLink: 'http://localhost:3000/SignUp',
                                    }}

                                      //A currentUser bejelentkezett felhasználó esetén enged kommentelni
                                      //Bejelentkezés után kell beállítani alapesetben null
                                     currentUser={{
                                        currentUserId: 'YourUserId',
                                        currentUserFullName: 'YourUserName',
                                        currentUserImg: 'YourUserImageURL'
                                        }}
                                    overlayStyle={{ backgroundColor: '#fff', color: 'black' }}
                                    //currentUser={null}
                                    submitBtnStyle={{ border: '1px solid black', backgroundColor: 'black' }}
                                    commentData={transformedComments}
                                    onSubmitAction={handleSubmitComment}
                                    titleStyle={{ color: '#378457' }}
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
