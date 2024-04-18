import axios from 'axios';
import React, { useEffect, useState } from 'react';
import {useParams } from 'react-router-dom';
import { MdArrowBack } from "react-icons/md";
import InnerImageZoom from 'react-inner-image-zoom';
import { jwtDecode } from 'jwt-decode';
import Navbar from '../../components/MainNavbarComponent';
import Footer from '../../components/FooterComponent';
import ColorPicker from '../../components/ShopPageComponent/ColorPickerComponent';
import {
    NavBtn,
    NavBtnLink,
    NiceButton,
    InfoContainer10
} from '../../components/TextElements';

function SingleProductDisplay(props) {
    const { ProductId } = useParams();
    const [selectedColor, setSelectedColor] = useState("");
    const [quantity, setQuantity] = useState(1);
    const [singleProductData, setSingleProductData] = useState({});
    const [transformedComments, setTransformedComments] = useState([]);
    const [commentText, setCommentText] = useState('');
    const [userId, setUserId] = useState('');

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
            color: selectedColor
        };

        props.addToCart(newItem, quantity) 
    };
   
    useEffect(() => {
        axios.get(`${process.env.REACT_APP_BASE_URL}Termekek/EgyTermek/` + ProductId)
            .then(response => {
                setSingleProductData(response.data);
                const transformedComments = response.data.hozzaszolasok.map(productData => ({
                    //userId: productData.felhasznaloId.toString(),
                    comId: productData.hozzaszolasId.toString(),
                    fullName: productData.loginNev,
                    avatarUrl: `${process.env.REACT_APP_KEP_URL}ppp.png`,
                    text: productData.leiras,
                    rating: productData.ertekeles,
                    userProfile: '',
                    replies: []
                }));
                
            })
            .catch(error => console.error('Error fetching product data:', error));
    }, [singleProductData]);

    useEffect(() => {
        const token = localStorage.getItem("LoginToken");
        if (token) {
            const decodedToken = jwtDecode(token);
            setUserId(decodedToken.userId);
        }
    }, []);

    const handleSubmitComment = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post(`${process.env.REACT_APP_BASE_URL}Hozzaszolas`, {
                userId: userId,
                termekId: ProductId,
                leiras: commentText,
                ertekeles: 0
            });
            console.log("Comment posted successfully:", response.data);
            // Refresh comments
            setCommentText('');
            // You might want to refresh comments here
        } catch (error) {
            console.error('Error posting comment:', error);
        }
    };

    const handleRatingChange = async (e, comId) => {
        const rating = parseInt(e.target.value);
        try {
            const response = await axios.post(`${process.env.REACT_APP_BASE_URL}Hozzaszolas/Rating`, {
                comId: comId,
                rating: rating
            });
            console.log("Rating updated successfully:", response.data);
            // Refresh comments
            const updatedComments = transformedComments.map(comment => {
                if (comment.comId === comId) {
                    return { ...comment, rating: rating };
                } else {
                    return comment;
                }
            });
            setTransformedComments(updatedComments);
        } catch (error) {
            console.error('Error updating rating:', error);
        }
    };
    
    return (
        <>
        <InfoContainer10>    
        <Navbar cart={props.cart} />
                <NavBtn style={{margin:'20px 0px 20px 200px'}}>
                    <NavBtnLink to='/ShopPage'><MdArrowBack/>Back</NavBtnLink>
                </NavBtn>
                <div className="container mt-3">
                    <div className='p-1 rounded d-flex flex-row FirstRow'
                    style={{color:'white',backgroundColor:'#059e60'}}>
                        <InnerImageZoom
                            width={1300}
                            className='ImageZoom rounded'
                            src={singleProductData.keputvonal}
                            zoomSrc={singleProductData.keputvonal}
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
                            <br/>
                            <NiceButton style={{backgroundColor:'black',color:'white',marginTop:'20px'}} onClick={handleAddToCart}>Kosárba</NiceButton>
                        </div>
                    </div>

                    <div className="row align-items-start">
                        <div className='rounded mx-auto d-flex flex-row'>
                            <div className='wrapper card-body rounded mt-3 w-100' style={{ backgroundColor: '#059e60' }}>
                                <h3>Comments</h3>
                                {transformedComments.length === 0 && <p>Be the first one to rate our item</p>}
                                {transformedComments.map(comment => (
                                    <div key={comment.comId}>
                                        <div>
                                            <img src={comment.avatarUrl} alt="avatar" />
                                            <strong>{comment.fullName}</strong>
                                            {/* Rating system */}
                                            <select value={comment.rating} onChange={(e) => handleRatingChange(e, comment.comId)}>
                                                <option value="0">No rating</option>
                                                <option value="1">1</option>
                                                <option value="2">2</option>
                                                <option value="3">3</option>
                                                <option value="4">4</option>
                                                <option value="5">5</option>
                                            </select>
                                        </div>
                                        <p>{comment.text}</p>
                                    </div>
                                ))}
                                <form onSubmit={handleSubmitComment}>
                                    <textarea
                                        value={commentText}
                                        onChange={(e) => setCommentText(e.target.value)}
                                        placeholder="Write your comment..."
                                        rows="4"
                                        cols="50"
                                    ></textarea>
                                    <br />
                                    <button type="submit">Post Comment</button>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
        </InfoContainer10>
        <Footer />
        </>
    );
}

export default SingleProductDisplay;