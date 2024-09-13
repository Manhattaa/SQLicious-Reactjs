import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Calendar from '../components/Calendar'; // Adjust path as necessary
import '../pages/indexPage.scss';

const IndexPage = () => {
    const navigate = useNavigate();

    const [selectedFood, setSelectedFood] = useState(null);
    const [selectedDate, setSelectedDate] = useState(null);
    const [selectedAmount, setSelectedAmount] = useState(null);
    const [showDatePicker, setShowDatePicker] = useState(false); // Controls calendar visibility
    const [customDate, setCustomDate] = useState(null); // Stores the selected custom date

    // Handling box clicks
    const handleFoodClick = (food) => setSelectedFood(food);
    const handleDateClick = (date) => setSelectedDate(date);
    const handleAmountClick = (amount) => setSelectedAmount(amount);
    
    const handleLoginClick = () => {
        if (selectedFood && selectedDate && selectedAmount) {
            navigate('/booking', {
                state: {
                    selectedFood,
                    selectedDate: selectedDate.toISOString(), // Pass the selected date as ISO string
                    selectedAmount
                }
            });
        } else {
            alert("Please select all required fields");
        }
    };

    // Helper function to show names of the day in Swedish
    const getWeekday = (date) => date.toLocaleDateString('sv-SE', { weekday: 'long' });
    const getMonthDay = (date) => date.toLocaleDateString('sv-SE', { day: 'numeric', month: 'long' });

    // Get today's date
    const today = new Date();
    const tomorrow = new Date(today);
    tomorrow.setDate(today.getDate() + 1);

    const datePlusTwoDays = new Date(today);
    datePlusTwoDays.setDate(today.getDate() + 2);

    const datePlusThreeDays = new Date(today);
    datePlusThreeDays.setDate(today.getDate() + 3);

    // Handle custom date selection
    const handleCustomDateSelect = (date) => {
        setCustomDate(date); // Set the selected custom date
        setSelectedDate(date); // Also update selected date
        setShowDatePicker(false); // Close the calendar overlay
    };

    // Compare dates (ignoring time) for highlighting
    const isSameDate = (date1, date2) => {
        if (!date1 || !date2) return false; // If either date is null or undefined, return false
        return (
            date1.getFullYear() === date2.getFullYear() &&
            date1.getMonth() === date2.getMonth() &&
            date1.getDate() === date2.getDate()
        );
    };

    return (
        <div id="root">
            <div className="content-container">
                {/* Food Section */}
                <h1 className="header-container">Måltid</h1>
                <div className="food-container">
                    {['Frukost', 'Lunch', 'Brunch', 'Middag', 'Julbord'].map((food) => (
                        <div
                            key={food}
                            className={`food-box ${selectedFood === food ? 'selected' : ''}`}
                            onClick={() => handleFoodClick(food)}
                        >
                            <h2>{food}</h2>
                        </div>
                    ))}
                </div>

                {/* Date Section */}
                <h1 className="header-container">Datum</h1>
                <div className="date-container">
                    <div
                        className={`date-box ${isSameDate(selectedDate, today) ? 'selected' : ''}`}
                        onClick={() => handleDateClick(today)}
                    >
                        <h2>Idag ({getWeekday(today)})</h2>
                    </div>
                    <div
                        className={`date-box ${isSameDate(selectedDate, tomorrow) ? 'selected' : ''}`}
                        onClick={() => handleDateClick(tomorrow)}
                    >
                        <h2>Imorgon ({getWeekday(tomorrow)})</h2>
                    </div>
                    <div
                        className={`date-box ${isSameDate(selectedDate, datePlusTwoDays) ? 'selected' : ''}`}
                        onClick={() => handleDateClick(datePlusTwoDays)}
                    >
                        <h2>{getWeekday(datePlusTwoDays)}</h2>
                    </div>
                    <div
                        className={`date-box ${isSameDate(selectedDate, datePlusThreeDays) ? 'selected' : ''}`}
                        onClick={() => handleDateClick(datePlusThreeDays)}
                    >
                        <h2>{getWeekday(datePlusThreeDays)}</h2>
                    </div>

                    {/* Custom date section */}
                    {customDate && (
                        <div className="date-box selected">
                            <h2>{getMonthDay(customDate)}</h2>
                        </div>
                    )}

                    <div
                        className="date-box"
                        onClick={() => setShowDatePicker(true)} // Show the calendar overlay
                    >
                        <h2>Annan dag</h2>
                    </div>
                </div>

                {/* Amount Section */}
                <h1 className="header-container">Antal personer</h1>
                <div className="amount-container">
                    {['1', '2', '3', '4', '5', '6', '7', '8', 'Fler än 8'].map((amount) => (
                        <div
                            key={amount}
                            className={`amount-box ${selectedAmount === amount ? 'selected' : ''}`}
                            onClick={() => handleAmountClick(amount)}
                        >
                            <h2>{amount}</h2>
                        </div>
                    ))}
                </div>
            </div>

            {/* Search Button */}
            <button className="btn-search-container" onClick={handleLoginClick}>Sök</button>

            {/* Calendar component (overlay) */}
            {showDatePicker && (
                <Calendar
                    selectedDate={customDate}
                    onDateSelect={handleCustomDateSelect} // Pass the function to handle date selection
                    onClose={() => setShowDatePicker(false)} // Close calendar when "Stäng" is clicked
                />
            )}
        </div>
    );
};

export default IndexPage;
