# 🔗 .NET URL Shortener Service with CI/CD

A modern, scalable URL shortening service built with **.NET 9.0** and **React (Vite)**. [cite_start]This project demonstrates the implementation of a full-stack application following professional DevOps principles, including containerization and automated CI/CD pipelines.

## 🚀 Features
* [cite_start]**Link Shortening**: Converts long URLs into manageable 6-character unique codes[cite: 3].
* [cite_start]**Automatic Redirection**: Seamlessly redirects users from shortened links to original destinations[cite: 3].
* [cite_start]**Data Persistence**: Stores URL mappings and metadata using SQLite via Entity Framework Core[cite: 3].
* [cite_start]**Modern UI**: Intuitive frontend dashboard built with React and Vite for easy link management[cite: 3].
* [cite_start]**Containerization**: Fully ready to be packaged with Docker for consistent deployment.
* [cite_start]**Automated CI/CD**: Designed for a full pipeline of building, testing, and deploying.

## 🛠️ Tech Stack
### Backend
* [cite_start]**Framework**: .NET 9.0 Web API.
* [cite_start]**ORM**: Entity Framework Core[cite: 3].
* [cite_start]**Database**: SQLite (Local development/Portability)[cite: 4].
* [cite_start]**API**: RESTful architecture[cite: 19].

### Frontend
* [cite_start]**Library**: React.js (Vite)[cite: 20].
* [cite_start]**Styling**: CSS & UI Components[cite: 3].
* [cite_start]**Feedback**: React Hot Toast for real-time notifications[cite: 3].


## 📦 Installation
1. Clone the repository
git clone https://github.com/daffwisdom/AMD_Project
cd url-shortener
2. Setup Backend
cd Backend/UrlShortener.Api
npm install
dotnet run
3. Setup Frontend
cd frontend
npm install
npm run dev

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
