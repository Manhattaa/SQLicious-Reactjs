import { useEffect, useState } from 'react';
import './App.css';
import IndexPage from './pages/IndexPage';
import BookingPage from './pages/BookingPage';
import Header from './components/Header';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

function App() {
    
    return (
        <BrowserRouter>
      <Routes>
        <Route path="/" element={ <><Header /> <IndexPage /> </>} />
        <Route path="/booking" element={<><Header /> <BookingPage /> </>} />
      </Routes>
    </BrowserRouter>
            
    );
}

export default App;