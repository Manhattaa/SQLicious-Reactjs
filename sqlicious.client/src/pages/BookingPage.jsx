import React, { useState, useEffect } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import axios from 'axios';
import './bookingPage.css';

const BookingPage = () => {
    const location = useLocation();
    const navigate = useNavigate();
    
    // Get the selected food, date, and number of people from the IndexPage
    const { selectedFood, selectedDate, selectedAmount } = location.state || {};

    // Safely parse the date string into a Date object
    const parseDate = (dateStr) => {
        const parsedDate = new Date(dateStr);
        return isNaN(parsedDate) ? new Date() : parsedDate;
    };

    const baseDate = parseDate(selectedDate);

    const [bookedTables, setBookedTables] = useState([]);

    // Example function to fetch table availability
    useEffect(() => {
        axios.get('/api/booking')
            .then(response => {
                const booked = response.data.filter(table => table.isBooked).map(table => table.id);
                setBookedTables(booked);
            })
            .catch(error => {
                console.error('Error fetching bookings:', error);
            });
    }, []);

    // Define meal time ranges based on selected food
    const getTimeRange = (food) => {
        const currentMonth = baseDate.getMonth(); // 0-indexed, December is 11
        switch (food) {
            case 'Frukost':
                return '07:00 - 10:00';
            case 'Brunch':
                return '10:00 - 13:00';
            case 'Lunch':
                return '12:00 - 15:00';
            case 'Middag':
                return '17:00 - 23:00';
            case 'Julbord':
                if (currentMonth === 11) { // Check if it's December
                    return '14:00 - 22:00';
                } else {
                    return 'Unavailable outside December';
                }
            default:
                return 'Invalid meal selection';
        }
    };

    const timeRange = getTimeRange(selectedFood);

    // Format date as "dd/MM"
    const formattedDate = baseDate instanceof Date && !isNaN(baseDate)
        ? `${baseDate.getDate()}/${baseDate.getMonth() + 1}`  // getMonth() is zero-indexed, so we add 1.
        : 'Invalid Date';

    // Navigate back to IndexPage when "Ändra" is clicked
    const handleEditClick = () => {
        navigate('/', {
            state: { selectedFood, selectedDate, selectedAmount }
        });
    };

    // Dummy data for tables
    const tables = [
        { id: 'table1'},
        { id: 'table2'},
        { id: 'table3'},
        { id: 'table4'},
        { id: 'table5'},
        { id: 'table6'},
        { id: 'table7'},
        { id: 'table8'},
        { id: 'table9'},
        { id: 'table10'},
        { id: 'table11'},
        { id: 'table12'},
        { id: 'table13'},
        { id: 'table14'}
    ];

    // Handle table booking click
    const handleBooking = (tableId) => {
        if (!bookedTables.includes(tableId)) {
            axios.post('/api/booking', { tableId })
                .then(() => {
                    setBookedTables([...bookedTables, tableId]);
                    alert(`${tableId} booked successfully!`);
                })
                .catch(() => {
                    alert('Failed to book the table. It may already be booked.');
                });
        } else {
            alert(`${tableId} is already booked.`);
        }
    };

    return (
        <div className="restaurant-map">
            {/* Display selected food, date, amount, and time range */}
            <div className="selected-details">
                <p>
                    <strong>{selectedAmount} gäster</strong>, {selectedFood.toLowerCase()}, {formattedDate} {timeRange}
                    &nbsp;
                    <span className="edit-link" onClick={handleEditClick}>Ändra</span>
                </p>
            </div>

            {/* Table Selection Section */}
            <div className="table-selection">
                <h1>Select a Table</h1>
                <img src="src/assets/RestaurantImager.png" alt="Restaurant Map" className="restaurant-map-img" />

                {tables.map(table => (
                    <div 
                        key={table.id} 
                        className={`table ${table.id} ${bookedTables.includes(table.id) ? 'booked' : ''}`} 
                        style={{ top: table.top, left: table.left }}
                        onClick={() => handleBooking(table.id)}
                    >
                        {table.id}
                    </div>
                ))}
            </div>
        </div>
    );
};

export default BookingPage;
