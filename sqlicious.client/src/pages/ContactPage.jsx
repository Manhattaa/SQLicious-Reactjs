import React, { useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import './contactPage.css'; // Make sure this links to the updated CSS

const ContactPage = () => {
    const location = useLocation();
    const navigate = useNavigate();

    const { selectedFood, selectedDate, selectedTime, selectedAmount, tableId } = location.state || {};

    const formatDate = (dateString) => {
        const date = new Date(dateString);
        return `${date.getDate()}/${date.getMonth() + 1}`;
    };

    const formatTime = (timeString) => {
        const [hours, minutes] = timeString.split(':');
        return `${hours}:${minutes.padStart(2, '0')}`;
    };

    const formattedDate = formatDate(selectedDate);
    const formattedTime = formatTime(selectedTime);

    const [customerDetails, setCustomerDetails] = useState({
        firstName: '',
        lastName: '',
        email: '',
        phone: ''
    });

    const handleBooking = () => {
        if (customerDetails.firstName && customerDetails.lastName && customerDetails.email) {
            navigate('/confirmation', { state: { ...location.state, customerDetails } });
        } else {
            alert('Please fill in all required fields.');
        }
    };

    return (
        <div>
            {/* Recap Section */}
            <div className="booking-recap">
                <p>
                    <strong>{selectedAmount} gäster</strong>, {selectedFood.toLowerCase()}, {formattedDate}, {formattedTime}
                    &nbsp;
                    <span className="edit-link" onClick={() => navigate('/')}>Ändra</span>
                </p>
                <p><strong>Table:</strong> {tableId}</p>
            </div>

            {/* Customer Details Form */}
            <div className="customer-form">
                <h2>Kontaktinformation</h2>
                <br />
                <form>
                    <div className="name-fields">
                        <div className="input-container">
                            <input
                                type="text"
                                value={customerDetails.firstName}
                                onChange={(e) => setCustomerDetails({ ...customerDetails, firstName: e.target.value })}
                                required
                            />
                            <label>First Name</label>
                        </div>

                        <div className="input-container">
                            <input
                                type="text"
                                value={customerDetails.lastName}
                                onChange={(e) => setCustomerDetails({ ...customerDetails, lastName: e.target.value })}
                                required
                            />
                            <label>Last Name</label>
                        </div>
                    </div>

                    <div className="input-container">
                        <input
                            type="email"
                            value={customerDetails.email}
                            onChange={(e) => setCustomerDetails({ ...customerDetails, email: e.target.value })}
                            required
                        />
                        <label>Email</label>
                    </div>

                    <div className="input-container">
                        <input
                            type="tel"
                            value={customerDetails.phone}
                            onChange={(e) => setCustomerDetails({ ...customerDetails, phone: e.target.value })}
                        />
                        <label>Phone (Optional)</label>
                    </div>
                </form>
                <br />
            </div>

            {/* Book Button */}
            <div className="book-button-container">
                <button onClick={handleBooking}>Book</button>
            </div>
        </div>
    );
};

export default ContactPage;
