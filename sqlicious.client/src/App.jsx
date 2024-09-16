import { useEffect, useState } from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './App.css';
import IndexPage from './pages/IndexPage';
import BookingPage from './pages/BookingPage';
import Header from './components/Header';
import ContactPage from './pages/ContactPage';
import ConfirmationPage from './pages/ConfirmationPage';

function App() {
    
    return (
        <BrowserRouter>
      <Routes>
        <Route path="/" element={ <><Header /> <IndexPage /> </>} />
        <Route path="/booking" element={<><Header /> <BookingPage /> </>} />
        <Route path="/contact" element={<><Header /> <ContactPage /> </>} />
        <Route path="/confirm" element={<><Header /> <ConfirmationPage /> </>} />
      </Routes>
    </BrowserRouter>
            
    );
}

export default App;