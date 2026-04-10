# 🚀 Fullstack URL Shortener (AMD201 Project)

A Fullstack URL Shortener web application developed with modern DevOps practices, including Containerization (Docker) and a CI/CD Pipeline (GitHub Actions).

## 🛠 Tech Stack

**Frontend:**
* ReactJS (v18) + Vite
* Axios (API Client)
* ESLint (Code Quality)

**Backend:**
* ASP.NET Core Web API (.NET 9)
* Entity Framework Core (ORM)
* SQLite (Local/Container Database)
* xUnit (Unit Testing & Integration Testing)

**DevOps & Deployment:**
* Docker & Docker Compose (Multi-stage build)
* GitHub Actions (CI/CD Pipeline)
* Render (Backend Cloud Hosting)
* Vercel (Frontend Cloud Hosting)

---

## 🌟 Key Features

1. **Shorten URL:** Converts long URLs into random 6-character short codes. Automatically appends `https://` if omitted by the user.
2. **Auto Redirect:** Seamlessly redirects users from the short link to the original URL.
3. **Database Extraction:** Provides a dedicated API (`/api/url/download-db`) to extract and download the physical `urlshortener.db` file directly from the Production cloud environment (Render) for data verification.
4. **Automated Testing:** Integrates Unit and Integration Tests into the CI/CD pipeline. The workflow acts as a Quality Gate, automatically halting deployment if tests fail.

---

## 🌐 Live Demo

* **Frontend App (Vercel):** `(https://url-shortener-web-three.vercel.app/)`
* **Backend API (Render):** `https://url-shortener-api-webb.onrender.com`
* **View Full Database (JSON):** [Click here](https://url-shortener-api-webb.onrender.com/api/url/all-links)
