const express = require('express');
const { exec } = require('child_process');
const app = express();
const port = 3000;

app.use(express.static('public'));

app.get('/search', (req, res) => {
    const query = req.query.q;
    exec(`./search.sh "${query}"`, (error, stdout, stderr) => {
        if (error) {
            console.error(`Error executing search: ${error}`);
            return res.status(500).send('Internal Server Error');
        }
        const results = stdout.trim().split(' ');
        res.json(results);
    });
});

app.listen(port, () => {
    console.log(`Server running at http://localhost:${port}`);
});
