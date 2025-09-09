const { getUsers } = require("./api");
const { filterUsersByUsername, filterUsersByRole, filterAlbumsByUserId } = require("./filter");

/*test("filter user by username", () => {
    const users = getUsers();
    const result = filterUsersByUsername(users, "bob2");
    expect(result).toEqual([{ id: 2, name: "Bob", username: "bob2", role: "user" }]);
});

test("filter user by role 'admin'", () => {
    const users = getUsers();
    const result = filterUsersByRole(users, "admin");
    expect(result).toEqual([
        { id: 1, name: "Alice", username: "alice1", role: "admin" },
        { id: 5, name: "Eva", username: "eva5", role: "admin" }
    ]);
});

test("filter user by role 'user'", () => {
    const users = getUsers();
    const result = filterUsersByRole(users, "user");
    expect(result).toEqual([
        { id: 2, name: "Bob", username: "bob2", role: "user" },
        { id: 4, name: "David", username: "david4", role: "user" }
    ]);
});

test("filter with username that does not exist", () => {
    const users = getUsers();
    const result = filterUsersByUsername(users, "nonexistent");
    expect(result).toEqual([]);
});

test("filter with role that does not exist", () => {
    const users = getUsers();
    const result = filterUsersByRole(users, "guest");
    expect(result).toEqual([]);
});*/
test("filter albums for user with ID 1", () => {
    const users = getUsers();
    const albums = filterAlbumsByUserId(users, 1);
    expect(albums).toEqual([
        { id: 101, title: "Vacation 2024" },
        { id: 102, title: "Work Photos" }
    ]);
});

test("filter albums for user with no albums", () => {
    const users = getUsers();
    const albums = filterAlbumsByUserId(users, 3);
    expect(albums).toEqual([]);
});

test("filter albums for non-existent user", () => {
    const users = getUsers();
    const albums = filterAlbumsByUserId(users, 99);
    expect(albums).toEqual([]);
});

test("filter user by username", () => {
    const users = getUsers();
    const result = filterUsersByUsername(users, "alice1");
    expect(result).toEqual([
        {
            id: 1,
            name: "Alice",
            username: "alice1",
            role: "admin",
            albums: [
                { id: 101, title: "Vacation 2024" },
                { id: 102, title: "Work Photos" }
            ]
        }
    ]);
});