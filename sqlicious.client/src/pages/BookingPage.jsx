import React, { useState, useEffect } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import axios from 'axios';
import './bookingPage.css';

const BookingPage = () => {
    const location = useLocation();
    const navigate = useNavigate();

    const { selectedFood, selectedDate, selectedAmount } = location.state || {};

    const parseDate = (dateStr) => {
        const parsedDate = new Date(dateStr);
        return isNaN(parsedDate) ? new Date() : parsedDate;
    };

    const baseDate = parseDate(selectedDate);
    const [bookedTables, setBookedTables] = useState([]);
    const [selectedTime, setSelectedTime] = useState('');

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

    // Define meal start and end times based on selected food
    const getTimeRange = (food) => {
        const currentMonth = baseDate.getMonth(); // 0-indexed, December is 11
        switch (food) {
            case 'Frukost':
                return ['07:00', '10:00'];
            case 'Brunch':
                return ['10:00', '13:00'];
            case 'Lunch':
                return ['12:00', '15:00'];
            case 'Middag':
                return ['17:00', '23:00'];
            case 'Julbord':
                if (currentMonth === 11) {
                    return ['14:00', '22:00'];
                } else {
                    return ['Unavailable', 'Unavailable'];
                }
            default:
                return ['Invalid', 'Invalid'];
        }
    };

    // Function to generate time slots every 30 minutes
    const generateTimeSlots = (start, end) => {
        const timeSlots = [];
        const [startHour, startMinute] = start.split(':').map(Number);
        const [endHour, endMinute] = end.split(':').map(Number);
        
        let currentHour = startHour;
        let currentMinute = startMinute;

        while (currentHour < endHour || (currentHour === endHour && currentMinute <= endMinute)) {
            const timeSlot = `${String(currentHour).padStart(2, '0')}:${String(currentMinute).padStart(2, '0')}`;
            timeSlots.push(timeSlot);

            // Move 30 minutes forward
            currentMinute += 30;
            if (currentMinute === 60) {
                currentMinute = 0;
                currentHour += 1;
            }
        }
        return timeSlots;
    };

    const [startTime, endTime] = getTimeRange(selectedFood);
    const timeSlots = generateTimeSlots(startTime, endTime);

    const formattedDate = baseDate instanceof Date && !isNaN(baseDate)
        ? `${baseDate.getDate()}/${baseDate.getMonth() + 1}`
        : 'Invalid Date';

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

    const handleTableClick = (tableId) => {
        if (!bookedTables.includes(tableId) && selectedTime) {
            navigate('/contact', {
                state: {
                    selectedFood,
                    selectedDate,
                    selectedTime,
                    selectedAmount,
                    tableId
                }
            });
        } else if (!selectedTime) {
            alert('Please select a time.');
        } else {
            alert(`${tableId} is already booked.`);
        }
    };

    return (
        <div className="restaurant-map">
            <div className="selected-details">
                <p>
                    <strong>{selectedAmount} gäster</strong>, {selectedFood.toLowerCase()}, {formattedDate} {startTime} - {endTime}
                    &nbsp;
                    <span className="edit-link" onClick={handleEditClick}>Ändra</span>
                </p>
            </div>

            {/* Time Selection Section */}
            <div className="time-selection">
                <h1 className="SelectATime-container">Select a Time</h1>
                <br />
                <div className="time-buttons">
                    {timeSlots.map((timeSlot, index) => (
                        <button
                            key={index}
                            className={`time-button ${selectedTime === timeSlot ? 'selected' : ''}`}
                            onClick={() => setSelectedTime(timeSlot)}
                        >
                            {timeSlot}
                        </button>
                    ))}
                </div>
            </div>

            {/* Table Selection Section */}
            <div className="table-selection">
                <h1 className="SelectATable-container">Select a Table</h1>
                <img src="src/assets/RestaurantImager.png" alt="Restaurant Map" className="restaurant-map-img" />
                {tables.map(table => (
                    <div 
                        key={table.id} 
                        className={`table ${table.id} ${bookedTables.includes(table.id) ? 'booked' : ''}`} 
                        style={{ top: table.top, left: table.left }}
                        onClick={() => handleTableClick(table.id)}
                    >
                        {table.id}
                    </div>
                ))}
            </div>
        </div>
    );
};

export default BookingPage;
