import React from 'react';
import logo from '../assets/logo.png';
import '../components/header.css';


const Header = () => {
    return (
        <header className="sqlicious-header">
      <div className="logo">
        <img src={logo} alt="SQLicious Logo" /> {/* Replace with your logo path */}
      </div>
      <h1 className="site-title">
        <span className="sql">SQL</span>
        <span className="icious">ICIOUS</span>
      </h1>
    </header>
  );
};

export default Header;