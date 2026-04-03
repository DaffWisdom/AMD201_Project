import React from 'react';

const Footer = () => {
    return (
        <footer className="footer">
            <div className="footer-content">
                <p>&copy; {new Date().getFullYear()} DevOps URL Shortener. Coursework Project.</p>
                <div className="footer-links">
                    <a href="#privacy">Privacy</a>
                    <span className="dot">•</span>
                    <a href="#terms">Terms</a>
                    <span className="dot">•</span>
                    <a href="#contact">Contact</a>
                </div>
            </div>
        </footer>
    );
};

export default Footer;