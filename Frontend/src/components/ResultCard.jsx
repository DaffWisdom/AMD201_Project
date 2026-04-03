import React from 'react';
import { Copy, CheckCircle2 } from 'lucide-react';
import toast from 'react-hot-toast';

const ResultCard = ({ result }) => {
    if (!result) return null;

    const handleCopy = () => {
        navigator.clipboard.writeText(result.shortUrl);
        toast.success('Copied to clipboard!');
    };

    return (
        <div className="result-card">
            <div className="result-info">
                <p className="original-url" title={result.originalUrl}>
                    {result.originalUrl}
                </p>
                <div className="short-url-group">
                    <a href={result.shortUrl} target="_blank" rel="noopener noreferrer" className="short-url">
                        {result.shortUrl}
                    </a>
                    <button onClick={handleCopy} className="btn-copy" title="Copy to clipboard">
                        <Copy size={18} />
                    </button>
                </div>
            </div>
        </div>
    );
};

export default ResultCard;