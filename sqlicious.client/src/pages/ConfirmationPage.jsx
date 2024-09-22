import React from 'react';
import { useLocation } from 'react-router-dom';
import './confirmationPage.css';

const ConfirmationPage = () => {
    const location = useLocation();
    const { selectedTime, selectedTable, selectedAmount, selectedFood, selectedDate, customerDetails } = location.state || {};

    return (
        <div>
            <p>Tack för din Bokning, <strong>{customerDetails.firstName}</strong></p>
            <p>Din bokning är nu bekräftad.</p>
            <h3>Booking Details:</h3>
            <p><strong>Måltids typ:</strong> {selectedFood}</p>
            <p><strong>Datum:</strong> {selectedDate}</p>
            <p><strong>Tid:</strong> {selectedTime}</p>
            <p><strong>Bord:</strong> {selectedTable}</p>
            <p><strong>Antal Gäster:</strong> {selectedAmount}</p>
            <h3>Kontaktinformation:</h3>
            <p><strong>Namn:</strong> {customerDetails.firstName} {customerDetails.lastName}</p>
            <p><strong>Email:</strong> {customerDetails.email}</p>
            {customerDetails.phone && <p><strong>Mobil:</strong> {customerDetails.phone}</p>}
        </div>
    );
};

export default ConfirmationPage;
