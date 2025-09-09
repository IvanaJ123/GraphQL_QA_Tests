// tests/helpers/graphqlClient.js
const fetch = require('node-fetch'); // ensure node-fetch@2 is installed
const URL = 'https://graphqlzero.almansi.me/api';

async function gqlRequest(query, variables = {}) {
    const res = await fetch(URL, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ query, variables }),
    });
    const json = await res.json();
    return { status: res.status, data: json.data, errors: json.errors || null };
}

module.exports = { gqlRequest, URL };
