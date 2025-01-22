import { jwtDecode } from "jwt-decode";
import Cookies from 'js-cookie';

// export const jwtToken = () => {
//     const token = Cookies.get('token');
//     if (!token) {
//         return null; 
//     }
//     try {
//         return jwtDecode(token);
//     } catch (error) {
//         console.error('Error decoding token:', error);
//         return null;
//     }
// };


export const jwtToken = () => {
    try {
        const token = Cookies.get('token');
        if (!token) return null;
        
        const decoded = jwtDecode(token);
        if (!decoded || !decoded.role) return null;
        
        return decoded;
    } catch (error) {
        console.error('Token validation error:', error);
        Cookies.remove('token'); // Clear invalid token
        return null;
    }
};