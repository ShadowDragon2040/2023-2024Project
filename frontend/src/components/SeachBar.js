  import React, { useRef, useState, useEffect } from 'react';
  import { FaSearch, FaMicrophone } from 'react-icons/fa';
  import axios from 'axios';
  import { NavLink } from 'react-router-dom/cjs/react-router-dom.min';
  import {baseUrl} from './TextElements';
  function SearchBar() {
    const inputRef = useRef(null);
    const [listening, setListening] = useState(false);
    const [query, setQuery] = useState("");
    const [termekek, setTermekek] = useState([]);
    const [isInputFocused, setIsInputFocused] = useState(false);

    useEffect(() => {
      const fetchData = async () => {
        try {
          const response = await axios.get(`${baseUrl}Termekek`);
          setTermekek(response.data);
        } catch (error) {
          console.error('Hiba a lekérdezés során:', error);
        }
      };

      fetchData();
    }, []);

    const handleMicrophoneClick = () => {
      if (listening) {
        recognition.stop();
        setListening(false);
      } else {
        recognition.start();
        setListening(true);
      }
    };

    const recognition = new (window.SpeechRecognition || window.webkitSpeechRecognition)();
    recognition.continuous = false;
    recognition.lang = 'en-US';

    recognition.onresult = (event) => {
      const last = event.results.length - 1;
      const query = event.results[last][0].transcript;

      if (inputRef.current) {
        setIsInputFocused(true);
        const updatedValue = query.slice(0, -1);
        setQuery(updatedValue);
        inputRef.current.value = updatedValue;

      }

      console.log('Speech Recognition Result:', query);
    };

    recognition.onerror = (event) => {
      console.error('Speech Recognition Error:', event.error);
    };

    recognition.onnomatch = () => {
      console.log('Speech Recognition: No match');
    };

    recognition.onspeechend = () => {
      recognition.stop();
      setListening(false);
    };

    recognition.onend = () => {
      setListening(false);
    };

    const filteredTermekek = termekek.filter(post => query === '' || post.termekNev.toLowerCase().includes(query.toLowerCase()));

    return (
      <div className="search-bar">
        <div className="input-container">
          <FaSearch className="search-icon" size={30} />
          <input
            onFocus={() => setIsInputFocused(true)}
            onBlur={() => setTimeout(() => setIsInputFocused(false), 200)}
            onChange={(event) => setQuery(event.target.value)}
            ref={inputRef}
            type="text"
            className="form-control form-input"
            id="searchbarId"
            placeholder="Search anything..."
          />
          <FaMicrophone
            size={30}
            className={`microphone-icon ${listening ? 'listening' : ''}`}
            onClick={handleMicrophoneClick}
          />
        </div>

        {isInputFocused && filteredTermekek.length > 0 && (
          <div className='result-k'>
            <div className="result-container">
              {filteredTermekek.map((item, index) => (
                <NavLink style={{ textDecoration: 'none'}} to={'/ShopPage/'+item.termekId}>
                <div className='result-row' key={index}>
                  <div className="result-box">
                    <p key={index}>{item.termekNev}</p>
                  </div>
                </div>
                </NavLink>
              ))}
            </div>
          </div>
        )}

      </div>
    );
  }

  export default SearchBar;
