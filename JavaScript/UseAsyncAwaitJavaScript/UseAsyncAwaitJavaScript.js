// Function definition using Promise object

function getDataAsync() {
    return new Promise((resolve, reject) => {
        try {
            let data = getSomeData();
            return resolve(data);
        } catch (e) {
            return reject(e);
        }
    });
}


// Function definition using async keyword

async function getDataAsync() {
    try {
        let data = getSomeData();
        return data;
    } catch (e) {
        throw new Error(e);
    }
}


// Function call using Promise object

function getDataAndDoSomethingAsync() {
    getDataAsync()
        .then((data) => {
            doSomethingHere(data);
        });
}


// Function call using `await` keyword

async function getDataAndDoSomethingAsync() {
    let data = await getDataAsync();
    doSomethingHere(data);
}