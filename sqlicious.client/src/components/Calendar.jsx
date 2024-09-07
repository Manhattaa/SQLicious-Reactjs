import React from 'react';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import '../components/Calendar.scss';

const Calendar = ({ selectedDate, onDateSelect, onClose }) => {
    return (
        <div className="calendar-overlay">
            <div className="calendar-popup">
                <h2>Välj ett datum</h2>
                <DatePicker
                    selected={selectedDate}
                    onChange={onDateSelect}
                    inline
                    dateFormat="dd/MM/yyyy"
                />
                <button onClick={onClose}>Stäng</button>
            </div>
        </div>
    );
};

export default Calendar;
