import React from 'react';
import { Link, Code } from 'lucide-react'; // Đã thay Github thành Code

const Navbar = () => {
    return (
        <nav className="navbar">
            <div className="nav-brand">
                <Link className="brand-icon" size={28} />
                <span className="brand-name">DevOps<span className="text-highlight">Short</span></span>
            </div>
            
            <div className="nav-links">
                <a href="#features">Features</a>
                <a href="#api">API Docs</a>
                <a href="#pricing">Pricing</a>
            </div>

            <div className="nav-actions">
                <a href="https://github.com" target="_blank" rel="noopener noreferrer" className="btn-github">
                    <Code size={20} /> {/* Đã thay thẻ <Github /> thành <Code /> */}
                    <span>Source Code</span>
                </a>
            </div>
        </nav>
    );
};

export default Navbar;