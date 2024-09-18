import React, { useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { createCustomer, reserveBooking } from '../Services/RestaurantService';
import './contactPage.css';

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

    // Handler to create customer and navigate to confirmation page
    const handleBooking = async () => {
        if (customerDetails.firstName && customerDetails.lastName && customerDetails.email) {
            try {
                // Step 1: Create Customer
                const customer = {
                    firstName: customerDetails.firstName,
                    lastName: customerDetails.lastName,
                    email: customerDetails.email,
                    phone: customerDetails.phone || null,
                };
    
                console.log('Customer Payload:', customer); // Log customer payload for debugging
    
                const customerResponse = await createCustomer(customer);
                const customerId = customerResponse.data.id; // Assuming the backend returns the created customer ID
    
                // Step 2: Reserve Booking
                const bookedDateTime = new Date().toISOString(); // Ensure the date is in ISO format
    
                // Ensure amount of customers and tableId are set correctly
                if (!selectedAmount || !tableId) {
                    alert("Please select the number of customers and a table.");
                    return;
                }
    
                const booking = {
                    amountOfCustomers: selectedAmount, // Set to the selected number of customers
                    bookedDateTime: bookedDateTime, // Use ISO format for bookedDateTime
                    customerId: customerId, // Use the ID from the created customer
                    tableId: tableId, // Use the selected tableId
                };
    
                console.log('Booking Payload:', booking); // Log booking payload for debugging
    
                const bookingResponse = await reserveBooking(booking);
    
                // Step 3: Navigate to Confirmation Page
                navigate('/confirmation', { state: { ...location.state, customerDetails: customerResponse.data, bookingDetails: bookingResponse.data } });
            } catch (error) {
                if (error.response) {
                    console.error('Error response:', error.response.data);
                    alert(`Error: ${error.response.data.title || 'Unable to process request'}`);
                } else {
                    console.error('Error:', error);
                    alert('There was an issue processing the booking. Please try again.');
                }
            }
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
