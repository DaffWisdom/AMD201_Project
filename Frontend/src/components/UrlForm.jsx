import React, { useState } from 'react';
import { Link } from 'lucide-react';

const UrlForm = ({ onSubmit, isLoading }) => {
    const [url, setUrl] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        if (url.trim()) {
            onSubmit(url);
        }
    };

    return (
        <form onSubmit={handleSubmit} className="url-form">
            <div className="input-group">
                <Link className="icon" size={20} />
                <input
                    type="url"
                    placeholder="Enter your long URL here (e.g., https://example.com)"
                    value={url}
                    onChange={(e) => setUrl(e.target.value)}
                    required
                    disabled={isLoading}
                />
                <button type="submit" disabled={isLoading || !url}>
                    {isLoading ? 'Shortening...' : 'Shorten'}
                </button>
            </div>
        </form>
    );
};

export default UrlForm;