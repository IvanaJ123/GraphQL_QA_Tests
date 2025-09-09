// api.albums.users.test.js
const { gqlRequest } = require('./helpers/graphqlClient.js');

// -----------------
// REAL API TESTS
// -----------------
describe("Task 1: Basic API testing — Users & Albums (GraphQLZero) [REAL API]", () => {
    test("[Query] fetch users returns list of users", async () => {
        const query = `
            query {
                users {
                    data {
                        id
                        name
                    }
                }
            }
        `;

        const { data } = await gqlRequest(query);

        expect(data.users).toBeTruthy();
        expect(Array.isArray(data.users.data)).toBe(true);
    });

    test("[Mutation] updateAlbum changes title of just-created album", async () => {
        const updateMutation = `
            mutation($id: ID!, $title: String!) {
                updateAlbum(id: $id, input: { title: $title }) {
                    id
                    title
                }
            }
        `;

        const { data } = await gqlRequest(updateMutation, {
            id: "101",
            title: "QA Album - updated"
        });

        expect(data.updateAlbum).toBeTruthy();
        expect(data.updateAlbum.title).toBe("QA Album - updated");
    });
});


// -----------------
// MOCKED API TESTS
// -----------------
describe("Task 1: Basic API testing — Users & Albums (GraphQLZero) [MOCKED]", () => {
    beforeAll(() => {
        jest.mock('./__mocks__/graphqlClient.js'); // replace gqlRequest with __mocks__/graphqlClient.js
    });

    afterAll(() => {
        jest.unmock('./__mocks__/graphqlClient.js'); // restore real gqlRequest for other files
    });

    const gqlRequest = require('./__mocks__/graphqlClient.js'); // re-import after mock

    test("[Query] fetch users returns mocked list", async () => {
        const query = `
            query {
                users {
                    data {
                        id
                        name
                        albums
                    }
                }
            }
        `;

        const { data } = await gqlRequest(query);

        expect(data.users.data.length).toBeGreaterThan(0);
        expect(data.users.data[0]).toHaveProperty("id");
        expect(data.users.data[0]).toHaveProperty("name");
    });

    test("[Error] requesting non-existent field produces GraphQL errors[]", async () => {
        const badQuery = `
            query {
                users {
                    madeUpField
                }
            }
        `;

        const { status, errors } = await gqlRequest(badQuery);

        expect(status).toBe(200); // GraphQL spec: even errors come with 200
        console.log("status - errors:" + status + " - " + errors);
        expect(Array.isArray(errors)).toBe(true);
    });
});
