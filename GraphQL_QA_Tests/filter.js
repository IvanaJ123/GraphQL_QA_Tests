// Filter users by username
function filterUsersByUsername(users, username) {
    return users.filter(user => user.username === username);
}

// Filter users by role
function filterUsersByRole(users, role) {
    return users.filter(user => user.role === role);
}

// Filter albums by user ID
function filterAlbumsByUserId(users, userId) {
    const user = users.find(u => u.id === userId);
    return user ? user.albums : [];
}

module.exports = { filterUsersByUsername, filterUsersByRole, filterAlbumsByUserId };
