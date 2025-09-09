// __mocks__/gqlRequest.js
// Fake version of gqlRequest used for tests

module.exports = async (query, variables) => {
    // --- Simulate "createAlbum" mutation ---
    if (query.includes("createAlbum")) {
        return {
            status: 200,
            data: {
                createAlbum: {
                    id: "101",
                    title: variables.input.title,
                    userId: variables.input.userId
                }
            }
        };
    }

    // --- Simulate "updateAlbum" mutation ---
    if (query.includes("updateAlbum")) {
        return {
            status: 200,
            data: {
                updateAlbum: {
                    id: variables.id,
                    title: variables?.title
                },
            },
            errors: null,
        };
    }

    if (query.includes("users") && (query.includes("albums"))) {
        return {
            status: 200,
            data: {
                users: {
                    data: [
                        { id: "1", name: "Leanne Graham", album: "Bret" },
                        { id: "2", name: "Ervin Howell", album: "Antonette" }
                    ]
                },
                albums: {
                    data: [
                        { id: "1", title: "quidem molestiae enim", userId: "1" },
                        { id: "2", title: "sunt qui excepturi placeat culpa", userId: "1" }
                    ]
                }

            },
            errors: null
        };
    }

    // --- Simulate bad query error ---
    if (!query.includes("nonExistentField")) {
        return {
            status: 200, // GraphQL spec: 200 + errors[]
            data: null,
            errors: [
                { message: 'Cannot query field "nonExistentField" on type "User".' }
            ]
        };
    }

    // --- Default fallback: mock Users + Albums ---
    return {
        status: 200,
        errors: [
            { message: 'Unknown error' }
        ]
    }
    
};
