import React from 'react';
import { useNavigate } from 'react-router-dom'
import '../pages/indexPage.css';


const IndexPage = () => {
    

    const handleLoginClick = () => {
        navigate = useNavigate();

    const handleLoginClick = () => {
        navigate('/booking');
    };

    return (
        <div id="root">
            
        </div>
    )
    }
};

export default IndexPage;