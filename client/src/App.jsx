import React, { useState } from "react";
import "./app.css";

const App = () => {
    const [originalUrl, setOriginalUrl] = useState("");
    const [shortenedUrl, setShortenedUrl] = useState("");
    const [error, setError] = useState("");

    const shortenUrl = async () => {
        if (!originalUrl) {
            setError("Please enter a valid URL.");
            return;
        }

        try {
            const response = await fetch("https://localhost:7072/urls", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ originalUrl }),
            });

            if (response.ok) {
                const data = await response.json();
                setShortenedUrl(`https://localhost:7072/${data.shortCode}`);
                setError("");
            } else {
                setError("Error shortening URL. Please try again.");
            }
        } catch (error) {
            setError("Error: Unable to connect to the server.");
        }
    };

    return (
        <div className="container">
            <h1>URL Shortener</h1>
            <input
                type="text"
                placeholder="Enter your URL here..."
                value={originalUrl}
                onChange={(e) => setOriginalUrl(e.target.value)}
                className="input"
            />
            <button onClick={shortenUrl} className="button">
                Shorten URL
            </button>
            <div className="result">
                {shortenedUrl && (
                    <p>
                        Shortened URL:{" "}
                        <a href={shortenedUrl} target="_blank" rel="noopener noreferrer">
                            {shortenedUrl}
                        </a>
                    </p>
                )}
                {error && <p className="error">{error}</p>}
            </div>
        </div>
    );
};

export default App;
