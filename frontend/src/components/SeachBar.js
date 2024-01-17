import React, { useRef, useState } from 'react';
import { FaSearch, FaMicrophone } from 'react-icons/fa';

function SearchBar() {
  const inputRef = useRef(null);
  const [listening, setListening] = useState(false);
 
 

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
      inputRef.current.value = query;
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

  return (
    <div className="form">
      <div className="input-container">
        <FaSearch className="search-icon" size={30}/>
       
          <>
            <input
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
          </>
       
      </div>
    </div>
  );
}

export default SearchBar;
