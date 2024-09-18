import axios from 'axios';

const bookingEndpoints = 'https://localhost:7213/api/Booking';
const tableEndpoints = 'https://localhost:7213/api/Table';
const customerEndpoints = 'https://localhost:7213/api/Customer';

// Booking API Endpoints
export const getAllBookings = async () => {
    return await axios.get(bookingEndpoints);
};

export const reserveBooking = async (booking) => {
    return await axios.post(`${bookingEndpoints}/reserve`, booking);
};

export const updateBooking = async (booking, bookingId) => {
    return await axios.put(`${bookingEndpoints}/updateBooking/${bookingId}`, booking);
};

export const deleteBooking = async (bookingId) => {  
    return await axios.delete(`${bookingEndpoints}/delete/${bookingId}`);
};

export const getBookingBasedOnId = async (bookingId) => {  
    return await axios.get(`${bookingEndpoints}/${bookingId}`);
};

// Customer API Endpoints
export const getAllCustomers = async () => {
    return await axios.get(customerEndpoints);
};

export const createCustomer = async (customer) => {  
    return await axios.post(`${customerEndpoints}/create`, customer);
};

export const updateCustomer = async (customer, customerId) => {
    return await axios.put(`${customerEndpoints}/update/${customerId}`, customer); 
};

export const deleteCustomer = async (customerId) => {
    return await axios.delete(`${customerEndpoints}/delete/${customerId}`);
};

export const getCustomerBasedOnId = async (customerId) => { 
    return await axios.get(`${customerEndpoints}/${customerId}`);
};

// Table API Endpoints
export const getAllTables = async () => {
    return await axios.get(tableEndpoints);
};

export const createTable = async (table) => {
    return await axios.post(`${tableEndpoints}/create`, table);
};

export const updateTable = async (table, tableId) => {
    return await axios.put(`${tableEndpoints}/update/${tableId}`, table);
};

export const deleteTable = async (tableId) => {
    return await axios.delete(`${tableEndpoints}/delete/${tableId}`);
};

export const getTableBasedOnId = async (tableId) => {
    return await axios.get(`${tableEndpoints}/${tableId}`);
};
