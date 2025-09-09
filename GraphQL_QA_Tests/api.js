function getUsers() {
    return [
        {
            id: 1,
            name: "Alice",
            username: "alice1",
            role: "admin",
            albums: [
                { id: 101, title: "Vacation 2024" },
                { id: 102, title: "Work Photos" }
            ]
        },
        {
            id: 2,
            name: "Bob",
            username: "bob2",
            role: "user",
            albums: [
                { id: 103, title: "Birthday Party" }
            ]
        },
        {
            id: 3,
            name: "Charlie",
            username: "charlie3",
            role: "moderator",
            albums: []
        }
    ];
}

module.exports = { getUsers };
