const apiUrl = 'https://localhost:7169/';

export async function getAllUrl() {

    try{
        const response = await fetch(apiUrl + 'api/getAll');
        return await response.json();
    }catch(error) {
        return [];
    }
    
}

export async function createShortUrl(url) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json'},
        body: JSON.stringify(url)
    };
    const response = await fetch(apiUrl + `api/createShortUrl`, requestOptions)
    return await response.json();
}