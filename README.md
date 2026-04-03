🔗 URL Shortener

A modern URL shortening web application that converts long URLs into short, easy-to-share links. Built with React for the frontend and Node.js + MySQL for the backend.

🚀 Features
🔗 Shorten long URLs instantly
⚡ Fast redirection to original links
✏️ Custom short codes (optional)
📊 Track number of clicks (optional)
🌐 RESTful API
💻 Responsive UI with React
🛠️ Tech Stack
Frontend
React
Axios
CSS / Tailwind (optional)
Backend
Node.js
Express.js
Database
MySQL
📦 Installation
1. Clone the repository
git clone https://github.com/daffwisdom/AMD_Project
cd url-shortener
2. Setup Backend
cd backend
npm install
npm run dev
3. Setup Frontend
cd frontend
npm install
npm start

📊 Example

Original URL:

https://example.com/some/very/long/link

Short URL:

http://localhost:5173/
🧠 How It Works
User inputs a long URL on the React frontend
Frontend sends request to backend API
Server generates a unique short code
Data is stored in MySQL database
When accessing the short URL, server redirects to original URL
