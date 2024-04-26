import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { MdArrowBack } from "react-icons/md";
import InnerImageZoom from 'react-inner-image-zoom';
import { jwtDecode } from 'jwt-decode';
import Navbar from '../../components/MainNavbarComponent';
import Footer from '../../components/FooterComponent';
import ColorPicker from '../../components/ShopPageComponent/ColorPickerComponent';
import { Rating } from 'react-simple-star-rating';
import {
    NavBtn,
    NavBtnLink,
    InfoContainer10,
    CommentButton
} from '../../components/TextElements';
import { toast } from 'react-toastify';

function SingleProductDisplay(props) {
    const { ProductId } = useParams();
    const [selectedColor, setSelectedColor] = useState("");
    const [quantity, setQuantity] = useState(1);
    const [singleProductData, setSingleProductData] = useState({});
    const [transformedComments, setTransformedComments] = useState([]);
    const [commentText, setCommentText] = useState('');
    const [userId, setUserId] = useState('');
    const [ratingStar, setRatingStar] = useState(1);
    const [increment,setIncrement]=useState(0);
    const incrementCounter=()=>{
        setIncrement(increment+1)
      }
    const handleRating = (rate) => {
      setRatingStar(rate)
    }

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
            image:singleProductData.keputvonal,
            quantity: quantity,
            color: selectedColor
        };

        props.addToCart(newItem, quantity)
    };

    useEffect(() => {
        axios.get(`${process.env.REACT_APP_BASE_URL}Termekek/EgyTermek/` + ProductId)
            .then(response => {
                setSingleProductData(response.data);
                const transformedComments = response.data.hozzaszolasok.map(commentData => ({
                    comId: commentData.hozzaszolasId.toString(),
                    fullName: commentData.userName,
                    avatarUrl: commentData.profilKep || `${process.env.REACT_APP_KEP_URL}ppp.jpg`,
                    text: commentData.leiras,
                    rating: commentData.ertekeles,
                    userProfile: '',
                    replies: []
                }));
                setTransformedComments(transformedComments);
            })
            .catch(error => console.error('Error fetching product data:', error));
    }, [increment]);

        const getToken=()=>{
            const token = localStorage.getItem("LoginToken");
            if (token) {
                const decodedToken = jwtDecode(token);
                setUserId(decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata"]);
            }
        }

        const handleSubmitComment = async (e) => {
            e.preventDefault();
            try {
                await getToken();
                if(localStorage.getItem('bejelenkezve')== 'false'){
                    toast.error("Please log in before writing a comment!")
                }
               console.log(ratingStar);
                if (commentText !== "") {
                    const jwtToken = localStorage.getItem("LoginToken");

                        axios.post(`${process.env.REACT_APP_BASE_URL}Hozzaszolas`, {
                            userId: userId,
                            termekId: ProductId,
                            leiras: commentText,
                            ertekeles: ratingStar
                        }, {
                            headers: {
                                'Authorization': `Bearer ${jwtToken}`
                            }
                        }).then(() => {
                            toast.success("Successfully posted comment!");
                        }).catch(error => {
                            console.error('Error posting comment:', error);
                        });
                }
                // Refresh comments
                setCommentText('');
                setRatingStar(1); // Reset rating to default
                setIncrement(increment+1);
            } catch (error) {
                console.error('Error posting comment:', error); 
            }
        };
        

    return (
        <>
            <InfoContainer10>
                <Navbar cart={props.cart} totalQuantity={props.cartItemCount} incrementCounter={incrementCounter} />
                <NavBtn style={{ margin: '20px 0px 20px 200px' }}>
                    <NavBtnLink to='/ShopPage'><MdArrowBack />Back</NavBtnLink>
                </NavBtn>
                <div className="container mt-3">
                    <div className='p-1 rounded d-flex flex-row FirstRow'
                        style={{ color: 'white', backgroundColor: '#059e60' }}>
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
                            <br/>
                            <input type="number" className='form-control w-25 border border-dark' id="quantity" name="quantity" min="1" max="5" value={quantity} onChange={handleQuantityChange} />
                            <br />
                            <CommentButton onClick={handleAddToCart}>Kosárba</CommentButton>
                        </div>
                    </div>

                    <div className="row align-items-start">
                        <div className='rounded mx-auto d-flex flex-row'>
                            <div className='wrapper card-body rounded mt-3 w-100' style={{ backgroundColor: '#059e60', padding: '20px' }}>
                                <h3>Write a comment</h3>
                                <form onSubmit={handleSubmitComment}>
                                    <textarea style={{ width: '100%' }}
                                        value={commentText}
                                        onChange={(e) => setCommentText(e.target.value)}
                                        placeholder="Write your comment..."
                                        rows="4"
                                    ></textarea>
                                    <br />
                                    <p>Rate our item:</p>
                                    <Rating onClick={handleRating} onChange={(e) => setRatingStar(parseInt(e.target.value))} initialValue={ratingStar} required />
                                    <br />
                                    <CommentButton type="submit" >Post Comment</CommentButton>
                                </form>
                                <hr style={{border: '3px solid white'}}></hr>
                                <h3 style={{ marginTop: '20px' }}>Comments</h3>
                                {transformedComments.length === 0 && <p>Be the first one to rate our item</p>}
                                {transformedComments.map(comment => (
                                    <div key={comment.comId} style={{ marginBottom: '20px',color:"black", backgroundColor: 'white', padding: '10px', borderRadius: '5px' }}>
                                        <div style={{ display: 'flex', alignItems: 'center' }}>
                                            <img style={{ width: '50px', height: '50px', borderRadius: '50%', margin: '10px' }} src={comment.avatarUrl} alt="avatar" />
                                            <p>
                                                <strong>{comment.fullName}</strong>
                                                <br/>
                                                Rating: {comment.rating}
                                            </p>
                                        </div>
                                        <p>{comment.text}</p>
                                    </div>
                                ))}
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
