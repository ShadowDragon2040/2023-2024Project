import React, { useState, useEffect } from 'react';
import Navbar from '../../components/MainNavbarComponent';
import Footer from '../../components/FooterComponent';
import { ShopPageContainer } from '../../components/TextElements';
import ShopSideBar from '../../components/ShopPageComponent/ShopSideBar';
import NewsCard from '../../components/ShopPageComponent/NewsCard';
import axios from 'axios';

function NewsPage(props) {
  const [isProfileVisible, setProfileVisible] = useState(false);
  const [newsList, setNewsList] = useState([]);
  const [loading,setLoading]=useState(false);

  useEffect(() => {
    const url = "https://newsapi.org/v2/everything?q=3dprinting&apiKey=ca4e80849f2b4172a7f5e08061fff1d2";
    axios.get(url)
      .then(response => {setNewsList(response.data.articles);setLoading(true);})
      .finally(setLoading(false))
      .catch(error => console.error('Error during fetch:', error));
  }, []);

  return (
    <>
      <ShopPageContainer>
        <Navbar
          isProfileVisible={isProfileVisible}
          setProfileVisible={setProfileVisible}
        />
        <div className="container">
          <div className="row" >
            <div className={`${props.collapsed ? 'col-1' : 'col-3'}`} style={{transition:'width 0.3s'}}>
              <ShopSideBar collapsed={props.collapsed} handleMouseEnter={props.handleMouseEnter} handleMouseLeave={props.handleMouseLeave} />
            </div>
            <div className='col' style={{minHeight:'1500px',marginTop:'80px'}}>
              <h1 className='text-light text-center'>News</h1>
              {loading?newsList.map((item, index) => (
                  <NewsCard item={item} key={index}/>
              )):<div className='spinner-border text-light'></div>}
            </div>
          </div>
        </div>
        <Footer />
      </ShopPageContainer>
    </>
  );
}

export default NewsPage;
