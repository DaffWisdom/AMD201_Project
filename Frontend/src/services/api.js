import axios from 'axios';

// Đổi sang false để TẮT Mock API, gọi Backend thật
const USE_MOCK = false; 

export const shortenUrl = async (originalUrl) => {
    if (USE_MOCK) {
        // Mock API response
    }

    
    const response = await axios.post('http://localhost:5000/api/url', { originalUrl });
    return response; 
};