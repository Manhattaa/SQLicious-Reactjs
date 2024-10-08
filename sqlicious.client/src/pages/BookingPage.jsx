import React, { useState, useEffect } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import axios from 'axios';
import './bookingPage.css';
import restaurantMap from '../assets/RestaurantImager.png';

const BookingPage = () => {
    const location = useLocation();
    const navigate = useNavigate();

    const { selectedFood, selectedDate, selectedAmount } = location.state || {};

    const parseDate = (dateStr) => {
        const parsedDate = new Date(dateStr);
        return isNaN(parsedDate) ? new Date() : parsedDate;
    };

    const baseDate = parseDate(selectedDate);
    const [tables, setTables] = useState([]);
    const [selectedTime, setSelectedTime] = useState('');

    // Table positions (can also be fetched from API)
    const tablePositions = [
        { tableId: 1, top: '1%', left: '8.5%' },
        { tableId: 2, top: '1%', left: '81.7%' },
        { tableId: 3, top: '25.7%', left: '5.7%' },
        { tableId: 4, top: '22.5%', left: '31.1%' },
        { tableId: 5, top: '22.5%', left: '57.8%' },
        { tableId: 6, top: '25.8%', left: '85.6%' },
        { tableId: 7, top: '40.7%', left: '18.4%' },
        { tableId: 8, top: '40.7%', left: '46.4%' },
        { tableId: 9, top: '40.7%', left: '71.7%' },
        { tableId: 10, top: '59%', left: '33.7%' },
        { tableId: 11, top: '59%', left: '59%' },
        { tableId: 12, top: '76.6%', left: '9%' },
        { tableId: 13, top: '80.5%', left: '41.3%' },
        { tableId: 14, top: '76.6%', left: '72.4%' }
    ];

    // Fetch available tables from the API
    useEffect(() => {
        const fetchTables = async () => {
            try {
                const tablesResponse = await axios.get('https://localhost:7213/api/Table');
                const bookingsResponse = await axios.get('https://localhost:7213/api/Booking');

                // Filter bookings for the selected date
                const bookingsForDate = bookingsResponse.data.filter(
                    (booking) => {
                        const bookingDate = new Date(booking.bookedDateTime);
                        return bookingDate.toDateString() === baseDate.toDateString();
                    }
                );

                const updatedTables = tablesResponse.data.map((table) => {
                    const isBooked = bookingsForDate.some((booking) => {
                        const bookingTime = new Date(booking.bookedDateTime).toTimeString().substring(0, 5);  // Extract the time part (HH:MM)
                        return booking.tableId === table.tableId && bookingTime === selectedTime;  // Compare time only
                    });

                    const position = tablePositions.find(pos => pos.tableId === table.tableId);

                    return {
                        ...table,
                        isAvailable: !isBooked,  // Set isAvailable based on booking status
                        top: position?.top || '0%',
                        left: position?.left || '0%'
                    };
                });

                setTables(updatedTables);
            } catch (error) {
                console.error('Error fetching tables or bookings:', error);
            }
        };

        if (selectedDate && selectedTime) {
            fetchTables();
        }
    }, [selectedDate, selectedTime]);

    // Define meal start and end times based on selected food
    const getTimeRange = (food) => {
        const currentMonth = baseDate.getMonth();  // 0-indexed, December is 11
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

    const handleTableClick = (tableId) => {
        const selectedTable = tables.find(table => table.tableId === tableId);

        if (selectedTable && selectedTable.isAvailable && selectedTime) {
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
            alert(`${tableId} is not available.`);
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
            <br />
            {/* Table Selection Section */}
            {/* <img src={restaurantMap} alt="Restaurant Map" className="restaurant-map-img" />
            {tables.map((table) => (
                <button
                    key={table.tableId}
                    className={`table ${table.isAvailable ? '' : 'booked'}`}
                    style={{ top: table.top, left: table.left }}
                    onClick={() => handleTableClick(table.tableId)}
                    disabled={!table.isAvailable}
                >
                    {table.tableId}
                </button>
            ))}
        </div> */}
        {/* Table Selection Section */}
        <div className="restaurant-map-container">
    {tables.map((table) => {
        // Determine the class for the table based on tableId
        let shapeClass = '';
        if (table.tableId === 1 || table.tableId === 2) {
            // Circular for table 1 and 2 (no change needed)
            shapeClass = '';
        } else if (table.tableId >= 3 && table.tableId <= 11) {
            // Rectangular for tables 3 to 11
            shapeClass = 'rectangular';
        } else {
            // Oval for the remaining tables (12 to 14)
            shapeClass = 'oval';
        }

        return (
            <button
                key={table.tableId}
                className={`table ${shapeClass} ${table.isAvailable ? '' : 'booked'}`}
                style={{ top: table.top, left: table.left }}
                onClick={() => handleTableClick(table.tableId)}
                disabled={!table.isAvailable}
            >
                {table.tableId}
            </button>
        );
    })}
</div>
</div>


    );
};

export default BookingPage;
