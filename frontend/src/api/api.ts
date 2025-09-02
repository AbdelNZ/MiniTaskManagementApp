import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5295/api",
});

export default api;
