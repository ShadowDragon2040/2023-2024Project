import React  from 'react';
import { NavLink } from 'react-router-dom';
import { NewsCard,TermekListImage } from '../TextElements'

function TermekCartCard(props) {
  
  return (
    <div>
    <NavLink style={{textDecoration: 'none',width:'100%'}}  key={props.item.id}  to={props.item.url}>
      <NewsCard>
        <TermekListImage style={{minHeight:'200px'}} className="card-img-top" src={props.item.urlToImage} alt="Image not found!" />
        <div style={{marginLeft:"50px"}}>
            <h5 className="card-title">{props.item.name} </h5>
            <p>{props.item.leiras}</p>
            <h4 className='font-weight-bold'>{props.item.title}</h4>
            <p className='font-weight-bold'>{props.item.description}</p>
            <p className='font-weight-bold'>Author: {props.item.author}</p>
            <p className='font-weight-bold'>Published: {props.item.publishedAt}</p>
        </div>
      </NewsCard>
    </NavLink>
   

    </div>

  );
}

export default TermekCartCard;
