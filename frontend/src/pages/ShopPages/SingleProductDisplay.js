import axios from 'axios';
import React, { useEffect, useState } from 'react';
import {useParams } from 'react-router-dom';
import { MdArrowBack } from "react-icons/md";
import InnerImageZoom from 'react-inner-image-zoom';
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

        /*const existingItemIndex = cart.findIndex(item =>
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
        }*/
       
    };

    const [singleProductData, setSingleProductData] = useState({});
   
    const url = `${process.env.REACT_APP_BASE_URL}Termekek/EgyTermek/`;

    useEffect(() => {
        axios.get(url + ProductId)
            .then(response => {
                setSingleProductData(response.data);
                const transformedComments = response.data.hozzaszolasok.map(productData => ({
                    //userId: productData.felhasznaloId.toString(),
                    comId: productData.hozzaszolasId.toString(),
                    fullName: productData.loginNev,
                    avatarUrl: `${process.env.REACT_APP_KEP_URL}ppp.png`,
                    text: productData.leiras,
                    userProfile: '',
                    replies: []
                }));
                
            })
            .catch(error => console.error('Error fetching product data:', error));
    }, [singleProductData]);

   
    

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
                </div>
        </InfoContainer10>
        <Footer />
        </>
    );
}

export default SingleProductDisplay;