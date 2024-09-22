import React, { useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { createCustomer, updateTable, reserveBooking } from '../Services/RestaurantService';
import './contactPage.css';

const ContactPage = () => {
    const location = useLocation();
    const navigate = useNavigate();

    const { selectedFood, selectedDate, selectedTime, selectedAmount, tableId } = location.state || {};

    const formatDate = (dateString) => {
        const date = new Date(dateString);
        return `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`;
    };
    
    // Function to format the time in HH:MM format, excluding seconds
    const formatTime = (timeString) => {
        const [hours, minutes] = timeString.split(':'); // Split time string by ':'
        return `${hours}:${minutes}`; // Return only hours and minutes, excluding seconds
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
    
                const customerResponse = await createCustomer(customer);
    
                if (!customerResponse || !customerResponse.data) {
                    throw new Error('Customer ID is undefined in the response');
                }
    
                const customerId = customerResponse.data;
    
                // Step 2: Update Table (mark it as unavailable)
                const tableUpdate = { isAvailable: false };
                await updateTable(tableUpdate, tableId);
    
                // Step 3: Extract only the date part (YYYY-MM-DD) from selectedDate
                const dateOnly = selectedDate.split('T')[0]; // Strip the time portion of the date
                const combinedDateTime = `${dateOnly}T${selectedTime}:00`; // Append selected time
    
                console.log('Corrected DateTime:', combinedDateTime); // Log to ensure correctness
    
                const booking = {
                    amountOfCustomers: selectedAmount,
                    bookedDateTime: combinedDateTime, // Send corrected date and time string
                    customerId: customerId,
                    tableId: tableId,
                };
    
                console.log('Booking Payload:', booking); // Log the payload being sent
    
                // Step 4: Call reserveBooking API to create the booking
                const bookingResponse = await reserveBooking(booking);
    
                // Step 5: Navigate to Confirmation Page
                navigate('/confirmation', {
                    state: { 
                        ...location.state, 
                        customerDetails: {
                            firstName: customerDetails.firstName,
                            lastName: customerDetails.lastName,
                            email: customerDetails.email,
                            phone: customerDetails.phone,
                        },
                        selectedDate: formatDate(selectedDate), // Convert date to local time
                        selectedTime: formatTime(selectedTime), // Convert time to local time
                        bookingDetails: bookingResponse.data
                    }
                });
            } catch (error) {
                if (error.response && error.response.data && error.response.data.errors) {
                    console.error('Validation errors:', error.response.data.errors);
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
