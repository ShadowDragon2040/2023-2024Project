import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { NavLink, useParams } from 'react-router-dom';
import { MdArrowBack } from "react-icons/md";
import InnerImageZoom from 'react-inner-image-zoom';
import { CommentSection } from 'react-comments-section';
import 'react-comments-section/dist/index.css';
import Navbar from '../components/ShopNavbar';
import { Rating } from 'react-simple-star-rating';
import Footer from '../components/Footer';
import placeholder from "../images/ppp.jpg"
import ColorPicker from './ColorPicker';
import Button from 'react-bootstrap/Button';


function SingleProductDisplay() {
    const { ProductId } = useParams();
    const [rating, setRating] = useState(0);
    const [commentString, setCommentString] = useState("");
    const [selectedColor, setSelectedColor] = useState("");
    const [quantity, setQuantity] = useState(1);
    const [cart, setCart] = useState([]);

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

    const handleColorChange = (color) => {
        setSelectedColor(color);
    };


    const handleQuantityChange = (e) => {
        setQuantity(parseInt(e.target.value));
    };

    const handleAddToCart = () => {
        const newItem = {
            id: ProductId,
            name: singleProductData.termekNev,
            price: singleProductData.ar * quantity,
            quantity: quantity,
            color: selectedColor  // Include the selected color here
        };

        const existingItemIndex = cart.findIndex(item =>
            item.id === ProductId &&
            item.color === selectedColor
        );

        if (existingItemIndex !== -1) {
            const updatedCart = [...cart];
            updatedCart[existingItemIndex].quantity += quantity;
            updatedCart[existingItemIndex].price += singleProductData.ar * quantity;
            setCart(updatedCart);
            console.log('Item already exists in cart. Updated cart:', updatedCart);
        } else {
            setCart(prevCart => [...prevCart, newItem]);
            console.log('Item added to cart:', newItem);
        }
    };



    const handleRemoveFromCart = (itemId) => {
        const updatedCart = cart.filter(item => item.id !== itemId);
        setCart(updatedCart);
    };


    const [singleProductData, setSingleProductData] = useState({});
    const [transformedComments, setTransformedComments] = useState(null);
    const url = "https://localhost:7026/Termekek/EgyTermek/";

    useEffect(() => {
        axios.get(url + ProductId)
            .then(response => {
                setSingleProductData(response.data);
                const transformedComments = response.data.hozzaszolasok.map(productData => ({
                    //userId: productData.felhasznaloId.toString(),
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
        axios.post("http://localhost:7026/Hozzaszolas", {
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
                <Navbar cart={cart} />
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
                            <ColorPicker selectedColor={selectedColor} onColorChange={handleColorChange} />

                            <input type="number" id="quantity" name="quantity" min="1" max="5" value={quantity} onChange={handleQuantityChange} />
                            <br></br>
                            <br></br>
                            <Button onClick={handleAddToCart}>Kosárba</Button>

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
                                    currentUser={{
                                        currentUserId: 'YourUserId',
                                        currentUserFullName: 'YourUserName',
                                        currentUserImg: 'YourUserImageURL'
                                    }}
                                    overlayStyle={{ backgroundColor: '#fff', color: 'black' }}
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