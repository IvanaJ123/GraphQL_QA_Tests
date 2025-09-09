const fetch = require("node-fetch");

test("fetch users from real GraphQL API", async () => {
  const query = `
    {
      users {
        data {
          id
          name
          username
        }
      }
    }
  `;

  const response = await fetch("https://graphqlzero.almansi.me/api", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ query })
  });

    const result = await response.json();
    console.log("Users response:", result); // Debug output

  // Check that users array exists
  expect(result.data.users.data.length).toBeGreaterThan(0);

  // Optional: check first user has id, name, username
    const firstUser = result.data.users.data[0];
    console.log("First user:", firstUser); //  Debug output
  expect(firstUser).toHaveProperty("id");
  expect(firstUser).toHaveProperty("name");
  expect(firstUser).toHaveProperty("username");
});
