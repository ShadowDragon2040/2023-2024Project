import React, { useState } from 'react';
import ReactDOM from 'react-dom';
import Modal from 'react-modal';

// A saját stílusokat itt definiálhatod
const customStyles = {
  content: {
    top: '50%',
    left: '50%',
    right: 'auto',
    bottom: 'auto',
    marginRight: '-50%',
    transform: 'translate(-50%, -50%)',
  },
};

// Az alkalmazás gyökérelemét állítsd be a modalhoz
Modal.setAppElement('#root');

function ProfilePage() {
  const [modalIsOpen, setModalIsOpen] = useState(false);

  // Felhasználó bejelentkezésekor hívódik meg
  function handleLogin() {
    setModalIsOpen(true);
  }

  // Modal bezárása
  function closeModal() {
    setModalIsOpen(false);
  }

  return (
    <div>
      <button onClick={handleLogin}>Bejelentkezés</button>
      <Modal
        isOpen={modalIsOpen}
        onRequestClose={closeModal}
        style={customStyles}
        contentLabel="Bejelentkezett Felhasználó"
      >
        <h2>Bejelentkezett Felhasználó</h2>
        {/* Itt jelenítsd meg az aktuálisan bejelentkezett felhasználót */}
        {/* Például: */}
        <p>Felhasználónév: JohnDoe</p>
        <button onClick={closeModal}>Bezárás</button>
      </Modal>
    </div>
  );
}

ReactDOM.render(<ProfilePage />, document.getElementById('root'));
