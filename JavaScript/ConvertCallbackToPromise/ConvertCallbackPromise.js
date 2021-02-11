// Callback function example using the Node.js fs.readFile function

fs.readFile("MyTextFile.txt", "utf8", (err, data) => {
    if (err) {
        throw err;
    }

    console.log(data);
});


// Create a “wrapper” function to use a promise object instead of a callback function

async function readFileAsync(path) {
    return new Promise((resolve, reject) => {
        fs.readFile(path, "utf8", async (err, data) => {
            if (err) {
                return reject(err);
            } else {
                return resolve(files);
            }
        });
    })
}


// Using the “wrapper” function with a promise object

getFilesAsync("MyTextFile.txt")
    .then(data => {
        console.log(data);
    })
    .catch(error => {
        throw error;
    });


// Alternatively, it is also possible to use this function with async/await operators.

try {
    const textContent = await getFilesAsync("MyTextFile.txt");
    console.log(textContent);
} catch (error) {
    throw error;
}