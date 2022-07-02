import axios from 'axios';

const api = axios.create({
    baseURL: "https://localhost:7047",
})

export default api;