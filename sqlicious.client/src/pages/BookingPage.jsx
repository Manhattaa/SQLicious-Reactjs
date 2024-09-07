import React, { useEffect, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import axios from 'axios';

const BookingPage = () => {
    const location = useLocation();
    const navigate = useNavigate();

    // Destructure user choices passed from the previous page or set defaults
    const { selectedFood, selectedDate, selectedAmount } = location.state || {};

    // State for available times and booking status
    const [availableTimes, setAvailableTimes] = useState([]);
    const [isLoading, setIsLoading] = useState(true);  // To handle loading states
    const [error, setError] = useState(null);  // To handle errors

    // Meal time ranges based on the type of meal
    const mealTimeRanges = {
        Frukost: { start: "07:00", end: "10:00" },
        Brunch: { start: "10:00", end: "12:00" },
        Lunch: { start: "12:00", end: "15:00" },
        Middag: { start: "17:00", end: "22:00" },
        Julbord: { start: "11:00", end: "22:00" }
    };

    // Function to generate time slots for the given start and end time
    const generateTimeSlots = (start, end) => {
        const timeSlots = [];
        let currentTime = new Date(`1970-01-01T${start}:00`);
        const endTime = new Date(`1970-01-01T${end}:00`);

        while (currentTime <= endTime) {
            timeSlots.push(currentTime.toTimeString().substring(0, 5));
            currentTime = new Date(currentTime.getTime() + 30 * 60000);  // Add 30 minutes
        }

        return timeSlots;
    };

    // Fetch all bookings for the selected date from the backend
    const fetchBookingsForDate = async (selectedDate) => {
        try {
            const response = await axios.get(`http://localhost:7213/api/Booking?date=${selectedDate}`);
            return response.data; 
        } catch (error) {
            setError('Error fetching bookings. Please try again later.');
            return [];
        }
    };

    // Filter out booked time slots from the available times
    const filterAvailableTimes = (timeSlots, bookings) => {
        const bookedTimes = bookings.map(booking => booking.time); 
        return timeSlots.filter(time => !bookedTimes.includes(time)); 
    };

    // Load available times based on the selected meal and date
    useEffect(() => {
        const loadAvailableTimes = async () => {
            setIsLoading(true);
            try {
                // Fetch bookings for the specific date
                const bookings = await fetchBookingsForDate(selectedDate);

                // Generate all possible timeslots for the selected meal
                const mealTimes = generateTimeSlots(
                    mealTimeRanges[selectedFood].start,
                    mealTimeRanges[selectedFood].end
                );

                // Filter out already booked times
                const availableTimes = filterAvailableTimes(mealTimes, bookings);
                setAvailableTimes(availableTimes);
            } catch (err) {
                setError('An error occurred while loading available times.');
            } finally {
                setIsLoading(false);
            }
        };

        if (selectedFood && selectedDate) {
            loadAvailableTimes();
        } else {
            setError('Invalid selection. Please go back and choose meal, date, and amount of people.');
        }
    }, [selectedFood, selectedDate]);

    // Handle booking the selected time
    const handleBooking = async (time) => {
        try {
            await axios.post('http://localhost:7213/api/Booking/Reserve', {
                meal: selectedFood,
                date: selectedDate,
                time: time,
                people: selectedAmount
            });
            alert('Booking successful!');
            navigate('/');  // Navigate to home or confirmation page
        } catch (error) {
            alert('Error creating booking. Please try again later.');
        }
    };

    // If there's an error or no selection made, show a message
    if (error) {
        return (
            <div className="booking-page">
                <h1>Fel</h1>
                <p>{error}</p>
                <button onClick={() => navigate('/')}>Gå Tillbaka</button>
            </div>
        );
    }

    // While loading, show a loading message
    if (isLoading) {
        return <div className="loading">Laddar tillgängliga tider.. Var god vänta...</div>;
    }

    return (
        <div className="booking-page">
            <h1>Bokningssammanfattning</h1>

            {/* User's Choices */}
            <div className="summary">
                <h2>Du har valt:</h2>
                <p><strong>Måltid:</strong> {selectedFood}</p>
                <p><strong>Datum:</strong> {new Date(selectedDate).toLocaleDateString('sv-SE')}</p>
                <p><strong>Antal personer:</strong> {selectedAmount}</p>
            </div>

            {/* Available Times */}
            <div className="available-times">
                <h2>Tillgängliga tider för {selectedFood}</h2>
                <p><strong>Tidsperiod:</strong> {mealTimeRanges[selectedFood].start} - {mealTimeRanges[selectedFood].end}</p>

                {availableTimes.length > 0 ? (
                    <div className="time-slot-list">
                        {availableTimes.map((time, index) => (
                            <button key={index} className="time-slot-button" onClick={() => handleBooking(time)}>
                                {time}
                            </button>
                        ))}
                    </div>
                ) : (
                    <p>Inga tillgängliga tider hittades.</p>
                )}
            </div>
        </div>
    );
};

export default BookingPage;
