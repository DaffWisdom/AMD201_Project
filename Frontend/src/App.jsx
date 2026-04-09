import React, { useState } from 'react';
import { Toaster } from 'react-hot-toast';
import toast from 'react-hot-toast';
import Navbar from './components/Navbar'; 
import Footer from './components/Footer'; 
import UrlForm from './components/UrlForm';
import ResultCard from './components/ResultCard';
import { shortenUrl } from './services/api';
import './App.css';

function App() {
    const [isLoading, setIsLoading] = useState(false);
    const [result, setResult] = useState(null);

    const handleShorten = async (originalUrl) => {
        setIsLoading(true);
        setResult(null);

        try {
            const response = await shortenUrl(originalUrl);
            setResult(response.data);
            toast.success('URL shortened successfully!');
        } catch (error) {
            toast.error(error.message || 'Something went wrong. Please try again.');
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <div className="app-layout">
            <Toaster position="top-center" reverseOrder={false} />
            
            {/* Thanh điều hướng ở trên cùng */}
            <Navbar />

            {/* Phần nội dung chính (bọc trong thẻ main) */}
            <main className="main-content">
                <div className="app-container">
                    <header className="app-header">
                        <h1>Shorten Your Links</h1>
                        <p>Paste your long link below to get a clean, shortened URL.</p>
                    </header>

                    <UrlForm onSubmit={handleShorten} isLoading={isLoading} />
                    <ResultCard result={result} />
                </div>
            </main>

            {/* Thanh chân trang ở dưới cùng */}
            <Footer />
        </div>
    );
}

export default App;